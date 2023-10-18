using Fighting.Controls;
using Fighting.Enums;
using Fighting.Helpers;
using Fighting.Models;
using Type = Fighting.Enums.Type;

namespace Fighting
{
    public partial class MainForm : Form
    {
        CharacterControl FirstCharacter;
        CharacterControl SecondCharacter;

        public MainForm()
        {
            InitializeComponent();

            CharactersForm charactersForm = new CharactersForm();
            charactersForm.ShowDialog();

            #region First character

            Character first = charactersForm.ChosenCharacter ?? CharacterGenerator.GenerateRandomCharacter(Side.Left);

            FirstCharacter = new CharacterControl(first)
            {
                BackColor = SystemColors.Control,
                Location = new Point(60, 135),
                Name = "FirstCharacter",
                Size = new Size(first.Head!.Width + 70, 338),
                TabIndex = 0,
                Side = Side.Left,
                Type = Type.Hero,
            };

            FirstCharacter.HealthChangedEvent += SetHealthValue;
            FirstCharacter.GotKilledEvent += CharacterKilled;

            Controls.Add(FirstCharacter);
            #endregion

            #region Second character

            Character second = CharacterGenerator.GenerateRandomCharacterExcept(first.Name, Side.Right);
            SecondCharacter = new CharacterControl(second)
            {
                BackColor = SystemColors.Control,
                Location = new Point(580, 135),
                Name = "SecondCharacter",
                Size = new Size(second.Head!.Width + 70, 338),
                TabIndex = 1,
                Side = Side.Right,
                Type = Type.Enemy,
            };

            SecondCharacter.GotDamagedEvent += SecondCharacter_Click;
            SecondCharacter.HealthChangedEvent += SetHealthValue;
            SecondCharacter.GotKilledEvent += CharacterKilled;

            Controls.Add(SecondCharacter);

            #endregion

            SetTransperency();
        }

        private void SetHealthValue(object? sender, EventArgs e)
        {
            CharacterControl character = (CharacterControl)sender!;
            if (character.Side == Side.Left)
            {
                HealthFirst.Value = character.Health;
            }
            else
            {
                HealthSecond.Value = character.Health;
            }
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
            if (HealthFirst?.Parent is not null)
            {
                pos = HealthFirst.Parent.PointToScreen(HealthFirst.Location);
                pos = this.PointToClient(pos);
                HealthFirst.Parent = this;
                HealthFirst.Location = pos;
                HealthFirst.BackColor = Color.Transparent;
            }
            if (HealthSecond.Parent is not null)
            {
                pos = HealthSecond.Parent.PointToScreen(HealthSecond.Location);
                pos = this.PointToClient(pos);
                HealthSecond.Parent = this;
                HealthSecond.Location = pos;
                HealthSecond.BackColor = Color.Transparent;
            }
        }

        private async void SecondCharacter_Click(object? sender, EventArgs e)
        {
            if (SecondCharacter.Health > 0)
            {
                Random rand = new Random();
                PictureBox picBox = rand.Next(3) switch
                {
                    0 => FirstCharacter.HeadPictureBox,
                    1 => FirstCharacter.BodyPictureBox,
                    2 => FirstCharacter.LegsPictureBox,
                    _ => throw new ArgumentException("Part number does not exist."),
                };
                await FirstCharacter.MakeDamage(picBox);
            }
        }

        private void CharacterKilled(object? sender, EventArgs e)
        {
            //FirstCharacter.Health = 100;
            //SecondCharacter.Health = 100;
            Application.Restart();
            Environment.Exit(0);
        }
    }
}