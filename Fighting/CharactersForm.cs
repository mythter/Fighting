using Fighting.Controls;
using Fighting.Enums;
using Fighting.Helpers;
using Fighting.Models;

namespace Fighting
{
    public partial class CharactersForm : Form
    {
        public Character? ChosenCharacter { get; private set; }

        public CharactersForm()
        {
            InitializeComponent();

            int count = CharacterGenerator.Count;

            // Form initialization
            Width = 210 * count / 2 + 18;
            Height = 215 * count / (count / 2) + 47;
            Text = "Choose character";
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;

            Character[] characters = CharacterGenerator.GenerateCharacters(Side.Left);

            for (int i = 0; i < count; i++)
            {
                CharacterBox characterBox = new CharacterBox(characters[i])
                {
                    Location = new Point((i % (count / 2)) * 210, (i / (count / 2)) * 215),
                    Name = $"{characters[i].Name}Box",
                    Size = new Size(210, 215),
                    TabIndex = 0,
                    CausesValidation = false,
                };
                characterBox.Click += CharacterChosen;
                Controls.Add(characterBox);
            }
        }

        private void CharacterChosen(object? sender, EventArgs e)
        {
            ChosenCharacter = ((CharacterBox)sender!).Character;
            this.Close();
        }

    }
}
