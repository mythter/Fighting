using Fighting.Models;
using System.Drawing.Text;

namespace Fighting.Controls
{
    public partial class CharacterBox : UserControl
    {
        #region Custom font
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font CustomFont;
        #endregion

        public CharacterBox(Character character)
        {
            InitializeComponent();
            WireAllControls(this);
            FrameImage = Properties.Resources.Frame_2;

            ArgumentNullException.ThrowIfNull(character);

            Character = character;
            CharacterImage = character.Image;
            CharacterName = character.Name;

            #region Custom font
            byte[] fontData = Properties.Resources.CityBrawlersBoldCaps;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.CityBrawlersBoldCaps.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.CityBrawlersBoldCaps.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            CustomFont = new Font(fonts.Families[0], 22.0F);
            CharacterNameLabel.Font = CustomFont;
            #endregion
        }

        public Image? CharacterImage
        {
            get => CharacterPictureBox.BackgroundImage;
            set => CharacterPictureBox.BackgroundImage = value;
        }

        public Image? FrameImage
        {
            get => CharacterPictureBox.Image;
            set => CharacterPictureBox.Image = value;
        }

        public string? CharacterName
        {
            get => CharacterNameLabel.Text;
            set => CharacterNameLabel.Text = value;
        }

        public Character Character { get; set; }

        private void WireAllControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                c.Click += Control_Click;
                if (c.HasChildren)
                {
                    WireAllControls(c);
                }
            }
        }

        private void Control_Click(object? sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);
        }
    }
}
