using Fighting.Models;

namespace Fighting.Helpers
{
    public static class CharacterGenerator
    {
        public static int Count { get; } = 8;

        public static Character[] GenerateCharacters()
        {
            Character[] characters = new Character[Count];

            characters[0] = new Character
            {
                Name = "Ken",
                Image = Properties.Resources.Ken_left,
                Head = Properties.Resources.Ken_left_1,
                Body = Properties.Resources.Ken_left_2,
                Legs = Properties.Resources.Ken_left_3,
            };
            characters[1] = new Character
            {
                Name = "Ryu",
                Image = Properties.Resources.Ryu_left,
                Head = Properties.Resources.Ryu_right_1,
                Body = Properties.Resources.Ryu_right_2,
                Legs = Properties.Resources.Ryu_right_3,
            };
            characters[2] = new Character
            {
                Name = "Kenn",
                Image = Properties.Resources.Ken_left,
                Head = Properties.Resources.Ken_left_1,
                Body = Properties.Resources.Ken_left_2,
                Legs = Properties.Resources.Ken_left_3,
            };
            characters[3] = new Character
            {
                Name = "Ryuu",
                Image = Properties.Resources.Ryu_left,
                Head = Properties.Resources.Ryu_right_1,
                Body = Properties.Resources.Ryu_right_2,
                Legs = Properties.Resources.Ryu_right_3,
            };
            characters[4] = new Character
            {
                Name = "Kenn",
                Image = Properties.Resources.Ken_left,
                Head = Properties.Resources.Ken_left_1,
                Body = Properties.Resources.Ken_left_2,
                Legs = Properties.Resources.Ken_left_3,
            };
            characters[5] = new Character
            {
                Name = "Ryuu",
                Image = Properties.Resources.Ryu_left,
                Head = Properties.Resources.Ryu_right_1,
                Body = Properties.Resources.Ryu_right_2,
                Legs = Properties.Resources.Ryu_right_3,
            };
            characters[6] = new Character
            {
                Name = "Kenn",
                Image = Properties.Resources.Ken_left,
                Head = Properties.Resources.Ken_left_1,
                Body = Properties.Resources.Ken_left_2,
                Legs = Properties.Resources.Ken_left_3,
            };
            characters[7] = new Character
            {
                Name = "Ryuu",
                Image = Properties.Resources.Ryu_left,
                Head = Properties.Resources.Ryu_right_1,
                Body = Properties.Resources.Ryu_right_2,
                Legs = Properties.Resources.Ryu_right_3,
            };
            return characters;
        }

        public static Character GenerateRandomCharacter()
        {
            return GenerateCharacters()[new Random().Next(Count)];
        }
    }
}
