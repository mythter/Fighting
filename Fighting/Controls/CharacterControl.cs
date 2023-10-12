using Fighting.Models;
using System.Runtime.CompilerServices;

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
                Head = character.Head;
                Body = character.Body;
                Legs = character.Legs;
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

        private void PictureBox_Click(object sender, EventArgs e)
        {
            CharacterMouseClick?.Invoke(sender, e);
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            CharacterMouseDown?.Invoke(sender, e);
        }

        public async Task SetDamage(PictureBox picBox)
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
            return picBox.Tag!.ToString() switch
            {
                "1" => ShieldPicBox1.Image is not null,
                "2" => ShieldPicBox2.Image is not null,
                "3" => ShieldPicBox3.Image is not null,
                _ => throw new ArgumentException(""),
            };
        }
    }
}
