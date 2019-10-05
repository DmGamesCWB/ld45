using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFakeBalls : MonoBehaviour
{
    public GameObject ball;
    public float xPosition;
    public float yPosition;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchBall", 3.0f, 8.0f);
        yPosition = 8;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LaunchBall()
    {
        xPosition = Random.Range(-8, 8);
         
        Instantiate(ball, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
    }
}
