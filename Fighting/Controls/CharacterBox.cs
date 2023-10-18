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
                Art = character.Image;
                CharacterName = character.Name;
            }
        }

        public Image? Art
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
