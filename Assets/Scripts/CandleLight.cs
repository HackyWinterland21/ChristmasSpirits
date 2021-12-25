using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : MonoBehaviour
{
    private Light candleFlame;

    // Start is called before the first frame update
    void Start()
    {
        candleFlame = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerLighting playerLighting = collision.gameObject.GetComponent<PlayerLighting>();
            if (playerLighting.PlayerCandleFlame)
            {
                candleFlame.enabled = true;
            }
        }
    }
}
