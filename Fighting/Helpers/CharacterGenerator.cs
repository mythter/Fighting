using Fighting.Enums;
using Fighting.Models;

namespace Fighting.Helpers
{
    public static class CharacterGenerator
    {
        public static int Count { get; } = 8;

        public static Character[] GenerateCharacters(Side side)
        {
            Character[] characters = new Character[Count];
            string s = side.ToString().ToLower();

            characters[0] = new Character
            {
                Name = "Ken",
                Image = Properties.Resources.Ken_art,
                Head = Properties.Resources.ResourceManager.GetObject($"Ken_{s}_1") as Image,
                Body = Properties.Resources.ResourceManager.GetObject($"Ken_{s}_2") as Image,
                Legs = Properties.Resources.ResourceManager.GetObject($"Ken_{s}_3") as Image,
            };
            characters[1] = new Character
            {
                Name = "Ryu",
                Image = Properties.Resources.Ryu_art,
                Head = Properties.Resources.ResourceManager.GetObject($"Ryu_{s}_1") as Image,
                Body = Properties.Resources.ResourceManager.GetObject($"Ryu_{s}_2") as Image,
                Legs = Properties.Resources.ResourceManager.GetObject($"Ryu_{s}_3") as Image,
            };
            characters[2] = new Character
            {
                Name = "Balrog",
                Image = Properties.Resources.Barlog_art,
                Head = Properties.Resources.ResourceManager.GetObject($"Balrog_{s}_1") as Image,
                Body = Properties.Resources.ResourceManager.GetObject($"Balrog_{s}_2") as Image,
                Legs = Properties.Resources.ResourceManager.GetObject($"Balrog_{s}_3") as Image,
            };
            characters[3] = new Character
            {
                Name = "Guile",
                Image = Properties.Resources.Guile_art,
                Head = Properties.Resources.ResourceManager.GetObject($"Guile_{s}_1") as Image,
                Body = Properties.Resources.ResourceManager.GetObject($"Guile_{s}_2") as Image,
                Legs = Properties.Resources.ResourceManager.GetObject($"Guile_{s}_3") as Image,
            };
            characters[4] = new Character
            {
                Name = "Cammy",
                Image = Properties.Resources.Cammy_art,
                Head = Properties.Resources.ResourceManager.GetObject($"Cammy_{s}_1") as Image,
                Body = Properties.Resources.ResourceManager.GetObject($"Cammy_{s}_2") as Image,
                Legs = Properties.Resources.ResourceManager.GetObject($"Cammy_{s}_3") as Image,
            };
            characters[5] = new Character
            {
                Name = "Chun-Li",
                Image = Properties.Resources.ChunLi_art,
                Head = Properties.Resources.ResourceManager.GetObject($"ChunLi_{s}_1") as Image,
                Body = Properties.Resources.ResourceManager.GetObject($"ChunLi_{s}_2") as Image,
                Legs = Properties.Resources.ResourceManager.GetObject($"ChunLi_{s}_3") as Image,
            };
            characters[6] = new Character
            {
                Name = "Juri",
                Image = Properties.Resources.Juri_art,
                Head = Properties.Resources.ResourceManager.GetObject($"Juri_{s}_1") as Image,
                Body = Properties.Resources.ResourceManager.GetObject($"Juri_{s}_2") as Image,
                Legs = Properties.Resources.ResourceManager.GetObject($"Juri_{s}_3") as Image,
            };
            characters[7] = new Character
            {
                Name = "Sakura",
                Image = Properties.Resources.Sakura_art,
                Head = Properties.Resources.ResourceManager.GetObject($"Sakura_{s}_1") as Image,
                Body = Properties.Resources.ResourceManager.GetObject($"Sakura_{s}_2") as Image,
                Legs = Properties.Resources.ResourceManager.GetObject($"Sakura_{s}_3") as Image,
            };
            return characters;
        }

        public static Character GenerateRandomCharacter(Side side)
        {
            return GenerateCharacters(side)[new Random().Next(Count)];
        }

        public static Character GenerateRandomCharacterExcept(string name, Side side)
        {
            Character character;
            Character[] characters = GenerateCharacters(side);
            Random rand = new Random();
            do
            {
                character = characters[rand.Next(Count)];
            }
            while (character.Name == name);

            return character;
        }
    }
}
