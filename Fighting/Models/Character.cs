using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighting.Models
{
    public class Character
    {
        public string Name { get; set; }
        public Image Head { get; set; }
        public Image Body { get; set; }
        public Image Legs { get; set; }
    }
}
