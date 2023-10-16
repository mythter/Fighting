namespace Fighting.Controls
{
    partial class CustomBar
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
            TableLayoutPanel = new TableLayoutPanel();
            BackPanel = new Panel();
            FrontPanel = new Panel();
            BackgroundPanel = new Panel();
            TableLayoutPanel.SuspendLayout();
            BackgroundPanel.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            TableLayoutPanel.BackColor = Color.Transparent;
            TableLayoutPanel.ColumnCount = 2;
            TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TableLayoutPanel.Controls.Add(BackPanel, 1, 0);
            TableLayoutPanel.Controls.Add(FrontPanel, 0, 0);
            TableLayoutPanel.Dock = DockStyle.Fill;
            TableLayoutPanel.Location = new Point(0, 0);
            TableLayoutPanel.Margin = new Padding(0);
            TableLayoutPanel.Name = "TableLayoutPanel";
            TableLayoutPanel.RowCount = 1;
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanel.Size = new Size(400, 20);
            TableLayoutPanel.TabIndex = 0;
            // 
            // BackPanel
            // 
            BackPanel.Dock = DockStyle.Fill;
            BackPanel.Location = new Point(200, 0);
            BackPanel.Margin = new Padding(0);
            BackPanel.Name = "BackPanel";
            BackPanel.Size = new Size(200, 20);
            BackPanel.TabIndex = 1;
            BackPanel.Paint += BackPanel_Paint;
            // 
            // FrontPanel
            // 
            FrontPanel.Dock = DockStyle.Fill;
            FrontPanel.Location = new Point(0, 0);
            FrontPanel.Margin = new Padding(0);
            FrontPanel.Name = "FrontPanel";
            FrontPanel.Size = new Size(200, 20);
            FrontPanel.TabIndex = 0;
            FrontPanel.Paint += FrontPanel_Paint;
            // 
            // BackgroundPanel
            // 
            BackgroundPanel.Controls.Add(TableLayoutPanel);
            BackgroundPanel.Dock = DockStyle.Fill;
            BackgroundPanel.Location = new Point(0, 0);
            BackgroundPanel.Margin = new Padding(0);
            BackgroundPanel.Name = "BackgroundPanel";
            BackgroundPanel.Size = new Size(400, 20);
            BackgroundPanel.TabIndex = 1;
            BackgroundPanel.Paint += BackgroundPanel_Paint;
            // 
            // CustomBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(BackgroundPanel);
            Name = "CustomBar";
            Size = new Size(400, 20);
            TableLayoutPanel.ResumeLayout(false);
            BackgroundPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TableLayoutPanel;
        private Panel BackgroundPanel;
        private Panel FrontPanel;
        private Panel BackPanel;
    }
}
