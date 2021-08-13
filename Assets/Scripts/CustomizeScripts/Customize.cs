using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyItem(string item)
    {
        switch (item)
        {
            case "Soccer Ball":
                GameManager.Instance.currentBall = "Soccer Ball";
                break;
            case "Tennis Ball":
                GameManager.Instance.currentBall = "Tennis Ball";
                break;            
            case "Bowling Ball":
                GameManager.Instance.currentBall = "Bowling Ball";
                break;            
        }
    }
}
