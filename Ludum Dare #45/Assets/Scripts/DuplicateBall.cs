using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateBall : MonoBehaviour
{
    public float bounceForceX = 5.0f;
    public float bounceForceY = 5.0f;
    public Camera cam;
    public GameObject score;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if MouseClick occurred while hovering the ball
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                //DuplicateBall Dball = GetComponent<DuplicateBall>();
                //if (Dball != null)
                //{
                //    Dball.duplicate(this.gameObject);
                //}
                // Everytime the ball is hit, the score increases by one
                
                score.GetComponent<KeepScore>().AddScore(1);
                hit.collider.attachedRigidbody.AddForce(
                    new Vector2(
                        (hit.collider.gameObject.transform.position.x - mousePos.x) * bounceForceX,
                        bounceForceY),
                    ForceMode2D.Impulse);
                Instantiate(ball, new Vector3(ball.transform.position.x * 3, ball.transform.position.y + 10, ball.transform.position.z), Quaternion.identity);
            }
        }
    }

}

    //public void duplicate(GameObject ball)
    //{
        // Instantiate at position (0, 0, 0) and zero rotation.
       // Instantiate(ball, new Vector3(ball.transform.position.x * 3, ball.transform.position.y+10, ball.transform.position.z), Quaternion.identity);
               
        //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    //}
//}
