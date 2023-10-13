﻿using Fighting.Enums;
using Fighting.Models;
using Type = Fighting.Enums.Type;

namespace Fighting.Controls
{
    public partial class CharacterControl : UserControl
    {
        Color damage = Color.Red;
        Color defense = Color.Green;
        public CharacterControl(Character? character)
        {
            InitializeComponent();
            SetTransperency();

            if (character is not null)
            {
                Head = character.Head!;
                Body = character.Body!;
                Legs = character.Legs!;
                Type = character.Type;
            }
        }

        public Image Head
        {
            get => HeadPictureBox.Image;
            set => HeadPictureBox.Image = value;
        }
        public Image Body
        {
            get => BodyPictureBox.Image;
            set => BodyPictureBox.Image = value;
        }
        public Image Legs
        {
            get => LegsPictureBox.Image;
            set => LegsPictureBox.Image = value;
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

        public PictureBox[]? Shields { get; set; }

        public event EventHandler? CharacterMouseEnter;
        public event EventHandler? CharacterMouseDown;
        public event EventHandler? CharacterMouseClick;

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
                ((PictureBox)sender!).BackColor = Color.FromArgb(80, 39, 245, 75);
            }
            else if (Type == Type.Enemy)
            {
                ((PictureBox)sender!).BackColor = Color.FromArgb(80, 245, 39, 42);
            }

            CharacterMouseEnter?.Invoke(sender, e);
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            if (picBox.BackColor != damage)
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
                await GetDamage((PictureBox)sender!);
                CharacterMouseClick?.Invoke(sender, e);
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

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            CharacterMouseDown?.Invoke(sender, e);
        }

        public async Task SetDamageColor(PictureBox picBox)
        {
            if (IsShield(picBox))
            {
                picBox.BackColor = defense;
            }
            else
            {
                picBox.BackColor = damage;
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

        private bool IsShield(PictureBox picBox)
        {
            if (Shields is not null)
            {
                int partNum = int.Parse(picBox.Tag!.ToString()!);
                return Shields[partNum].Image is not null;
            }
            return false;
        }

        public async Task GetDamage(PictureBox picBox)
        {
            await Task.WhenAll(
                     SetDamageColor(picBox),
                     AnimateDamage()
                 );
            await Task.Delay(500);
        }
    }

}
