using Fighting.Enums;
using Fighting.Models;

namespace Fighting.Helpers
{
    public static class CharacterGenerator
    {
        public static int Count { get; } = 8;

        private static readonly string[] Names = { "Ken", "Ryu", "Balrog", "Guile", "Cammy", "Chun-Li", "Juri", "Sakura"};

        public static Character[] GenerateCharacters(Side side)
        {
            Character[] characters = new Character[Count];
            string s = side.ToString().ToLower();

            for (int i = 0; i < Count; i++)
            {
                string name =  Names[i].Replace("-", "");
                characters[i] = new Character
                {
                    Name = Names[i],
                    Image = Properties.Resources.ResourceManager.GetObject($"{name}_art") as Image,
                    Head = Properties.Resources.ResourceManager.GetObject($"{name}_{s}_1") as Image,
                    Body = Properties.Resources.ResourceManager.GetObject($"{name}_{s}_2") as Image,
                    Legs = Properties.Resources.ResourceManager.GetObject($"{name}_{s}_3") as Image,
                };
            }

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
