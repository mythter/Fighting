namespace Fighting.Controls
{
    partial class CharacterControl
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
            HeadPictureBox = new PictureBox();
            BodyPictureBox = new PictureBox();
            LegsPictureBox = new PictureBox();
            ShieldRightPicBox1 = new PictureBox();
            ShieldRightPicBox2 = new PictureBox();
            ShieldRightPicBox3 = new PictureBox();
            ShieldLeftPicBox3 = new PictureBox();
            ShieldLeftPicBox2 = new PictureBox();
            ShieldLeftPicBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)HeadPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BodyPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LegsPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShieldRightPicBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShieldRightPicBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShieldRightPicBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShieldLeftPicBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShieldLeftPicBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShieldLeftPicBox1).BeginInit();
            SuspendLayout();
            // 
            // HeadPictureBox
            // 
            HeadPictureBox.Location = new Point(35, 0);
            HeadPictureBox.Name = "HeadPictureBox";
            HeadPictureBox.Size = new Size(220, 105);
            HeadPictureBox.TabIndex = 0;
            HeadPictureBox.TabStop = false;
            HeadPictureBox.Tag = "0";
            HeadPictureBox.Click += PictureBox_Click;
            HeadPictureBox.MouseEnter += PictureBox_MouseEnter;
            HeadPictureBox.MouseLeave += PictureBox_MouseLeave;
            // 
            // BodyPictureBox
            // 
            BodyPictureBox.Location = new Point(35, 105);
            BodyPictureBox.Name = "BodyPictureBox";
            BodyPictureBox.Size = new Size(220, 105);
            BodyPictureBox.TabIndex = 1;
            BodyPictureBox.TabStop = false;
            BodyPictureBox.Tag = "1";
            BodyPictureBox.Click += PictureBox_Click;
            BodyPictureBox.MouseEnter += PictureBox_MouseEnter;
            BodyPictureBox.MouseLeave += PictureBox_MouseLeave;
            // 
            // LegsPictureBox
            // 
            LegsPictureBox.Location = new Point(35, 210);
            LegsPictureBox.Name = "LegsPictureBox";
            LegsPictureBox.Size = new Size(220, 105);
            LegsPictureBox.TabIndex = 2;
            LegsPictureBox.TabStop = false;
            LegsPictureBox.Tag = "2";
            LegsPictureBox.Click += PictureBox_Click;
            LegsPictureBox.MouseEnter += PictureBox_MouseEnter;
            LegsPictureBox.MouseLeave += PictureBox_MouseLeave;
            // 
            // ShieldRightPicBox1
            // 
            ShieldRightPicBox1.Location = new Point(255, 0);
            ShieldRightPicBox1.Name = "ShieldRightPicBox1";
            ShieldRightPicBox1.Size = new Size(35, 105);
            ShieldRightPicBox1.TabIndex = 3;
            ShieldRightPicBox1.TabStop = false;
            ShieldRightPicBox1.Tag = "";
            // 
            // ShieldRightPicBox2
            // 
            ShieldRightPicBox2.Location = new Point(255, 105);
            ShieldRightPicBox2.Name = "ShieldRightPicBox2";
            ShieldRightPicBox2.Size = new Size(35, 105);
            ShieldRightPicBox2.TabIndex = 4;
            ShieldRightPicBox2.TabStop = false;
            ShieldRightPicBox2.Tag = "";
            // 
            // ShieldRightPicBox3
            // 
            ShieldRightPicBox3.Location = new Point(255, 210);
            ShieldRightPicBox3.Name = "ShieldRightPicBox3";
            ShieldRightPicBox3.Size = new Size(35, 105);
            ShieldRightPicBox3.TabIndex = 5;
            ShieldRightPicBox3.TabStop = false;
            ShieldRightPicBox3.Tag = "";
            // 
            // ShieldLeftPicBox3
            // 
            ShieldLeftPicBox3.Location = new Point(0, 210);
            ShieldLeftPicBox3.Name = "ShieldLeftPicBox3";
            ShieldLeftPicBox3.Size = new Size(35, 105);
            ShieldLeftPicBox3.TabIndex = 8;
            ShieldLeftPicBox3.TabStop = false;
            ShieldLeftPicBox3.Tag = "";
            // 
            // ShieldLeftPicBox2
            // 
            ShieldLeftPicBox2.Location = new Point(0, 105);
            ShieldLeftPicBox2.Name = "ShieldLeftPicBox2";
            ShieldLeftPicBox2.Size = new Size(35, 105);
            ShieldLeftPicBox2.TabIndex = 7;
            ShieldLeftPicBox2.TabStop = false;
            ShieldLeftPicBox2.Tag = "";
            // 
            // ShieldLeftPicBox1
            // 
            ShieldLeftPicBox1.Location = new Point(0, 0);
            ShieldLeftPicBox1.Name = "ShieldLeftPicBox1";
            ShieldLeftPicBox1.Size = new Size(35, 105);
            ShieldLeftPicBox1.TabIndex = 6;
            ShieldLeftPicBox1.TabStop = false;
            ShieldLeftPicBox1.Tag = "";
            // 
            // CharacterControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(ShieldLeftPicBox3);
            Controls.Add(ShieldLeftPicBox2);
            Controls.Add(ShieldLeftPicBox1);
            Controls.Add(ShieldRightPicBox3);
            Controls.Add(ShieldRightPicBox2);
            Controls.Add(ShieldRightPicBox1);
            Controls.Add(LegsPictureBox);
            Controls.Add(BodyPictureBox);
            Controls.Add(HeadPictureBox);
            Name = "CharacterControl";
            Size = new Size(290, 315);
            ((System.ComponentModel.ISupportInitialize)HeadPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)BodyPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)LegsPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShieldRightPicBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShieldRightPicBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShieldRightPicBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShieldLeftPicBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShieldLeftPicBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShieldLeftPicBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        public PictureBox HeadPictureBox;
        public PictureBox BodyPictureBox;
        public PictureBox LegsPictureBox;
        public PictureBox ShieldRightPicBox1;
        public PictureBox ShieldRightPicBox2;
        public PictureBox ShieldRightPicBox3;
        public PictureBox ShieldLeftPicBox3;
        public PictureBox ShieldLeftPicBox2;
        public PictureBox ShieldLeftPicBox1;
    }
}
