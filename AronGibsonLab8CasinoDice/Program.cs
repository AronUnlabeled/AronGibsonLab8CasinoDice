using System;
namespace AronGibsonLab8CasinoDice
{
    class Program
    {
        static void Main(string[] args)
        {
            //creates dice object with arbitrary amount sides so we can change sides in our loop without creating the object every loop.
            dice d = new dice(6);
            int die1;
            int die2;
            int sides;
            string again;
            do 
            {
                do 
                {
                    try
                    {
                        Console.WriteLine("Enter number of sides (between 2 and 1073741823)");
                        sides = int.Parse(Console.ReadLine());
                        if (sides > 1)
                            if (sides < 1073741824)
                                break;
                        Console.WriteLine("must be between 2 and 1073741823");
                        
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("must enter a number");
                    }
                }while (true);

                d.setSides(sides);
                die1 = RandGen(sides);
                die2 = RandGen(sides);
                Console.WriteLine(d.roll(die1,die2));

                do
                {
                    Console.WriteLine("Roll more dice? y or n");
                    again = Console.ReadLine();
                    if (again == "y")
                        break;
                    else if (again == "n")
                        break;
                    Console.WriteLine("Must select y or n");
                } while(true);

            } while (again=="y");


        }

        public static int RandGen(int sides){
            Random rand = new Random();
            return rand.Next(1,sides+1);
        }


    }

    class dice 
    {

        private int sides;

        public dice(int sides) {
            this.sides = sides;
        }

        public int getSides() {
            return sides;    
        }

        public void setSides(int sides) {
            this.sides = sides;
        }

        public string roll(int die1,int die2) {
            if (sides == 6) 
            {

                if (die1 + die2 == 7)
                    return $"Win: a total of 7 or 11 \n{die1} + {die2} = 7";

                else if(die1+die2==11)
                    return $"Win: a total of 7 or 11 \n{die1} + {die2} = 11";

                switch (die1, die2)
                {
                    case (1, 1):
                        return "Snake eyes two 1s \nCraps: A total of 2,3 or 12 ";
                    case (1, 2):
                        return "Ace deuce: A 1 and a 2 \nCraps: A total of 2,3 or 12";
                    case (2,1):
                        return "Ace deuce: A 1 and a 2 \nCraps: A total of 2,3 or 12";
                    case (6, 6):
                        return "Box cars: two 6s \nCraps: A total of 2,3 or 12";
                    default:
                        return $"{die1} + {die2} = {die1+die2}";
                }
            }
            return $"{die1} + {die2} = {die1 + die2}";
        }
    }
}
