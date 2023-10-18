namespace Fighting
{
    partial class CharacterScreen
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
            SuspendLayout();
            // 
            // characterBox1
            // 
            characterBox1.Location = new Point(90, 12);
            characterBox1.Name = "characterBox1";
            characterBox1.Size = new Size(262, 269);
            characterBox1.TabIndex = 0;
            // 
            // CharacterScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(characterBox1);
            Name = "CharacterScreen";
            Text = "CharacterScreen";
            ResumeLayout(false);
        }

        #endregion

        private Controls.CharacterBox characterBox1;
    }
}