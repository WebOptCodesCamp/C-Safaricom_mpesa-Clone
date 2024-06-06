using System;

namespace SafaricomApi{

    public class Apis{


  public static void MainApi(int slt){

    Console.Clear();

    if (slt==1)
    {
CreateAgent.NewAgent();
        
    }else if(slt==2){
PaybillApp.GetPaybill();
    }else{

MyTill.CreateTill();

    }





  }



    }




}