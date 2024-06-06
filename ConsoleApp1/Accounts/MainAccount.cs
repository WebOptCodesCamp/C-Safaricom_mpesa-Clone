using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace MainAccount{
class Acc{
public static void Account(int slt){

if(slt==1){
   
    SignUp.createAccount();

}else if(slt==2){
    SignIn.LogIn();
}else{


    Safaricom.SafDash();
}



}

}


}