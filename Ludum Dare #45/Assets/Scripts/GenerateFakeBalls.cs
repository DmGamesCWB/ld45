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
        yPosition = 8;
        StartCoroutine(SpawnBalls(0.8f));
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
        
        StartCoroutine(SpawnBalls(waitTime));
    }
}
