namespace Dekatop_II_04.Forms
{
    partial class MainForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            comboEvent = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnSimulation = new Guna.UI2.WinForms.Guna2Button();
            btnPartipants = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(164, 44);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(378, 34);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Marathon Simulation Event 2025";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(99, 109);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(172, 23);
            guna2HtmlLabel2.TabIndex = 1;
            guna2HtmlLabel2.Text = "Please select the events :";
            // 
            // comboEvent
            // 
            comboEvent.BackColor = Color.Transparent;
            comboEvent.CustomizableEdges = customizableEdges1;
            comboEvent.DrawMode = DrawMode.OwnerDrawFixed;
            comboEvent.DropDownStyle = ComboBoxStyle.DropDownList;
            comboEvent.FocusedColor = Color.FromArgb(94, 148, 255);
            comboEvent.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            comboEvent.Font = new Font("Segoe UI", 10F);
            comboEvent.ForeColor = Color.FromArgb(68, 88, 112);
            comboEvent.ItemHeight = 30;
            comboEvent.Location = new Point(296, 103);
            comboEvent.Name = "comboEvent";
            comboEvent.ShadowDecoration.CustomizableEdges = customizableEdges2;
            comboEvent.Size = new Size(283, 36);
            comboEvent.TabIndex = 2;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = SystemColors.ControlLight;
            guna2Panel1.Controls.Add(btnSimulation);
            guna2Panel1.Controls.Add(btnPartipants);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.Dock = DockStyle.Bottom;
            guna2Panel1.Location = new Point(0, 174);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(689, 49);
            guna2Panel1.TabIndex = 3;
            // 
            // btnSimulation
            // 
            btnSimulation.CustomizableEdges = customizableEdges3;
            btnSimulation.DisabledState.BorderColor = Color.DarkGray;
            btnSimulation.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSimulation.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSimulation.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSimulation.FillColor = Color.White;
            btnSimulation.Font = new Font("Segoe UI", 9F);
            btnSimulation.ForeColor = Color.Black;
            btnSimulation.Location = new Point(362, 8);
            btnSimulation.Name = "btnSimulation";
            btnSimulation.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSimulation.Size = new Size(180, 29);
            btnSimulation.TabIndex = 1;
            btnSimulation.Text = "Simulation";
            // 
            // btnPartipants
            // 
            btnPartipants.CustomizableEdges = customizableEdges5;
            btnPartipants.DisabledState.BorderColor = Color.DarkGray;
            btnPartipants.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPartipants.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPartipants.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPartipants.FillColor = Color.White;
            btnPartipants.Font = new Font("Segoe UI", 9F);
            btnPartipants.ForeColor = Color.Black;
            btnPartipants.Location = new Point(113, 8);
            btnPartipants.Name = "btnPartipants";
            btnPartipants.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnPartipants.Size = new Size(180, 29);
            btnPartipants.TabIndex = 0;
            btnPartipants.Text = "Participants List";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 223);
            Controls.Add(guna2Panel1);
            Controls.Add(comboEvent);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marathon Simulation || Login";
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ComboBox comboEvent;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnPartipants;
        private Guna.UI2.WinForms.Guna2Button btnSimulation;
    }
}