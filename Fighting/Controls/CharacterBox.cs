using Fighting.Models;

namespace Fighting.Controls
{
    public partial class CharacterBox : UserControl
    {
        public CharacterBox(Character? character)
        {
            InitializeComponent();

            if (character is not null)
            {
                Character = character;
                CharacterImage = character.Image;
                CharacterName = character.Name;
            }
        }

        public Image? CharacterImage
        {
            get => CharacterPictureBox.Image;
            set => CharacterPictureBox.Image = value;
        }

        public string? CharacterName
        {
            get => CharacterNameLabel.Text;
            set => CharacterNameLabel.Text = value;
        }

        public Character? Character { get; set; }
    }
}
