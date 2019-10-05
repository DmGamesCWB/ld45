using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBalls : MonoBehaviour
{
    public GameObject ball;
    public int numberOfBalls = 10;

    private int ballsInstantiated = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstantiateBall());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InstantiateBall()
    {
        yield return new WaitForSeconds(3);
        float xPosition = Random.Range(-8, 8);
        Instantiate(ball, new Vector3(xPosition, 6.0f, 0), Quaternion.identity);
        ballsInstantiated++;
        if(ballsInstantiated < numberOfBalls)
        {
            StartCoroutine(InstantiateBall());
        }
    }
}
