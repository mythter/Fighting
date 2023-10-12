using Fighting.Controls;
using Fighting.Models;
using Fighting.Properties;

namespace Fighting
{
    public partial class Form1 : Form
    {
        CharacterControl FirstCharacter;
        CharacterControl SecondCharacter;

        public Form1()
        {
            InitializeComponent();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            #region First character
            Character first = new Character
            {
                Name = "Ken",
                Head = Properties.Resources.Ken_left_1,
                Body = Properties.Resources.Ken_left_2,
                Legs = Properties.Resources.Ken_left_3,
            };
            FirstCharacter = new CharacterControl(first);

            FirstCharacter.BackColor = SystemColors.Control;
            FirstCharacter.Location = new Point(106, 119);
            FirstCharacter.Name = "FirstCharacter";
            FirstCharacter.Size = new Size(246, 338);
            FirstCharacter.TabIndex = 0;

            FirstCharacter.CharacterMouseEnter += (s, e) => { ((PictureBox)s!).BackColor = Color.FromArgb(80, 39, 245, 75); };
            FirstCharacter.CharacterMouseClick += (s, e) => { SwitchShield(s, e); };

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
            SecondCharacter = new CharacterControl(second);

            SecondCharacter.BackColor = SystemColors.Control;
            SecondCharacter.Location = new Point(588, 119);
            SecondCharacter.Name = "SecondCharacter";
            SecondCharacter.Size = new Size(220, 338);
            SecondCharacter.TabIndex = 1;

            Controls.Add(SecondCharacter);

            SecondCharacter.CharacterMouseEnter += (s, e) => { ((PictureBox)s!).BackColor = Color.FromArgb(80, 245, 39, 42); };
            SecondCharacter.CharacterMouseClick += async (s, e) => { await MakeDamage(s); };

            #endregion

            SetTransperency();
        }

        private async Task MakeDamage(object? sender)
        {
            SecondCharacter.SetDamage((PictureBox)sender!);
            await SecondCharacter.AnimateDamage();
            await Task.Delay(500);
            PictureBox picBox = new Random().Next(3) switch
            {
                0 => FirstCharacter.HeadPictureBox,
                1 => FirstCharacter.BodyPictureBox,
                2 => FirstCharacter.LegsPictureBox,
                _ => throw new ArgumentException(""),
            };
            FirstCharacter.SetDamage(picBox);
            await FirstCharacter.AnimateDamage();
        }

        private void SwitchShield(object? sender, EventArgs e)
        {
            PictureBox shield;
            PictureBox picBox = (PictureBox)sender!;
            CharacterControl character = (CharacterControl)picBox.Parent!;


            shield = GetShieldPicBox(picBox);

            if (shield.Image is not null)
            {
                shield.Image = null;
            }
            else
            {
                ClearShields(character);
                shield.Image = Properties.Resources.board_left;
            }
        }

        private void ClearShields(CharacterControl character)
        {
            character.ShieldPicBox1.Image = null;
            character.ShieldPicBox2.Image = null;
            character.ShieldPicBox3.Image = null;
        }

        private PictureBox GetShieldPicBox(PictureBox picBox)
        {
            CharacterControl character = (CharacterControl)picBox.Parent!;
            return picBox.Tag!.ToString() switch
            {
                "1" => character.ShieldPicBox1,
                "2" => character.ShieldPicBox2,
                "3" => character.ShieldPicBox3,
                _ => throw new ArgumentException(""),
            };
        }
    }
}