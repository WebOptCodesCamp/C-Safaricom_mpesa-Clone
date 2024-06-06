using System;
using System.Threading;
using System.Threading.Tasks;
using UserInfo;
using System.Text.Json;
namespace ControllerApp{

public class Send{

    public static void SendMoney(string? phone, string? pin){


        Console.Clear();
        Console.WriteLine("\n\n\n");
        Console.ForegroundColor= ConsoleColor.DarkGray;
        Console.WriteLine("\nEnter the phone to send Money to: \n");
        Console.ForegroundColor= ConsoleColor.DarkBlue;
        string? phone2 = Console.ReadLine();
        Console.ForegroundColor= ConsoleColor.DarkGray;
        Console.WriteLine("\nEnter Amout to send: \n");
        Console.ForegroundColor= ConsoleColor.DarkBlue;
        float? amount = float.Parse(Console.ReadLine() ?? string.Empty);
        Console.ForegroundColor= ConsoleColor.DarkGray;
        Console.WriteLine("\n\nPlease Wait while processing your request.....");
        Thread.Sleep(450);
        if(phone2 == phone){

        Console.ForegroundColor= ConsoleColor.DarkRed;
        Console.WriteLine("\n\nYou!!,cannot send money to your ownn phone number");

        }else{
            string usersjson = File.ReadAllText("ConsoleApp1/Database/Users.json");
            if(usersjson != ""){
             List<User>?  users = JsonSerializer.Deserialize<List<User>>(usersjson);
             if(users is not null){
            bool IsvalidPhone = false;
             foreach (var user in users)
             {
                if(user.Phone == phone2){

                    IsvalidPhone = true;
                    break;
                }
                
             }
             if(IsvalidPhone){

                int count =0;
                int mypos =0;
                int hispos =0;

                foreach(var user in users){

                    if(user.Phone==phone){
                        mypos = count;
                    }else if(user.Phone == phone2){
                        hispos = count;


                    }
                    count++;
                }
                float cost = 0;
                if(amount>100 && amount <201){
                    cost= 7;
                }else if (amount>200 && amount <400){
                    cost = 15;
                }else{
                    cost = 100;
                }
                 if(amount <1){

                     Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n\nCannot send cash {amount} to {users[hispos].Name} because the amount entered is below the minimum");

                 }else{
                if(users[mypos].Balance < amount + cost){
                     Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n\nOhps insufficient fund in your account to send cash {amount} to {users[hispos].Name}");
                }else{
                
                users[mypos].Balance -= (int)(amount+cost);
                users[hispos].Balance += (int)amount;
                var options = new JsonSerializerOptions();
                options.WriteIndented = true;
                string updateuser = JsonSerializer.Serialize(users,options);
                File.WriteAllText("ConsoleApp1/Database/Users.json",updateuser);
                Console.ForegroundColor = ConsoleColor.DarkGreen; 
                Console.WriteLine($"\n\nSuccessfully Sent cash {amount} ksh to {users[hispos].Name} , transaction cost is {cost} and your acccount balance is {users[mypos].Balance}");
                
                
                }}

            





             }else{

        Console.ForegroundColor= ConsoleColor.DarkRed;
        Console.WriteLine("\n\nOhps!!, The number entered is Invalid");
             }
                
             }
                
            }



        }







    }
}

}