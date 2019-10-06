using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHit : MonoBehaviour
{
    public int numCollision = 0;
    private const int kMaxCollisions = 3;
    public GameObject score;
    public AudioClip hitBrickSound;
    public float shrinkRate = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (numCollision >= kMaxCollisions)
        {
            Debug.Log("Destroying brick");
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Brick hit");
        score.GetComponent<KeepScore>().AddScore(1);
        AudioManager.inst.AudioPlay(hitBrickSound);
        numCollision++;
        transform.localScale = new Vector3(
            transform.localScale.x * shrinkRate,
            transform.localScale.y,
            transform.localScale.z);
    }
}
