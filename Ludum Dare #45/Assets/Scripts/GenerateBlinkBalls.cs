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
    // Start is called before the first frame update
    void Start()
    {
        // Start function SpawnBlinkBalls as a coroutine.
        yPosition = 11.0f;
        StartCoroutine(SpawnBlinkBalls(3.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // every 5 seconds instantiate blinked Balls
    private IEnumerator SpawnBlinkBalls(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        xPosition = Random.Range(-8, 8);
        Instantiate(ball, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
        if (ball != null) {
            Renderer ballRenderer = ball.GetComponent<Renderer>();
            for (int i = 0; i < 6; ++i)
            {
                if (ballRenderer != null) {
                    ballRenderer.enabled = false;
                    yield return new WaitForSeconds(0.1f);
                }
                if (ballRenderer != null) {
                    ballRenderer.enabled = true;
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
        
        ballsInstantiated++;
        if (ballsInstantiated < numberOfBalls)
        {
            StartCoroutine(SpawnBlinkBalls(waitTime));
        }
    }
}
