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
            ShieldPicBox1 = new PictureBox();
            ShieldPicBox2 = new PictureBox();
            ShieldPicBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)HeadPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BodyPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LegsPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShieldPicBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShieldPicBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShieldPicBox3).BeginInit();
            SuspendLayout();
            // 
            // HeadPictureBox
            // 
            HeadPictureBox.Location = new Point(0, 0);
            HeadPictureBox.Name = "HeadPictureBox";
            HeadPictureBox.Size = new Size(212, 105);
            HeadPictureBox.TabIndex = 0;
            HeadPictureBox.TabStop = false;
            HeadPictureBox.Tag = "1";
            HeadPictureBox.Click += PictureBox_Click;
            HeadPictureBox.MouseDown += PictureBox_MouseDown;
            HeadPictureBox.MouseEnter += PictureBox_MouseEnter;
            HeadPictureBox.MouseLeave += PictureBox_MouseLeave;
            // 
            // BodyPictureBox
            // 
            BodyPictureBox.Location = new Point(0, 105);
            BodyPictureBox.Name = "BodyPictureBox";
            BodyPictureBox.Size = new Size(212, 105);
            BodyPictureBox.TabIndex = 1;
            BodyPictureBox.TabStop = false;
            BodyPictureBox.Tag = "2";
            BodyPictureBox.Click += PictureBox_Click;
            BodyPictureBox.MouseDown += PictureBox_MouseDown;
            BodyPictureBox.MouseEnter += PictureBox_MouseEnter;
            BodyPictureBox.MouseLeave += PictureBox_MouseLeave;
            // 
            // LegsPictureBox
            // 
            LegsPictureBox.Location = new Point(0, 210);
            LegsPictureBox.Name = "LegsPictureBox";
            LegsPictureBox.Size = new Size(212, 105);
            LegsPictureBox.TabIndex = 2;
            LegsPictureBox.TabStop = false;
            LegsPictureBox.Tag = "3";
            LegsPictureBox.Click += PictureBox_Click;
            LegsPictureBox.MouseDown += PictureBox_MouseDown;
            LegsPictureBox.MouseEnter += PictureBox_MouseEnter;
            LegsPictureBox.MouseLeave += PictureBox_MouseLeave;
            // 
            // ShieldPicBox1
            // 
            ShieldPicBox1.Location = new Point(211, 0);
            ShieldPicBox1.Name = "ShieldPicBox1";
            ShieldPicBox1.Size = new Size(35, 105);
            ShieldPicBox1.TabIndex = 3;
            ShieldPicBox1.TabStop = false;
            // 
            // ShieldPicBox2
            // 
            ShieldPicBox2.Location = new Point(211, 105);
            ShieldPicBox2.Name = "ShieldPicBox2";
            ShieldPicBox2.Size = new Size(35, 105);
            ShieldPicBox2.TabIndex = 4;
            ShieldPicBox2.TabStop = false;
            // 
            // ShieldPicBox3
            // 
            ShieldPicBox3.Location = new Point(211, 210);
            ShieldPicBox3.Name = "ShieldPicBox3";
            ShieldPicBox3.Size = new Size(35, 105);
            ShieldPicBox3.TabIndex = 5;
            ShieldPicBox3.TabStop = false;
            // 
            // CharacterControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(ShieldPicBox3);
            Controls.Add(ShieldPicBox2);
            Controls.Add(ShieldPicBox1);
            Controls.Add(LegsPictureBox);
            Controls.Add(BodyPictureBox);
            Controls.Add(HeadPictureBox);
            Name = "CharacterControl";
            Size = new Size(246, 315);
            ((System.ComponentModel.ISupportInitialize)HeadPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)BodyPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)LegsPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShieldPicBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShieldPicBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShieldPicBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        public PictureBox HeadPictureBox;
        public PictureBox BodyPictureBox;
        public PictureBox LegsPictureBox;
        public PictureBox ShieldPicBox1;
        public PictureBox ShieldPicBox2;
        public PictureBox ShieldPicBox3;
    }
}
