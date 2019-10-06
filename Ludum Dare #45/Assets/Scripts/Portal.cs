using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject ball;
    public GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float offset = 2;
        if (this.name == "Left Wall")
        {
            offset *= -1;
        }
        Debug.Log("Hit " + this.name + " portal");
        Debug.Log("updating ball");

        ball.transform.position = new Vector3(this.transform.position.x * -1 + offset, ball.transform.position.y, 0);
        score.GetComponent<KeepScore>().AddScore(1);
    }
}
