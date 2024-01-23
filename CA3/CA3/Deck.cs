using System;
namespace CA3
{
    public class Deck
    {
        //properties - get only
        public string[] Suit { get; }
        public string[] Rank { get; }

        //hardcoded property values
        public Deck()
        {
            Suit = new string[] { "Hearts", "Diamonds", "Clubs", "Spades" };

            Rank = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        }

        //method to control card dealing 
        //this method uses the random.next() method to supply a random array value for both 'suit' and 'rank'
        //a switch statement is used to control the outputted int value 

        public int DealCard(int score)
        {
            Random r1 = new Random();

            int value = 10;
            int index1 = r1.Next(0, 4);
            int index2 = r1.Next(0, 13);

            switch (index2)
            {

                case 0:
                    value = 2;
                    break;
                case 1:
                    value = 3;
                    break;
                case 2:
                    value = 4;
                    break;
                case 3:
                    value = 5;
                    break;
                case 4:
                    value = 6;
                    break;
                case 5:
                    value = 7;
                    break;
                case 6:
                    value = 8;
                    break;
                case 7:
                    value = 9;
                    break;
                case 8:
                    value = 10;
                    break;
                case 9:
                    value = 10;
                    break;
                case 10:
                    value = 10;
                    break;
                case 11:
                    value = 10;
                    break;
                case 12:
                    value = 11;
                    break;
            }

            //controls variable Ace value
            if (value == 11 && (score + value) > 21)
                value = 1;

            //output text to console
            Console.WriteLine($"Card dealt is the {Rank[index2]} of {Suit[index1]}, value {value}");

            return value;

        }
    }
}
