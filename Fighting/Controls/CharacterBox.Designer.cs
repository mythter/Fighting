namespace Fighting.Controls
{
    partial class CharacterBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CharacterNameLabel = new Label();
            CharacterPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CharacterPictureBox).BeginInit();
            SuspendLayout();
            // 
            // CharacterNameLabel
            // 
            CharacterNameLabel.AutoSize = true;
            CharacterNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CharacterNameLabel.Location = new Point(70, 185);
            CharacterNameLabel.Name = "CharacterNameLabel";
            CharacterNameLabel.Size = new Size(68, 28);
            CharacterNameLabel.TabIndex = 0;
            CharacterNameLabel.Text = "Name";
            CharacterNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CharacterPictureBox
            // 
            CharacterPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            CharacterPictureBox.Location = new Point(0, 0);
            CharacterPictureBox.Name = "CharacterPictureBox";
            CharacterPictureBox.Size = new Size(210, 182);
            CharacterPictureBox.TabIndex = 1;
            CharacterPictureBox.TabStop = false;
            // 
            // CharacterBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(CharacterPictureBox);
            Controls.Add(CharacterNameLabel);
            Name = "CharacterBox";
            Size = new Size(210, 215);
            ((System.ComponentModel.ISupportInitialize)CharacterPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CharacterNameLabel;
        private PictureBox CharacterPictureBox;
    }
}
