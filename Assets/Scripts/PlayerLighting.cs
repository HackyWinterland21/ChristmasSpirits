using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLighting : MonoBehaviour
{
    [SerializeField] private bool playerCandleFlame = true;

    public bool PlayerCandleFlame
    {
        get
        {
            return playerCandleFlame;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
