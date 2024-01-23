using System;
namespace CA3
{
	public class Player
	{
        //properties
        public string Name { get; set; }
        public int Score { get; set; }

        //ctors
        public Player()
        {
        }

        public Player(string name)
        {
            Name = name;
        }

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }


        //methods

        public override string ToString()
        {
            return Name;
        }
    }
}

