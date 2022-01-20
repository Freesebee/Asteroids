using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : IMediator
{
    private byte _hp = 3;
    public Ship Ship;
    public Text HPText;
    
    public void Notify(object sender, string action)
    {
        if(sender == Ship && action == MediatorConsts.GotHit)
        {
            reactOnGettingHit();        
        }
        else if(sender == Ship && action == MediatorConsts.GotDestroyed)
        {
            reactOnDestroy();        
        }
    }
    public void reactOnDestroy()
    {

    }
    public void reactOnGettingHit()
    {
        if (--_hp > 0)
            HPText.text = $"LIVES: {_hp}";
        else
            reactOnDestroy();
    }
}
