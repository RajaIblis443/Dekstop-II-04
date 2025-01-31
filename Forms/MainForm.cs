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
    public partial class MainForm : Form
    {
        
        private readonly EventDal _eventDal;
        public MainForm()
        {
            InitializeComponent();
            RegisterEventHandler();
            _eventDal = new EventDal();
            RegisterInitializeComponent();
        }
        //Event
        private void RegisterEventHandler()
        {
            btnPartipants.Click += BtnPartipants_Click;
            btnSimulation.Click += BtnSimulation_Click;
        }

        private void BtnSimulation_Click(object? sender, EventArgs e)
        {
            var result = Simulation();
            if (result == null)
            {
                MessageBox.Show("No event selected or event data is invalid.");
                return;
            }

            MarathonSimulation marathon = new MarathonSimulation(result.EventID, result.EventName, (int)result.DistanceKm);
            marathon.Show();
            this.Hide();
        }

        private void BtnPartipants_Click(object? sender, EventArgs e)
        {
            if (comboEvent.SelectedItem != null)
            {
                var selectedEvent = (dynamic)comboEvent.SelectedItem;
                int selectedId = selectedEvent.Id;

                Participants participants = new Participants(selectedId);
                participants.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Selected Event");
            }
        }



        //Initialize
        private void RegisterInitializeComponent()
        {
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            comboEvent.Items.Clear();

            var result = _eventDal.GetAllEvent();

            foreach (var item in result)
            {
                comboEvent.Items.Add(new { Id = item.EventID, Name = item.EventName });
                comboEvent.DisplayMember = "Name";
                comboEvent.ValueMember = "Id";
            }
        }

        private Event Simulation()
        {
            if (comboEvent.SelectedItem != null)
            {
                var selectedEvent = (dynamic)comboEvent.SelectedItem;
                int selectedId = selectedEvent.Id;
                return _eventDal.GetEventById(selectedId);
            }
            else
            {
                MessageBox.Show("Selected Event");
                return null;
            }
        }
    }
}
