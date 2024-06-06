using System;

namespace Graphic{

   public class Mygraphic{

public  string mpesa =@"
███╗   ███╗██████╗ ███████╗███████╗ █████╗ 
████╗ ████║██╔══██╗██╔════╝██╔════╝██╔══██╗
██╔████╔██║██████╔╝█████╗  ███████╗███████║
██║╚██╔╝██║██╔═══╝ ██╔══╝  ╚════██║██╔══██║
██║ ╚═╝ ██║██║     ███████╗███████║██║  ██║
╚═╝     ╚═╝╚═╝     ╚══════╝╚══════╝╚═╝  ╚═╝
                                           
";

public  string safaricom = @"
 __        __            _                     
/ _\ __ _ / _| __ _ _ __(_) ___ ___  _ __ ___  
\ \ / _` | |_ / _` | '__| |/ __/ _ \| '_ ` _ \ 
_\ \ (_| |  _| (_| | |  | | (_| (_) | | | | | |
\__/\__,_|_|  \__,_|_|  |_|\___\___/|_| |_| |_|
                                               
";
        public static void GraphicTxt(){

            Console.ForegroundColor=ConsoleColor.Magenta;
           

            string graphic =@"
 __        __   _      ___        _   
 \ \      / /__| |__  / _ \ _ __ | |_ 
  \ \ /\ / / _ \ '_ \| | | | '_ \| __|
   \ V  V /  __/ |_) | |_| | |_) | |_ 
    \_/\_/ \___|_.__/ \___/| .__/ \__|
                           |_|        
";
     Console.WriteLine($"\t{graphic}");
     
     Console.ForegroundColor=ConsoleColor.White;
        }
    }
}