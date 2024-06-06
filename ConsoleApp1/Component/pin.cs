using System;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Component{

    public class Pin{

       public static string EnterPin(){
       StringBuilder input = new StringBuilder();

while(true)
{
ConsoleKeyInfo inputkey = Console.ReadKey(true);

  if(input.Length==6){
    break;
  }
  if(inputkey.Key==ConsoleKey.Backspace & input.Length>0){
input.Remove(input.Length-1,1);

    
    Console.Write("\b \b");

  }else if(inputkey.Key != ConsoleKey.Backspace){
    input.Append(inputkey.KeyChar);
    
    
    Console.ForegroundColor = ConsoleColor.White;

    Console.Write(input[input.Length-1]);
    Thread.Sleep(240);
    Console.Write("\b \b");
    Console.ForegroundColor = ConsoleColor.Black;
     
   Console.Write("*");

     }else if(inputkey.Key==ConsoleKey.Enter){
    break;
   }
}

string myinput = input.ToString();
        Console.ForegroundColor=ConsoleColor.White;
      return myinput;

        }
  




        }
    }
