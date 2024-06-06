using System;
using Graphic;
namespace ControllerApp{

    public class Services{
        public static void MyService(string? phone , string? pin){
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Mygraphic graphic = new Mygraphic();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(graphic.mpesa);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n1.Change pin");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n2.Check balance");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n3.Deposit Money to Agent");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\nYour Choice: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            int choice = int.Parse(Console.ReadLine() ?? string.Empty);

            switch(choice){
                case 1:
                Console.Clear();
                ChangePin.NewPin(phone);
                break;
                case 2:
                Console.Clear();
                CheckBalance.NewBalance(phone,pin);
                break;
                case 3:
                Console.Clear();
                DepositFromAgent.DepositNow(phone,pin);
                break;

                default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nOhps invalid choice");
                break;
            }

        }
    }
}