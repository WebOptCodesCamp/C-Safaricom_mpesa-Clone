using System;
using System.Text.Json;
using UserInfo;
using MyAgent;

namespace ControllerApp{
    public class DepositFromAgent{

        public static void DepositNow(string? phone , string? pin){

            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nEnter Agent no: \n");
            Console.ForegroundColor = ConsoleColor.Green;
            string? agentnumber = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nEnter store number: \n");
            Console.ForegroundColor = ConsoleColor.White;
            string? storenumber = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nEnter Amount to Deposit: \n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            int amount = int.Parse(Console.ReadLine() ?? string.Empty);

            if(amount <50){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\nOhps , You cannot deposit cash {amount} ksh which is below 50 shillings ");
            }else{
                int cost = 11;
                if(amount>100 && amount < 501){
                    cost = 29;

                }else if(amount>500 && amount <1500){
                    cost = 50;
                }else{
                    cost = 75;
                }

                string userjson = File.ReadAllText("ConsoleApp1/Database/Users.json");
                string agentjson = File.ReadAllText("ConsoleApp1/Database/Agent.json");


                if(userjson !="" && agentjson !=""){
                    var options = new JsonSerializerOptions();
                    options.WriteIndented = true;
                    List<User>? users = JsonSerializer.Deserialize<List<User>>(userjson);
                    List<MyAgentDetails>? agents = JsonSerializer.Deserialize<List<MyAgentDetails>>(agentjson);

                    if(users is not null && agents is not null){


                        // we want to check if agent number and store number entered is valid

                        bool IsvalidAgent = false;
                        string? agentphone ="";
                        string? agentname ="";





                        foreach(var agent in agents){

                         if(agent.AgentNo == agentnumber && agent.StoreNo == storenumber){
                            agentphone = agent.Phone;
                            agentname = agent.Name;
                            IsvalidAgent = true;
                            break;


                         }

                         


                        }



                        if(IsvalidAgent){
                            int count =0;
                            int me =0;
                            int his =0;

                            foreach(var user in users){
                                if(user.Phone == phone){
                                    me = count;
                                }else if(user.Phone == agentphone){
                                    his = count;
                                }

                            
                            count++;

                            }


                          

                            users[me].Balance += amount ;
                            users[his].Balance += (float)cost*(10/100);
                            string usersJson = JsonSerializer.Serialize(users,options);
                            File.WriteAllText("ConsoleApp1/Database/Users.json",usersJson);

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine($"\n\nConfirmed cash {amount} has been deposited to {agentname} , transaction cost is cash {0}.00 shillings and your account balance is cash {users[me].Balance}.00 shillings");
                          





                        }else{



                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\nOhps invalid storenumber or agentnumber entered");
                        }
                    }



                }




            }



        }
    }
}