using System;
using Graphic;
using UserInfo;
using MyAgent;
using System.Text.Json;
namespace SafaricomApi{

public class CreateAgent{



    public static void NewAgent(){
        Console.Clear();
        Console.WriteLine("\n\n");
        Mygraphic graphic = new Mygraphic();
        Console.WriteLine(graphic.safaricom);
        Console.ForegroundColor=ConsoleColor.DarkGreen;
        Console.WriteLine("\n\nPlease Fill in your Number: \n");
        Console.ForegroundColor=ConsoleColor.DarkRed;
        string? phone = Console.ReadLine();
        Console.ForegroundColor=ConsoleColor.DarkGreen;
        Console.WriteLine("\n\nPlease Fill in your Desirable agent name:\n");
        Console.ForegroundColor=ConsoleColor.DarkBlue;
        string? agentname = Console.ReadLine();  
        Console.ForegroundColor=ConsoleColor.White;
        Random random = new Random();
        int num1 = random.Next(0,9);
        int num2  = random.Next(200,900);
        int num3 = random.Next(100,1200);
        int num4 = random.Next(7,20);
        int num5 = random.Next(16,200);
        int num6 = random.Next(123,800);
        string agentno = num1+""+num2+""+num3+"";
        string storenumber =num4+""+num5+""+num6+"";

        string userJson = File.ReadAllText("ConsoleApp1/Database/Users.json");

        List<User>? users = JsonSerializer.Deserialize<List<User>>(userJson);
       int  IsRegistered = 0;
        if(users is not null){

         foreach(var user in users){

            if(user.Phone==phone){
                IsRegistered=1;
                break;
            }
         }

         if(IsRegistered>0){

          MyAgentDetails details = new MyAgentDetails{Phone=phone,Name=agentname,AgentNo=agentno,StoreNo=storenumber};
          
          var options = new JsonSerializerOptions();
          options.WriteIndented = true;
          string agentJson = File.ReadAllText("ConsoleApp1/Database/Agent.json");
          if(agentJson != ""){
          List<MyAgentDetails>? agents = JsonSerializer.Deserialize<List<MyAgentDetails>>(agentJson);
           if(agents is not null){
            agents.Add(details);
            string agentsJson = JsonSerializer.Serialize(agents,options);
            File.WriteAllText("ConsoleApp1/Database/Agent.json",agentsJson);
            Console.ForegroundColor=ConsoleColor.DarkGray;
            Console.WriteLine("\nData saved Successfully !!");
            Console.ForegroundColor = ConsoleColor.White;
           }

  


          }else{

         List<MyAgentDetails> addme = new List<MyAgentDetails>();
         addme.Add(details);
         
            string agentsJson = JsonSerializer.Serialize(addme,options);
            File.WriteAllText("ConsoleApp1/Database/Agent.json",agentsJson);
            Console.ForegroundColor=ConsoleColor.DarkGray;
            Console.WriteLine("\nData Successfully saved");
            Console.ForegroundColor = ConsoleColor.White;



          }




        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"\n\nYour Agent Number is {agentno} and Store Number is {storenumber}\n\n");
        Console.ForegroundColor = ConsoleColor.White;


            
            


         }else{
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine("\n\nOhps! Invalid phone number Entered");
            Console.ForegroundColor=ConsoleColor.White;


         }

        }
        
        






    }
}




}