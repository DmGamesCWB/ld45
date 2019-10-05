using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeRigidbodyOnClick : MonoBehaviour
{
    public int clicksToWait = 3;
    private int clickEvents = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickEvents++;
            if(clickEvents >= clicksToWait)
            {
                GetComponent<Rigidbody2D>().WakeUp();
            }
        }
    }
}
