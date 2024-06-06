using System;
using Graphic;
using SafaricomApi;
namespace MainAccount{



    public class Safaricom{

    public static void SafDash(){
        Console.Clear();
        Mygraphic graphic = new Mygraphic();
        Console.ForegroundColor=ConsoleColor.Green;
        Console.WriteLine(graphic.safaricom);
        Console.ForegroundColor= ConsoleColor.DarkGray;
        Console.WriteLine("\n\n1.Request for Agent Number");
        Console.WriteLine("\n2.Request for Paybill Number");
        Console.WriteLine("\n3.Request for Till Number");

        Console.ForegroundColor= ConsoleColor.Blue;
        Console.Write("\n\nYour Choice: ");
        int slt = int.Parse(Console.ReadLine() ?? string.Empty);
        Apis apis = new Apis();
        switch (slt)
        {
            case 1:
            Apis.MainApi(slt);
            break;
            case 2:
            Apis.MainApi(slt);
            break;
            case 3:
            Apis.MainApi(slt);
            break;
            
            default:
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine("\nOhps! , Invalid choice");
            break;
        }
        Console.ForegroundColor= ConsoleColor.White;


    }



    }








}