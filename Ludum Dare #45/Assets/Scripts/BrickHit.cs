using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHit : MonoBehaviour
{
    public int numCollision = 0;
    private const int kMaxCollisions = 3;
    public GameObject score;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (numCollision >= kMaxCollisions)
        {
            score.GetComponent<KeepScore>().AddScore(1);
            Debug.Log("Destroying brick");
            Object.Destroy(this);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Brick hit");
        numCollision++;
    }
}
