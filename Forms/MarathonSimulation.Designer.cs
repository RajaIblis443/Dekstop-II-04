namespace Dekatop_II_04.Forms
{
    partial class MarathonSimulation
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
            btnStart = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.CustomizableEdges = customizableEdges1;
            btnStart.DisabledState.BorderColor = Color.DarkGray;
            btnStart.DisabledState.CustomBorderColor = Color.DarkGray;
            btnStart.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnStart.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnStart.Font = new Font("Segoe UI", 9F);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(1, 361);
            btnStart.Name = "btnStart";
            btnStart.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnStart.Size = new Size(723, 36);
            btnStart.TabIndex = 0;
            btnStart.Text = "guna2Button1";
            // 
            // MarathonSimulation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 395);
            Controls.Add(btnStart);
            Name = "MarathonSimulation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MarathonSimulation";
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnStart;
    }
}