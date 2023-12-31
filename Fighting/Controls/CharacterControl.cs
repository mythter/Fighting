﻿using Fighting.Enums;
using Fighting.Models;
using Type = Fighting.Enums.Type;

namespace Fighting.Controls
{
    public delegate void HealthChangedHandler(object sender, HealthChangedEventArgs e);
    public partial class CharacterControl : UserControl
    {
        private readonly Color _damageColor = Color.Red;
        private readonly Color _defenseColor = Color.Green;
        private readonly Color _heroEnterColor = Color.FromArgb(80, 39, 245, 75);
        private readonly Color _enemyEnterColor = Color.FromArgb(80, 245, 39, 42);

        public CharacterControl(Character? character)
        {
            InitializeComponent();
            SetTransperency();

            if (character is not null)
            {
                Head = character.Head;
                Body = character.Body;
                Legs = character.Legs;
                Type = character.Type;
            }
        }

        public Image? Head
        {
            get => HeadPictureBox.Image;
            set
            {
                if (value is not null)
                {
                    HeadPictureBox.Width = value.Width;
                    ShieldRightPicBox1.Location = new Point(35 + HeadPictureBox.Width, ShieldRightPicBox1.Location.Y);
                }
                HeadPictureBox.Image = value;
            }
        }
        public Image? Body
        {
            get => BodyPictureBox.Image;
            set
            {
                if (value is not null)
                {
                    BodyPictureBox.Width = value.Width;
                    ShieldRightPicBox2.Location = new Point(35 + BodyPictureBox.Width, ShieldRightPicBox2.Location.Y);
                }
                BodyPictureBox.Image = value;
            }
        }
        public Image? Legs
        {
            get => LegsPictureBox.Image;
            set
            {
                if (value is not null)
                {
                    LegsPictureBox.Width = value.Width;
                    ShieldRightPicBox3.Location = new Point(35 + LegsPictureBox.Width, ShieldRightPicBox3.Location.Y);
                }
                LegsPictureBox.Image = value;
            }
        }

        private Side _side;
        public Side Side
        {
            get => _side;
            set
            {
                _side = value;
                if (_side == Side.Left)
                {
                    ShieldLeftPicBox1.Enabled = false;
                    ShieldLeftPicBox2.Enabled = false;
                    ShieldLeftPicBox3.Enabled = false;
                    ShieldLeftPicBox1.Visible = false;
                    ShieldLeftPicBox2.Visible = false;
                    ShieldLeftPicBox3.Visible = false;
                    Shields = new PictureBox[]
                    {
                        ShieldRightPicBox1,
                        ShieldRightPicBox2,
                        ShieldRightPicBox3
                    };
                }
                else
                {
                    ShieldRightPicBox1.Enabled = false;
                    ShieldRightPicBox2.Enabled = false;
                    ShieldRightPicBox3.Enabled = false;
                    ShieldRightPicBox1.Visible = false;
                    ShieldRightPicBox2.Visible = false;
                    ShieldRightPicBox3.Visible = false;
                    Shields = new PictureBox[]
                    {
                        ShieldLeftPicBox1,
                        ShieldLeftPicBox2,
                        ShieldLeftPicBox3
                    };
                }
            }
        }
        public Type Type { get; set; }

        private float _health = 100f;
        public float Health
        {
            get => _health;
            set
            {
                float diff = value - _health;
                if (value > 100)
                {
                    _health = value;
                }
                else if (value < 0)
                {
                    _health = 0;
                }
                else
                {
                    _health = value;
                }
                HealthChangedEvent?.Invoke(this, new HealthChangedEventArgs(diff));
            }
        }

        public bool IsAnimating { get; private set; }

        public PictureBox[]? Shields { get; private set; }

        public event EventHandler? CharacterMouseEnter;
        public event EventHandler? CharacterMouseClick;
        public event EventHandler? GotDamagedEvent;
        public event EventHandler? GotKilledEvent;
        public event HealthChangedHandler? HealthChangedEvent;

        private void SetTransperency()
        {
            Point pos;

            if (HeadPictureBox?.Parent is not null)
            {
                pos = HeadPictureBox.Parent.PointToScreen(HeadPictureBox.Location);
                pos = this.PointToClient(pos);
                HeadPictureBox.Parent = this;
                HeadPictureBox.Location = pos;
                HeadPictureBox.BackColor = Color.Transparent;
            }
            if (BodyPictureBox?.Parent is not null)
            {
                pos = BodyPictureBox.Parent.PointToScreen(BodyPictureBox.Location);
                pos = this.PointToClient(pos);
                BodyPictureBox.Parent = this;
                BodyPictureBox.Location = pos;
                BodyPictureBox.BackColor = Color.Transparent;
            }
            if (LegsPictureBox?.Parent is not null)
            {
                pos = LegsPictureBox.Parent.PointToScreen(LegsPictureBox.Location);
                pos = this.PointToClient(pos);
                LegsPictureBox.Parent = this;
                LegsPictureBox.Location = pos;
                LegsPictureBox.BackColor = Color.Transparent;
            }
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (Type == Type.Hero)
            {
                ((PictureBox)sender!).BackColor = _heroEnterColor;
            }
            else if (Type == Type.Enemy)
            {
                ((PictureBox)sender!).BackColor = _enemyEnterColor;
            }

            CharacterMouseEnter?.Invoke(sender, e);
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            if (picBox.BackColor != _damageColor)
            {
                picBox.BackColor = default;
            }
        }

