using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuteColorMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (SpriteRenderer variableName in GetComponents<SpriteRenderer>())
        {
            variableName.color = Color.blue;
            print("blue");
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
