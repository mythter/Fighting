using Fighting.Models;

namespace Fighting.Controls
{
    public partial class CharacterBox : UserControl
    {
        public CharacterBox(Character character)
        {
            InitializeComponent();
            WireAllControls(this);

            ArgumentNullException.ThrowIfNull(character);

            Character = character;
            CharacterImage = character.Image;
            CharacterName = character.Name;
        }

        public Image? CharacterImage
        {
            get => CharacterPictureBox.BackgroundImage;
            set => CharacterPictureBox.BackgroundImage = value;
        }

        public string? CharacterName
        {
            get => CharacterNameLabel.Text;
            set => CharacterNameLabel.Text = value;
        }

        public Character Character { get; set; }

        private void WireAllControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                c.Click += Control_Click;
                if (c.HasChildren)
                {
                    WireAllControls(c);
                }
            }
        }

        private void Control_Click(object? sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);
        }
    }
}
