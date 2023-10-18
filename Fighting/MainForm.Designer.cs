namespace Fighting
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            HealthFirst = new Controls.CustomBar();
            HealthSecond = new Controls.CustomBar();
            SuspendLayout();
            // 
            // HealthFirst
            // 
            HealthFirst.BackColor = Color.Transparent;
            HealthFirst.BackColorBright = Color.FromArgb(184, 184, 184);
            HealthFirst.BackColorDark = Color.FromArgb(100, 100, 100);
            HealthFirst.FrontColorBright = Color.FromArgb(37, 249, 37);
            HealthFirst.FrontColorDark = Color.FromArgb(27, 179, 27);
            HealthFirst.Location = new Point(12, 20);
            HealthFirst.Name = "HealthFirst";
            HealthFirst.Reverse = false;
            HealthFirst.Size = new Size(400, 20);
            HealthFirst.TabIndex = 50;
            HealthFirst.Value = 100F;
            // 
            // HealthSecond
            // 
            HealthSecond.BackColor = Color.Transparent;
            HealthSecond.BackColorBright = Color.FromArgb(184, 184, 184);
            HealthSecond.BackColorDark = Color.FromArgb(100, 100, 100);
            HealthSecond.FrontColorBright = Color.FromArgb(37, 249, 37);
            HealthSecond.FrontColorDark = Color.FromArgb(27, 179, 27);
            HealthSecond.Location = new Point(518, 20);
            HealthSecond.Name = "HealthSecond";
            HealthSecond.Reverse = true;
            HealthSecond.Size = new Size(400, 20);
            HealthSecond.TabIndex = 1;
            HealthSecond.Value = 100F;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.Background;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(930, 540);
            Controls.Add(HealthFirst);
            Controls.Add(HealthSecond);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
        }

        private Controls.CustomBar HealthFirst;
        private Controls.CustomBar HealthSecond;

        #endregion
    }
}