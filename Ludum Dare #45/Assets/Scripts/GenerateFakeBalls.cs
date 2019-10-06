using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFakeBalls : MonoBehaviour
{
    public GameObject ball;
    public float xPosition;
    public float yPosition;
    public int numberOfBalls = 10;
    private int ballsInstantiated = 0;
    // Start is called before the first frame update
    void Start()
    {
        yPosition = 8;
        StartCoroutine(SpawnBalls(3.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnBalls(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        xPosition = Random.Range(-8, 8);
        Instantiate(ball, new Vector3(xPosition, yPosition, 0), Quaternion.identity);

        ballsInstantiated++;
        if (ballsInstantiated < numberOfBalls)
        {
            StartCoroutine(SpawnBalls(waitTime));
        }

    }
}