        private async void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender!;
            if (Type == Type.Hero)
            {
                int shieldNumber = int.Parse(picBox.Tag!.ToString()!);
                SwitchShield(shieldNumber);

            }
            else if (Type == Type.Enemy)
            {
                await MakeDamage((PictureBox)sender!);
            }
            CharacterMouseClick?.Invoke(sender, e);
        }

        private void SwitchShield(int shieldNumber)
        {
            if (Shields is not null)
            {
                PictureBox shield = Shields[shieldNumber];

                if (shield.Image is not null)
                {
                    shield.Image = null;
                }
                else
                {
                    ClearShields();
                    shield.Image = Properties.Resources.board_left;
                }
            }
        }

        private void ClearShields()
        {
            if (Shields is not null)
            {
                foreach (var shield in Shields)
                {
                    shield.Image = null;
                }
            }
        }

        public bool IsShield(PictureBox picBox)
        {
            if (Shields is not null)
            {
                int partNum = int.Parse(picBox.Tag!.ToString()!);
                return Shields[partNum].Image is not null;
            }
            return false;
        }

        public bool IsShield(int partNum)
        {
            if (partNum > 2 || partNum < 0)
                return false;

            if (Shields is not null)
            {
                return Shields[partNum].Image is not null;
            }

            return false;
        }

        public async Task SetDamageColor(PictureBox picBox)
        {
            if (IsShield(picBox))
            {
                picBox.BackColor = _defenseColor;
            }
            else
            {
                picBox.BackColor = _damageColor;
            }
            await Task.Delay(250);
            picBox.BackColor = default;
        }

        public async Task AnimateDamage()
        {
            Padding padding = Padding;
            int shift = 10;
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    HeadPictureBox.Padding = new Padding(padding.Left + shift, padding.Top, padding.Right, padding.Bottom);
                    BodyPictureBox.Padding = new Padding(padding.Left + shift, padding.Top, padding.Right, padding.Bottom);
                    LegsPictureBox.Padding = new Padding(padding.Left + shift, padding.Top, padding.Right, padding.Bottom);
                }
                else
                {
                    HeadPictureBox.Padding = new Padding(padding.Left - shift, padding.Top, padding.Right, padding.Bottom);
                    BodyPictureBox.Padding = new Padding(padding.Left - shift, padding.Top, padding.Right, padding.Bottom);
                    LegsPictureBox.Padding = new Padding(padding.Left - shift, padding.Top, padding.Right, padding.Bottom);
                }
                await Task.Delay(20);
            }
            Padding = padding;
        }

        public async Task MakeDamage(PictureBox picBox)
        {
            if (IsAnimating || Health == 0)
                return;

            // Damage calculation depending on the part number.
            float damage = CalculateDamage(picBox);
            Health -= damage;

            // Damage animation.
            IsAnimating = true;
            await Task.WhenAll(
                     SetDamageColor(picBox),
                     AnimateDamage()
                 );
            await Task.Delay(500);
            IsAnimating = false;

            // Call GotKilled event if health is 0.
            if (Health == 0)
            {
                GotKilledEvent?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                GotDamagedEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        private float CalculateDamage(PictureBox picBox)
        {
            int partNum = int.Parse(picBox.Tag!.ToString()!);
            float damage;
            damage = partNum switch
            {
                0 => (float)new Random().NextDouble(20, 30),
                1 => (float)new Random().NextDouble(10, 20),
                2 => (float)new Random().NextDouble(15, 25),
                _ => throw new ArgumentException("Part number does not exist.")
            };

            if (IsShield(partNum))
            {
                damage *= partNum switch
                {
                    0 => 0.75f,
                    1 => 0.25f,
                    2 => 0.5f,
                    _ => throw new ArgumentException("Part number does not exist.")
                };
            }

            return damage;
        }
    }

    public class HealthChangedEventArgs : EventArgs
    {
        public float Value { get; private set; }
        public HealthChangedEventArgs(float value)
        {
            Value = value;
        }
    }

    public static class RandomExtensions
    {
        public static double NextDouble(
            this Random random,
            double minValue,
            double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
