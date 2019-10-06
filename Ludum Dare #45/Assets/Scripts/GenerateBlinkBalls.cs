using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlinkBalls : MonoBehaviour
{
    public GameObject ball;
    public float xPosition;
    public float yPosition;
    public int numberOfBalls = 10;
    private int ballsInstantiated = 0;

    public float maxTimeBetweenSpawns = 5.0f;
    public float minSize = 0.5f;
    public float maxSize = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Start function SpawnBlinkBalls as a coroutine.
        yPosition = 11.0f;
        StartCoroutine(SpawnBlinkBalls(Random.Range(3.0f, maxTimeBetweenSpawns)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // every x seconds instantiate blinked Balls
    private IEnumerator SpawnBlinkBalls(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        xPosition = Random.Range(-8, 8);
        GameObject g = Instantiate(ball, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
        g.GetComponent<Rigidbody2D>().WakeUp();
        g.transform.localScale *= Random.Range(minSize, maxSize);

        ballsInstantiated++;
        if (ballsInstantiated < numberOfBalls)
        {
            StartCoroutine(SpawnBlinkBalls(waitTime));
        }
        
    }
}
