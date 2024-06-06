using System;
using Component;
using UserInfo;
using ControllerApp;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MainAccount{



    public class SignIn:ControllApp{

  public static void LogIn(){

  Console.Clear();
  Console.ForegroundColor = ConsoleColor.DarkBlue;

  Console.WriteLine("\n\n\n\nWelcome Back ~");
 Console.ForegroundColor=ConsoleColor.DarkGray;
  Console.WriteLine("\nPlease Enter your Phone number: \n");
 Console.ForegroundColor=ConsoleColor.DarkGreen;
 string? phone = Console.ReadLine();
 Console.ForegroundColor=ConsoleColor.DarkGray;
  Console.WriteLine("\nPlease Enter your Pin: \n");
  ProgramComponent comp = new ProgramComponent();
  string pin = ProgramComponent.WritePin();
  Console.WriteLine("\n");
 
 string usersJson = File.ReadAllText("ConsoleApp1/Database/Users.json");
 List<User>? users=JsonSerializer.Deserialize<List<User>>(usersJson);

 if(users is not null){
bool IsUser = false;
    foreach(var user in users){

        if(user.Pin == pin && user.Phone == phone){
            IsUser= true;
            break;
        }
    }

if(IsUser){

Console.ForegroundColor=ConsoleColor.Yellow;
Console.WriteLine("\nLoged In Successfully");
Thread.Sleep(700);
Choose(phone,pin);


}else{

  Console.ForegroundColor=ConsoleColor.Red;
Console.WriteLine("\nOhps!!, Invalid pin entered");  
}

 }


Console.ForegroundColor=ConsoleColor.White;
  }


    }
}