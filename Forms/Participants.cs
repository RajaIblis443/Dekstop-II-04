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
    public partial class Participants : Form
    {
        private readonly EventDal _eventDal;
        private readonly ParticipantDal _participantDal;
        protected int eventId;
        public Participants(int id)
        {
            _participantDal = new ParticipantDal();
            eventId = id;
            _eventDal = new EventDal();
            InitializeComponent();
            RegisterEventHandle();
            RegisterInitialize();
        }
        //
        //Event
        //
        private void RegisterEventHandle()
        {
            
            lblBack.Click += LblBack_Click;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dataParticipants.SelectedRows.Count > 0)
            {
                int participantId = int.Parse(dataParticipants.SelectedRows[0].Cells["Id"].Value.ToString());
                var result = _participantDal.deleteUser(participantId);
                if (result)
                {
                    dataGrid(eventId);
                }
            }
            else
            {
                MessageBox.Show("Pilih peserta yang ingin diedit.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            if (dataParticipants.SelectedRows.Count > 0)
            {
                int participantId = int.Parse(dataParticipants.SelectedRows[0].Cells["Id"].Value.ToString());
                UpdateForm updateForm = new UpdateForm(participantId);
                if (updateForm.Visible)
                {
                    updateForm.Close();
                }
                updateForm.DataUpdated += () =>
                {
                    dataGrid(eventId);
                };
                updateForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pilih peserta yang ingin diedit.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            AddForm addForm = new AddForm(eventId);

            addForm.DataAdded += () =>
            {
                dataGrid(eventId);
            };

            addForm.ShowDialog();

        }

        private void LblBack_Click(object? sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }

        //
        //Initialize
        //
        private void RegisterInitialize()
        {
            dataGrid(eventId);
        }


        private void dataGrid(int id)
        {
            dataParticipants.Rows.Clear();
            dataParticipants.Columns.Clear();
            dataParticipants.Columns.Add("Id", "Id");
            dataParticipants.Columns.Add("EventName", "Event Name");
            dataParticipants.Columns.Add("DistanceKm", "Distance (km)");
            dataParticipants.Columns.Add("ParticipantName", "Name");
            dataParticipants.Columns.Add("ParticipantAge", "Age");
            dataParticipants.Columns.Add("ParticipantSpeed", "Speed");

            var items = _eventDal.GetEventWithParticipantsByEventId(id);

            foreach (var item in items)
            {
                foreach (var participant in item.Participant)
                {
                    dataParticipants.Rows.Add(participant.ParticipantId, item.EventName, item.DistanceKm, participant.Name, participant.Age, participant.Speed);
                }
            }

            dataParticipants.Refresh();
        }
    }
}
