using Fighting.Controls;
using Fighting.Enums;
using Fighting.Helpers;
using Fighting.Models;
using System.Drawing.Text;
using Type = Fighting.Enums.Type;

namespace Fighting
{
    public partial class MainForm : Form
    {
        #region Custom font
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font CustomFont;
        Font DamageValueFont;
        #endregion

        CharacterControl FirstCharacter;
        CharacterControl SecondCharacter;
        Label FirstDamageValueLabel;
        Label SecondDamageValueLabel;

        public MainForm()
        {
            #region Custom font
            byte[] fontData = Properties.Resources.CityBrawlersBoldCaps;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.CityBrawlersBoldCaps.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.CityBrawlersBoldCaps.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            CustomFont = new Font(fonts.Families[0], 70.0F);
            DamageValueFont = new Font(fonts.Families[0], 28.0F);
            #endregion

            InitializeComponent();
            DoubleBuffered = true;

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

            #region Damage labels
            FirstDamageValueLabel = new Label()
            {
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Red,
                BackColor = Color.Transparent,
                Font = DamageValueFont,
                AutoSize = true,
                Visible = false,
            };
            Controls.Add(FirstDamageValueLabel);

            SecondDamageValueLabel = new Label()
            {
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Red,
                BackColor = Color.Transparent,
                Font = DamageValueFont,
                AutoSize = true,
                Visible = false,
            };
            Controls.Add(SecondDamageValueLabel);
            #endregion

            SetTransperency();
        }

        private async void SetHealthValue(object? sender, HealthChangedEventArgs e)
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
            await AnimateDamageValue(character, e.Value);
        }

        private async Task AnimateDamageValue(CharacterControl character, float value)
        {
            Label label;
            string damageStr = value.ToString("+0.##;-0.##");

            if (character.Side == Side.Left)
            {
                label = FirstDamageValueLabel;
                label.Text = damageStr;
                label.Location = new Point(character.Width + 70, 120);
            }
            else
            {
                label = SecondDamageValueLabel;
                label.Text = damageStr;
                label.Location = new Point(ClientSize.Width - character.Width - 50 - label.Width, 120);
            }
            label.BringToFront();

            label.Visible = true;
            await AnimateLabel(label);
            label.Visible = false;
        }

        private async Task AnimateLabel(Label label)
        {
            for (int i = 0; i < 50; i++)
            {
                label.Location = new Point(label.Location.X, label.Location.Y - 1);
                await Task.Delay(10);
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
            if (FirstCharacter.IsAnimating)
                return;

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

        private async void CharacterKilled(object? sender, EventArgs e)
        {
            ShowFinalLabel();
            await Task.Delay(1500);

            Application.Restart();
            Environment.Exit(0);
        }

        private void ShowFinalLabel()
        {
            var label = new Label
            {
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Dock = DockStyle.Fill,
                ForeColor = Color.LightGray,
                BackColor = Color.Black,
                Font = CustomFont,
            };
            Controls.Add(label);
            label.BringToFront();

            if (FirstCharacter.Health == 0)
            {
                label.Text = "YOU LOOSE";
            }
            else
            {
                label.Text = "YOU WIN";
            }
        }
    }
}