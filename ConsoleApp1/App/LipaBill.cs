using System;
using UserInfo;
using PaybillUser;
using System.Text.Json;

namespace ControllerApp{




    public class LipaBill{


        public static void  PayMyBill(string? phone , string? pin){
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.ForegroundColor= ConsoleColor.DarkGray;
            Console.WriteLine("Enter PayBill number: \n");
            Console.ForegroundColor= ConsoleColor.DarkYellow;
            string? paybill = Console.ReadLine();
            Console.ForegroundColor= ConsoleColor.DarkGray;
            Console.WriteLine("\nEnter Account number: \n");
            Console.ForegroundColor= ConsoleColor.DarkGreen;
            string? account = Console.ReadLine();
            Console.ForegroundColor= ConsoleColor.DarkGray;
            Console.WriteLine("\nEnter Amount\n");
            Console.ForegroundColor= ConsoleColor.DarkBlue;
            int amount = int.Parse(Console.ReadLine() ?? string.Empty);

            int cost =0;

            if(amount > 100){
                cost = 20;
            }

            if(amount <10){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nOhps!! the Amount Entered is Less than minimum");
                return;
            }else{
                string paybilljson = File.ReadAllText("ConsoleApp1/Database/Paybill.json");
                string usersjson = File.ReadAllText("ConsoleApp1/Database/Users.json");

                if(paybilljson != "" && usersjson != ""){

                    List<UserPaybill>?  paybilllist = JsonSerializer.Deserialize<List<UserPaybill>>(paybilljson);
                    List<User>? users = JsonSerializer.Deserialize<List<User>>(usersjson);
                    var options = new JsonSerializerOptions();
                    options.WriteIndented = true;

                    if(paybilllist is not null && users is not null){
                        bool IsvalidPaybill = false;
                        string? accountname = "";
                        string? paybillphone = "";
                        foreach (var payb in paybilllist)
                        {
                            if(payb?.PaybillNo == paybill && payb?.AccountNo==account){
                                IsvalidPaybill = true;
                                accountname = payb?.AccountName;
                                paybillphone =payb?.PhoneNo;
                                break;
                            }
                            
                        }

                        if(IsvalidPaybill){
                            int count =0;
                            int me =0;
                            int his =0;

                            foreach(var user in users){
                                if(user.Phone == phone){
                                    me = count;
                                }else if(user.Phone == paybillphone){
                                    his = count;
                                }


                                count++;
                            }
                            if(users[me].Balance < amount + cost){

                                Console.ForegroundColor=ConsoleColor.Red;
                                Console.WriteLine($"\n\nOhps Insufficient fund in your account to pay cash {amount} ksh");
                            }else{

                                users[me].Balance -= amount+cost;
                                users[his].Balance += amount;
                                string usersJson = JsonSerializer.Serialize(users,options);
                                File.WriteAllText("ConsoleApp1/Database/Users.json",usersJson);

                            Console.ForegroundColor=ConsoleColor.Green;
                            Console.WriteLine($"\n\nConfirm cash {amount} ksh sent to {accountname} transaction cost is {cost} ksh and your account balance is {users[me].Balance}");


                            }






                        }else{

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\nOhps , Invalid account number or paybill entered");




                        }






                    }






                }









            }






        }
    }
}