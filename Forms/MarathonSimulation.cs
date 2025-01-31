using Dekatop_II_04.DataAccess;
using Dekatop_II_04.Models;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Dekatop_II_04.Forms
{
    public partial class MarathonSimulation : Form
    {
        private readonly SimulationDal _simulationDal;
        private readonly List<Participant> _participants;
        private readonly Dictionary<int, Guna2ProgressBar> _progressBars;
        private readonly Dictionary<int, Guna2HtmlLabel> _labels;
        private System.Windows.Forms.Timer _timer;
        private readonly DateTime _startTime;
        private readonly int _totalDistance;
        private const int PROGRESS_BAR_WIDTH = 400;
        private const int VERTICAL_SPACING = 30;
        private const int TIMER_INTERVAL = 50;
        private const int LABEL_X_POSITION = 10;
        private const int PROGRESS_BAR_X_POSITION = 100;
        private const int INITIAL_Y_OFFSET = 50;
        private const double SPEED_MULTIPLIER = 10.0;

        public MarathonSimulation(int eventId, string eventName, int distanceKm)
        {
            InitializeComponent();

            if (string.IsNullOrWhiteSpace(eventName))
                throw new ArgumentException("Event name cannot be empty", nameof(eventName));

            if (distanceKm <= 0)
                throw new ArgumentException("Distance must be greater than 0", nameof(distanceKm));

            _simulationDal = new SimulationDal();
            _participants = new List<Participant>();
            _progressBars = new Dictionary<int, Guna2ProgressBar>();
            _labels = new Dictionary<int, Guna2HtmlLabel>();
            _startTime = DateTime.Now;
            _totalDistance = distanceKm * 1000;

            Text = $"Simulation: {eventName}";

            LoadParticipants(eventId);
            InitializeSimulation();
            InitializeStartButton();
        }

        private void LoadParticipants(int eventId)
        {
            if (eventId <= 0)
                throw new ArgumentException("Invalid event ID", nameof(eventId));

            try
            {
                var loadedParticipants = _simulationDal.LoadParticipants(eventId);

                if (loadedParticipants == null || !loadedParticipants.Any())
                {
                    MessageBox.Show("No participants found for this event.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _participants.AddRange(loadedParticipants);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading participants: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeSimulation()
        {
            if (!_participants.Any()) return;

            int yOffset = INITIAL_Y_OFFSET;

            foreach (var participant in _participants)
            {
                if (!participant.ParticipantId.HasValue) continue;

                CreateParticipantControls(participant, yOffset);
                yOffset += VERTICAL_SPACING;
            }
        }

        private void CreateParticipantControls(Participant participant, int yOffset)
        {
            Guna2HtmlLabel lblParticipant = new Guna2HtmlLabel()
            {
                Text = participant.Name,
                Location = new Point(LABEL_X_POSITION, yOffset),
                AutoSize = true
            };

            Guna2ProgressBar progressBar = new Guna2ProgressBar()
            {
                Location = new Point(PROGRESS_BAR_X_POSITION, yOffset),
                Width = PROGRESS_BAR_WIDTH,
                Maximum = _totalDistance,
                Value = 0
            };

            Controls.Add(lblParticipant);
            Controls.Add(progressBar);

            _progressBars[participant.ParticipantId.Value] = progressBar;
            _labels[participant.ParticipantId.Value] = lblParticipant;
        }

        private void InitializeStartButton()
        {
            if (btnStart == null)
            {
                MessageBox.Show("Start button not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnStart.Click += StartSimulation;
        }

        private void StartSimulation(object sender, EventArgs e)
        {
            if (!_participants.Any())
            {
                MessageBox.Show("No participants available to simulate.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnStart.Enabled = false; // Prevent multiple starts

            _timer = new System.Windows.Forms.Timer
            {
                Interval = TIMER_INTERVAL
            };
            _timer.Tick += UpdateSimulation;
            _timer.Start();
        }

        private void UpdateSimulation(object sender, EventArgs e)
        {
            bool allFinished = true;

            foreach (var participant in _participants)
            {
                if (!participant.ParticipantId.HasValue || !participant.Speed.HasValue) continue;

                var progressBar = _progressBars[participant.ParticipantId.Value];
                if (progressBar.Value < _totalDistance)
                {
                    double timeFactor = (_timer.Interval / 1000.0) * SPEED_MULTIPLIER;
                    
                    double speed = Convert.ToDouble(participant.Speed.Value);
                    int moveDistance = Math.Max((int)(speed * timeFactor), 1);
                    progressBar.Value = Math.Min(progressBar.Value + moveDistance, _totalDistance);
                    allFinished = false;
                }
            }

            if (allFinished)
            {
                _timer.Stop();
                ShowResults();
            }
        }

        private void ShowResults()
        {
            var results = _participants
                .Where(p => p.Speed.HasValue && p.Speed.Value > 0)
                .Select(p => new ParticipantResult
                {
                     NameParticipant = p.Name,
                    TimeTaken = TimeSpan.FromSeconds(_totalDistance / (Convert.ToDouble(p.Speed.Value) * SPEED_MULTIPLIER))
                })
                .OrderBy(r => r.TimeTaken)
                .ToList();

            if (!results.Any())
            {
                MessageBox.Show("No valid results to display.", "Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RankParticipant rankParticipant = new RankParticipant(results);
            rankParticipant.Show();
            this.Close();

            btnStart.Enabled = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _timer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}