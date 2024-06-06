using System;
using Graphic;


namespace ControllerApp{

    public class ControllApp{


        public static void Choose(string? phone, string? pin){
            Mygraphic graphic = new Mygraphic();
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.ForegroundColor=ConsoleColor.DarkGreen;
            Console.WriteLine(graphic.mpesa);
            Console.ForegroundColor=ConsoleColor.DarkBlue;
            Console.WriteLine("\n\nWelcome~ :");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n\n1.Send Money");
            Console.WriteLine("\n2.Lipa na Paybill");
            Console.WriteLine("\n3.Lipa na Till");
            Console.WriteLine("\n4.Widthdraw Cash From Agent");
            Console.WriteLine("\n5.other Services\n\n");
            
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\n\nYour Choice: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            int slt = int.Parse( Console.ReadLine() ?? string.Empty);

            switch (slt)
            {
                case 1:
                Console.Clear();
                Send.SendMoney(phone,pin);
                break;
                case 2:
                Console.Clear();
                LipaBill.PayMyBill(phone,pin);
                break;
                case 3:
                Console.Clear();
                PayTill.LipaTill(phone,pin);
                break;
                case 4:
                Console.Clear();
                WidthdrawFromAgent.WidthdrawNow(phone,pin);
                break;
                case 5:
                Console.Clear();
                Services.MyService(phone,pin);
                break;
                
                default:
            Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Ohps!! , Invalid choice please try again");
                break;
            }

            Console.WriteLine("\n");






        }
    }




}