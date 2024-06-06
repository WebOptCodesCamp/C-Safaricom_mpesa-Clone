using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using UserInfo;
using Component;
namespace MainAccount{
public class SignUp{
public static void createAccount(){
     Console.Clear();
     Console.ForegroundColor = ConsoleColor.DarkGray;   
    Console.WriteLine("\n\nEnter Your Full Name: \n");
    Console.ForegroundColor = ConsoleColor.Blue;
    string? name = Console.ReadLine();
     Console.ForegroundColor = ConsoleColor.DarkGray;   
    Console.WriteLine("\nEnter your Email Address: \n");
     Console.ForegroundColor = ConsoleColor.Green;   
    string? email = Console.ReadLine();
     Console.ForegroundColor = ConsoleColor.DarkGray;   
    Console.WriteLine("\nEnter your ID number: \n");
     Console.ForegroundColor = ConsoleColor.Yellow;   
    string? idno = Console.ReadLine();
     Console.ForegroundColor = ConsoleColor.DarkGray;   
    Console.WriteLine("\nEnter your Age: \n");
     Console.ForegroundColor = ConsoleColor.White;   
    int age = int.Parse(Console.ReadLine() ?? string.Empty);
     Console.ForegroundColor = ConsoleColor.DarkGray;   
    Console.WriteLine("\nEnter your phone number: \n");
     Console.ForegroundColor = ConsoleColor.Yellow;   
    string? phone = Console.ReadLine();
    float balance = 0;
    Console.ForegroundColor=ConsoleColor.DarkGray;
    Console.WriteLine("\nEnter  Your Pin:  \n");
     ProgramComponent comp = new ProgramComponent();
    string pin1= ProgramComponent.WritePin();
    Console.ForegroundColor=ConsoleColor.DarkGray;
    Console.WriteLine("\nConfirm  Your Pin:  \n");
     string pin2= ProgramComponent.WritePin();

     if(pin1!=pin2){
    Console.ForegroundColor=ConsoleColor.DarkRed;

        Console.WriteLine("\n\nOohps!,The Pin Entered does not match\n\n");
     }else{

        Console.Write("\n\nPlease Wait While Saving Your Details: ");
        for(int i=0; i<10; i++){
            Console.Write(">>");
            Thread.Sleep(350);
        }
        for(int j=10; j>=3; j--){
            Console.Write("\b \b");
            Thread.Sleep(250*j);
        }
        for(int t=3; t<=10;t++){
            Console.Write(">>");
            Thread.Sleep(180*t);
        }
        
     
    

                
                User myuser = new User{Name=name,Email=email,ID=idno,Age=age,Phone=phone,Balance=balance,Pin=pin1};
                string Datajson = File.ReadAllText("ConsoleApp1/Database/Users.json");
                List<User>? addme = JsonSerializer.Deserialize<List<User>>(Datajson);
                if(addme is not null){
                addme.Add(myuser);
                var options = new JsonSerializerOptions();
                options.WriteIndented = true;
                string UserJson = JsonSerializer.Serialize(addme,options);
                File.WriteAllText("ConsoleApp1/Database/Users.json",UserJson);
                Console.ForegroundColor=ConsoleColor.DarkGreen;
                Console.WriteLine("\n\nHurray Saved Sucessfully ////\n");
                Console.ForegroundColor = ConsoleColor.White;   
                }
                }
}

}}