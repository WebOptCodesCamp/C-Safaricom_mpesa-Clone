using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MainAccount;

namespace Options{

    public class Myoptions{
 public static void Choice(){
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("\n => ~ What are you going to Do:");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n 1.Create your Account first");
Console.WriteLine("\n 2.Already , Have account? Login");
Console.WriteLine("\n 3.Safaricom SDK Services\n\n");


Console.ForegroundColor = ConsoleColor.White;
  Console.Write("Your Choice:  ");
  int slt = int.Parse(Console.ReadLine() ?? string.Empty);

  switch (slt)
  {
    case 1:
    Acc.Account(slt);
    break;
    case 2:
    Acc.Account(slt);
    break;
    case 3:
    Acc.Account(slt);
    break;
    
    default:
    Console.ForegroundColor=ConsoleColor.Red;
    Console.WriteLine("\nOhps invalid input please try again");
    Console.ForegroundColor=ConsoleColor.White;
    break;
  }




  }
    }
}
