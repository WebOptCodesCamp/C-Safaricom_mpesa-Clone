using System;
using Component;
using UserInfo;
using System.Text.Json;
namespace ControllerApp{


    public class CheckBalance{

        public static void NewBalance(string? phone, string? pin){
             ProgramComponent comp = new ProgramComponent();
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n\nEnter your pin: \n\n");
            string mypin = ProgramComponent.WritePin();
            

            if(mypin != pin){
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\n\nOhps pin entered is incorrect");
            }else{

              string userjson = File.ReadAllText("ConsoleApp1/Database/Users.json");

              if(userjson != ""){
               List<User>? users = JsonSerializer.Deserialize<List<User>>(userjson);
               

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
                   
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nYour Account balance is cash {users[me].Balance}.00 shillings");



               







              }



            }


        }
    }
    }}