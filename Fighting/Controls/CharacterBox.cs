using Fighting.Models;

namespace Fighting.Controls
{
    public partial class CharacterBox : UserControl
    {
        Character character = new Character();
        public CharacterBox(Character? character)
        {
            InitializeComponent();

            if (character is not null)
            {
                this.character = character;
                Art = character.Image;
                Name = character.Name;
            }
        }

        public Image? Art
        {
            set => CharacterPictureBox.Image = value;
        }

        public string? Name
        {
            set => CharacterNameLabel.Text = value;
        }

        public Character ChooseCharacter(object sender, EventArgs e)
        {
            return character;
        }
    }
}
