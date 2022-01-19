using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : IMediator
{
    private float _maxSpeed = 50f;
    private Ship ship;
    public void Notify(object sender, string action)
    {
        if(sender == ship && action == "gotHit")
        {
            reactOnGettingHit();        
        }
        else if(sender == ship && action == "gotDestroyed")
        {
            reactOnDestroy();        
        }
    }
    public void reactOnDestroy()
    {

    }
    public void reactOnGettingHit()
    {

    }
}
