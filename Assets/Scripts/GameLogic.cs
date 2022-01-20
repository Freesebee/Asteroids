using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : IMediator
{
    private byte _hp = 3;
    public Ship Ship;
    public Text HPText;
    public Text GameOverText;
    
    public void Notify(object sender, string action)
    {
        if(sender == Ship)
        {
            if(action == MediatorConsts.GotHit)
            {
                reactOnShipGettingHit();        
            }
        }
        else if(sender is Asteroid)
        {
            if(action == MediatorConsts.GotDestroyed)
            {
                reactOnDestroy(sender as SpaceObject);        
            }
        }
    }
    public void reactOnDestroy(SpaceObject spaceObject)
    {
        GameObject.Destroy(spaceObject.GameObject);
    }
    public void reactOnShipGettingHit()
    {
        HPText.text = $"LIVES: {--_hp}";
        if (_hp <= 0)
        {
            Debug.LogError("GAMEOVER");
            GameOverText.enabled = true;
            Time.timeScale = 0;
        }
    }
}
