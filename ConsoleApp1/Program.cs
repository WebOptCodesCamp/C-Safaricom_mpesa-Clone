using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphic;
using Options;


class App{

    public static void Main(string[] args){
        
        char con ='y';
        Console.Clear();
       while(con=='y'){
       Mygraphic.GraphicTxt();
       Myoptions.Choice();
       Console.Write("\nDo you Want to continue? [y/n] ");
       con=char.Parse(Console.ReadLine() ?? string.Empty);
       switch (con)
       {
        case'y':
        Console.Clear();
        break;
        default:
        break;
       }

       }
    }
}