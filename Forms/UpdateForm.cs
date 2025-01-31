using Dekatop_II_04.DataAccess;
using Dekatop_II_04.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dekatop_II_04.Forms
{
    public partial class UpdateForm : Form
    {
        public event Action DataUpdated;

        private readonly ParticipantDal _participantDal;
        private int participantId;
        public UpdateForm(int id)
        {
            _participantDal = new ParticipantDal();
            participantId = id;
            InitializeComponent();
            RegisterEventHandler();
            GetById();
        }

        //Register Event Handler
        private void RegisterEventHandler()
        {
            btnSave.Click += BtnSave_Click;
            
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            UpdateUser();
        }


        //Validation
        private void GetById()
        {
            var participant = _participantDal.getUserById(participantId);

            if (participant == null)
            {
                MessageBox.Show("Peserta tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            textName.Text = participant.Name;
            textAge.Text = participant.Age.ToString();
            textSpeed.Text = participant.Speed.ToString();
           
        }



        private void UpdateUser()
        {
            if (string.IsNullOrWhiteSpace(textName.Text) ||
                string.IsNullOrWhiteSpace(textSpeed.Text) ||
                string.IsNullOrWhiteSpace(textAge.Text))
            {
                MessageBox.Show("Isi semua bidang yang kosong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textSpeed.Text, out decimal speed) || speed <= 0)
            {
                MessageBox.Show("Masukkan kecepatan yang valid (angka positif).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textAge.Text, out int age) || age <= 0 || age > 120)
            {
                MessageBox.Show("Masukkan umur yang valid (angka antara 1 dan 120).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var participant = new Participant()
            {
                ParticipantId = participantId,
                Name = textName.Text,
                Age = age,
                Speed = speed
            };

            try
            {
                var result = _participantDal.UpdateUser(participant);

                if (result)
                {
                    DataUpdated?.Invoke();

                    MessageBox.Show("Peserta berhasil diubah.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
