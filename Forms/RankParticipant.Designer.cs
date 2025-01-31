namespace Dekatop_II_04.Forms
{
    partial class RankParticipant
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.Charts.WinForms.ChartFont chartFont1 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont2 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont3 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont4 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid1 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick1 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont5 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid2 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick2 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont6 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid3 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.PointLabel pointLabel1 = new Guna.Charts.WinForms.PointLabel();
            Guna.Charts.WinForms.ChartFont chartFont7 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Tick tick3 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont8 = new Guna.Charts.WinForms.ChartFont();
            chartRace = new Guna.Charts.WinForms.GunaChart();
            datasetRace = new Guna.Charts.WinForms.GunaHorizontalBarDataset();
            SuspendLayout();
            // 
            // chartRace
            // 
            chartRace.Datasets.AddRange(new Guna.Charts.Interfaces.IGunaDataset[] { datasetRace });
            chartFont1.FontName = "Arial";
            chartRace.Legend.LabelFont = chartFont1;
            chartRace.Location = new Point(10, 12);
            chartRace.Name = "chartRace";
            chartRace.Size = new Size(730, 332);
            chartRace.TabIndex = 0;
            chartFont2.FontName = "Arial";
            chartFont2.Size = 12;
            chartFont2.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            chartRace.Title.Font = chartFont2;
            chartFont3.FontName = "Arial";
            chartRace.Tooltips.BodyFont = chartFont3;
            chartFont4.FontName = "Arial";
            chartFont4.Size = 9;
            chartFont4.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            chartRace.Tooltips.TitleFont = chartFont4;
            chartRace.XAxes.GridLines = grid1;
            chartFont5.FontName = "Arial";
            tick1.Font = chartFont5;
            chartRace.XAxes.Ticks = tick1;
            chartRace.YAxes.GridLines = grid2;
            chartFont6.FontName = "Arial";
            tick2.Font = chartFont6;
            chartRace.YAxes.Ticks = tick2;
            chartRace.ZAxes.GridLines = grid3;
            chartFont7.FontName = "Arial";
            pointLabel1.Font = chartFont7;
            chartRace.ZAxes.PointLabels = pointLabel1;
            chartFont8.FontName = "Arial";
            tick3.Font = chartFont8;
            chartRace.ZAxes.Ticks = tick3;
            // 
            // datasetRace
            // 
            datasetRace.Label = "Rank Marathon";
            datasetRace.TargetChart = chartRace;
            // 
            // RankParticipant
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 430);
            Controls.Add(chartRace);
            Name = "RankParticipant";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RankParticipant";
            ResumeLayout(false);
        }

        #endregion

        private Guna.Charts.WinForms.GunaChart chartRace;
        private Guna.Charts.WinForms.GunaHorizontalBarDataset datasetRace;
    }
}