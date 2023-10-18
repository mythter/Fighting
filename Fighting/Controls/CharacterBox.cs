using Fighting.Models;

namespace Fighting.Controls
{
    public partial class CharacterBox : UserControl
    {
        Character? character;
        public CharacterBox(Character? character)
        {
            InitializeComponent();

            if (character is not null)
            {
                this.character = character;
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

        public Character? ChooseCharacter(object sender, EventArgs e)
        {
            return character;
        }
    }
}
