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
    public partial class AddForm : Form
    {
        public event Action DataAdded;

        private readonly ParticipantDal _participantDal;
        private int eventId;
        public AddForm(int id)
        {
            eventId = id;
            _participantDal = new ParticipantDal();
            InitializeComponent();
            RegisterEventHandler();
        }

        //Register Event Handler
        public void RegisterEventHandler()
        {
            btnSave.Click += BtnSave_Click;
            lblBack.Click += LblBack_Click;
        }

        private void LblBack_Click(object? sender, EventArgs e)
        {
            Participants participants = new Participants(eventId);
            participants.Show();
            this.Close(); 

        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            AddUser();
        }

        public void AddUser()
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
                Name = textName.Text.Trim(),
                Age = age,
                EventId = eventId,
                Speed = speed,
            };

            
            try
            {
                _participantDal.AddUser(participant);

                DataAdded?.Invoke();

                MessageBox.Show("Peserta berhasil ditambahkan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                textName.Clear();
                textSpeed.Clear();
                textAge.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
