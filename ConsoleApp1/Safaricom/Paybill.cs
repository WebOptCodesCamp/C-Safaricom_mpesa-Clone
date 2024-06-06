using System;
using Graphic;
using PaybillUser;
using System.Text.Json;
using UserInfo;

namespace SafaricomApi{


    public class PaybillApp{


        public static void GetPaybill(){
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Mygraphic graphic = new Mygraphic();
            Console.WriteLine("\n\n\n");
            Console.WriteLine(graphic.safaricom);
            Console.ForegroundColor=ConsoleColor.DarkGray;
            Console.WriteLine("\nPlease Enter Your Bussiness Name: \n");
            Console.ForegroundColor=ConsoleColor.Green;
            string? Bussinessname = Console.ReadLine();
            Console.ForegroundColor=ConsoleColor.DarkGray;
            Console.WriteLine("\nPlease Fill in Your Acount number: \n");
            Console.ForegroundColor=ConsoleColor.Green;
            string? account = Console.ReadLine();
            Console.ForegroundColor=ConsoleColor.DarkGray;
            Console.WriteLine("\nEnter Your Preferable Paybill Number: \n");
            Console.ForegroundColor=ConsoleColor.Green;
            string? paybill = Console.ReadLine();
            Console.ForegroundColor=ConsoleColor.DarkGray;
            Console.WriteLine("\nEnter Your Phone Number: \n");
            Console.ForegroundColor=ConsoleColor.Green;
            string? phone = Console.ReadLine();
            Console.ForegroundColor=ConsoleColor.White;

            UserPaybill user = new UserPaybill{AccountName=Bussinessname,AccountNo=account,PaybillNo=paybill,PhoneNo=phone};
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            string paybilljson = File.ReadAllText("ConsoleApp1/Database/paybill.json");
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

            

          if(IsRegistered){
            if(paybilljson != ""){

            List<UserPaybill>? paybills = JsonSerializer.Deserialize<List<UserPaybill>>(paybilljson);
            if(paybills is not null){
            paybills.Add(user);
            string paybillJson = JsonSerializer.Serialize(paybills,options);

            File.WriteAllText("ConsoleApp1/Database/paybill.json",paybillJson);
            Console.WriteLine("\n\nYour Paybill has been created successfully");

            }

            }else{
                List<UserPaybill> bill = new List<UserPaybill>();
                bill.Add(user);
                 string paybillJson = JsonSerializer.Serialize(bill,options);

            File.WriteAllText("ConsoleApp1/Database/paybill.json",paybillJson);
            Console.WriteLine("\n\nYour Paybill has been created successfully");







            }}else{

            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("\n\nohps!!, Invalid phone number entered please try again");
            Console.ForegroundColor=ConsoleColor.White;

            }
            // for remeberance purpose












            




        }
    }
}