using Type = Fighting.Enums.Type;

namespace Fighting.Models
{
    public class Character
    {
        public string? Name { get; set; }
        public Image? Image { get; set; }
        public Image? Head { get; set; }
        public Image? Body { get; set; }
        public Image? Legs { get; set; }
        public Type Type { get; set; }
    }
}
