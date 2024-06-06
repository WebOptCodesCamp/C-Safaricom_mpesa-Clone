using System;
using Graphic;
using UserInfo;
using TillInfo;
using System.Text.Json;

namespace SafaricomApi{


    public class MyTill{

        public static void CreateTill(){
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Mygraphic graphic = new Mygraphic();
            Console.WriteLine(graphic.safaricom);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n\nEnter Your Till Name: \n");
            Console.ForegroundColor = ConsoleColor.Blue;
            string? tillname = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nEnter Your Phone Number: \n");
            Console.ForegroundColor = ConsoleColor.Green;
            string? phone= Console.ReadLine();
            Random  rand = new Random();
            int num1 = rand.Next(20,1200);
            int num2 = rand.Next(12,569);
            string tillnumber = num1+""+num2+"";

           string usersjson = File.ReadAllText("ConsoleApp1/Database/Users.json");
            bool IsRegistered = false;
            if(usersjson != ""){

                List<User>? allUsers = JsonSerializer.Deserialize<List<User>>(usersjson);

                if(allUsers is not null){

                    foreach(var usr in allUsers){
                        if(usr.Phone==phone){
                            IsRegistered = true;
                            break;
                        }
                    }
                }





            }


          string tilljson = File.ReadAllText("ConsoleApp1/Database/Till.json");
          var options = new JsonSerializerOptions();
          options.WriteIndented = true;
          Till till = new Till{TillName=tillname,PhoneNo=phone,TillNo=tillnumber};
          if(IsRegistered){

          if(tilljson !=""){
            List<Till>? tills = JsonSerializer.Deserialize<List<Till>>(tilljson);
            if(tills is not null){
                tills.Add(till);
                string tillJson = JsonSerializer.Serialize(tills,options);
                File.WriteAllText("ConsoleApp1/Database/Till.json",tillJson);


            }





          }else{

            List<Till> mytill = new List<Till>();
            mytill.Add(till);
            string tillJson = JsonSerializer.Serialize(mytill,options);
                File.WriteAllText("ConsoleApp1/Database/Till.json",tillJson);


          }








            
            Console.ForegroundColor=ConsoleColor.DarkBlue;
            Console.WriteLine("\n\nYour Till number have been Created Successfully");
            Console.ForegroundColor=ConsoleColor.DarkYellow;
            Console.WriteLine($"\n\nYour Till Number is {tillnumber}\n");}else{
                Console.ForegroundColor=ConsoleColor.Red;

            Console.WriteLine("\nOhps!! , Invalid phone number entered please try again");
            Console.ForegroundColor = ConsoleColor.White;
            
            }





        }
    }




}