using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    
    public int stardust;
    
    public GameData()
    {
        
        stardust = GameManager.Instance.dust;
        
    }
    
}
