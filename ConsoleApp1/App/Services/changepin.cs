using System;
using Component;
using UserInfo;
using System.Text.Json;
namespace ControllerApp{


    public class ChangePin{

        public static void NewPin(string? phone){
             ProgramComponent comp = new ProgramComponent();
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nEnter your previous pin: \n\n");
            string previouspin = ProgramComponent.WritePin();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n\nEnter your new pin: \n\n");
            string pin = ProgramComponent.WritePin();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\nConfirm your new pin: \n\n");
            string pin1 = ProgramComponent.WritePin();

            if(pin != pin1){
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\n\nOhps pin entered does not match");
            }else{

              string userjson = File.ReadAllText("ConsoleApp1/Database/Users.json");

              if(userjson != ""){
               List<User>? users = JsonSerializer.Deserialize<List<User>>(userjson);
               var options = new JsonSerializerOptions();
               options.WriteIndented = true;

               if(users is not null){

                  int count =0;
                  int me =0;
                  

                  foreach(var user in users){

                    if(user.Phone == phone){

                     me = count;
                        
                    break;
                    }
                    count++;
                  }
                   if(users[me].Pin != previouspin){
                     Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nOhps incorrect pin entered");



               }else{
                users[me].Pin = pin;
                string usersJson = JsonSerializer.Serialize(users,options);
                File.WriteAllText("ConsoleApp1/Database/Users.json",usersJson);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nYour Pin has been changed successfully");



               }







              }



            }


        }
    }
    }}