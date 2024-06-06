using System;
using UserInfo;
using TillInfo;
using System.Text.Json;


namespace ControllerApp{
    public class PayTill{

        public static void LipaTill(string? phone, string? pin){
        Console.Clear();
        Console.WriteLine("\n\n\n");

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nEnter till number: \n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        string? till = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nEnter  amount: \n");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        int amount = int.Parse(Console.ReadLine() ?? string.Empty);





        if(amount <10){
            Console.ForegroundColor =ConsoleColor.Red;
            Console.WriteLine("\n\nOhps, The amount entered is less than minimum");
        }else{

        int cost =0;
        string usersjson = File.ReadAllText("Consoleapp1/Database/Users.json");
        string tilljson = File.ReadAllText("ConsoleApp1/Database/Till.json");


        if(usersjson != "" && tilljson != ""){

          var options = new JsonSerializerOptions();
          options.WriteIndented = true;
          List<User>? users = JsonSerializer.Deserialize<List<User>>(usersjson);
          List<Till>? tills = JsonSerializer.Deserialize<List<Till>>(tilljson);


          if(users is not null && tills is not null){


            // we want to check if we have a valid till number entered

            bool IsvalidTill = false;
            string? tillname = "";
            string? tillphone ="";

            foreach(var til in tills){
                if(til.TillNo == till){

                    IsvalidTill = true;
                    tillname = til.TillName;
                    tillphone = til.PhoneNo;
                  break;
                }
            }
        if(IsvalidTill){
            int count = 0;
            int me = 0;
            int his = 0;

            foreach(var user in users){
                if(user.Phone == phone){
                    me = count;
                }else if(user.Phone == tillphone){
                    his = count;
                }


                count++;
            }

            if(users[me].Balance < amount){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\nOhps, Failed you have insufficient fund to send cash {amount} ksh to {tillname}");
            }else{
                users[me].Balance -= amount;
                users[his].Balance += amount;
                string usersJson = JsonSerializer.Serialize(users,options);
                File.WriteAllText("ConsoleApp1/Database/Users.json",usersJson);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nConfirmed  cash {amount} ksh  sent to {tillname} , transaction cost is {cost} ksh and your account balance is {users[me].Balance}");
          


            }



        }else{

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nOhps , Invalid till number entered");
        }




          }



        }







        }

        }
    }
}