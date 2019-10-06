using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFakeBalls : MonoBehaviour
{
    public GameObject ball;
    public float xPosition;
    public float yPosition;
    public float minSize = .5f;
    public float maxSize = 1.5f;
    public float timeBetweenSpawns = 0.8f;
    public float maxXForceOnSpawn = 5f;

    // Start is called before the first frame update
    void Start()
    {
        yPosition = 8;
        StartCoroutine(SpawnBalls(timeBetweenSpawns));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnBalls(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        xPosition = Random.Range(-8, 8);
        GameObject g = Instantiate(ball, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
        g.transform.localScale *= Random.Range(minSize, maxSize);
        g.GetComponent<Rigidbody2D>().AddForce(
                       new Vector2(Random.Range(-maxXForceOnSpawn, maxXForceOnSpawn), 0), ForceMode2D.Impulse);

       StartCoroutine(SpawnBalls(waitTime));
    }
}
