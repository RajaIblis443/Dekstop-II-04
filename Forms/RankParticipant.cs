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
    public partial class RankParticipant : Form
    {
        private List<ParticipantResult> participants;

        public RankParticipant(List<ParticipantResult> Lparticipants)
        {
            participants = Lparticipants.ToList();
            InitializeComponent();
            DisplayResult();
        }

        private void DisplayResult()
        {
            foreach (var participant in participants)
            {
                datasetRace.DataPoints.Add(participant.NameParticipant,participant.TimeTaken.TotalSeconds);
            }
            chartRace.Title.Text = "Rank Peserta";
        }
        
    }
}
