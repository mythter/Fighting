using Fighting.Controls;
using Fighting.Enums;
using Fighting.Models;
using Type = Fighting.Enums.Type;

namespace Fighting
{
    public partial class Form1 : Form
    {
        CharacterControl FirstCharacter;
        CharacterControl SecondCharacter;

        public Form1()
        {
            InitializeComponent();

            #region First character
            Character first = new Character
            {
                Name = "Ken",
                Head = Properties.Resources.Ken_left_1,
                Body = Properties.Resources.Ken_left_2,
                Legs = Properties.Resources.Ken_left_3,
            };
            FirstCharacter = new CharacterControl(first)
            {
                BackColor = SystemColors.Control,
                Location = new Point(80, 135),
                Name = "FirstCharacter",
                Size = new Size(281, 338),
                TabIndex = 0,
                Side = Side.Left,
                Type = Type.Hero,
            };

            Controls.Add(FirstCharacter);
            #endregion

            #region Second character
            Character second = new Character
            {
                Name = "Ryu",
                Head = Properties.Resources.Ryu_right_1,
                Body = Properties.Resources.Ryu_right_2,
                Legs = Properties.Resources.Ryu_right_3,
            };
            SecondCharacter = new CharacterControl(second)
            {
                BackColor = SystemColors.Control,
                Location = new Point(580, 135),
                Name = "SecondCharacter",
                Size = new Size(246, 338),
                TabIndex = 1,
                Side = Side.Right,
                Type = Type.Enemy,
            };

            SecondCharacter.CharacterMouseClick += async (s, e) =>
            {
                Random rand = new Random();
                PictureBox picBox = rand.Next(3) switch
                {
                    0 => FirstCharacter.HeadPictureBox,
                    1 => FirstCharacter.BodyPictureBox,
                    2 => FirstCharacter.LegsPictureBox,
                    _ => throw new ArgumentException(""),
                };
                await FirstCharacter.GetDamage(picBox);
            };

            Controls.Add(SecondCharacter);

            #endregion

            SetTransperency();
        }

        private void SetTransperency()
        {
            Point pos;

            if (FirstCharacter?.Parent is not null)
            {
                pos = FirstCharacter.Parent.PointToScreen(FirstCharacter.Location);
                pos = this.PointToClient(pos);
                FirstCharacter.Parent = this;
                FirstCharacter.Location = pos;
                FirstCharacter.BackColor = Color.Transparent;
            }
            if (SecondCharacter?.Parent is not null)
            {
                pos = SecondCharacter.Parent.PointToScreen(SecondCharacter.Location);
                pos = this.PointToClient(pos);
                SecondCharacter.Parent = this;
                SecondCharacter.Location = pos;
                SecondCharacter.BackColor = Color.Transparent;
            }
        }
    }
}