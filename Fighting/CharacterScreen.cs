using Fighting.Controls;
using Fighting.Models;

namespace Fighting
{
    public partial class CharacterScreen : Form
    {
        CharacterBox KenBox;
        CharacterBox RyuBox;

        public CharacterScreen()
        {
            InitializeComponent();
            Character first = new Character
            {
                Name = "Ken",
                Head = Properties.Resources.Ken_left_1,
                Body = Properties.Resources.Ken_left_2,
                Legs = Properties.Resources.Ken_left_3,
            };
            KenBox = new CharacterBox(first);
            Controls.Add(KenBox);

            Character second = new Character
            {
                Name = "Ryu",
                Head = Properties.Resources.Ryu_right_1,
                Body = Properties.Resources.Ryu_right_2,
                Legs = Properties.Resources.Ryu_right_3,
            };
            RyuBox = new CharacterBox(second);
            Controls.Add(RyuBox);

        }
    }
}
