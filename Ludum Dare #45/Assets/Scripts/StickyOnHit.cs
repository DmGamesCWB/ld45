using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyOnHit : MonoBehaviour
{
    public float bounceForceX = 5.0f;
    public float bounceForceY = 5.0f;
    public Camera cam;
    public GameObject score;

    private bool holdingBall = false;
    private Vector3 offset; // offset of holding point from center of Ball

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Update ball position to mouse position
        if (holdingBall)
        {
            transform.position = new Vector3(mousePos.x - offset.x, mousePos.y - offset.y, 0);
        }

        // Check if MouseClick occurred while hovering the ball
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                // If not holding the ball yet
                if (holdingBall)
                {
                    holdingBall = false;
                    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                    // Everytime the ball is released, the score increases by one
                    score.GetComponent<KeepScore>().AddScore(1);
                    hit.collider.attachedRigidbody.AddForce(
                        new Vector2(
                            (hit.collider.gameObject.transform.position.x - mousePos.x) * bounceForceX,
                            bounceForceY),
                        ForceMode2D.Impulse);
                }
                else
                {
                    offset = new Vector3(
                        mousePos2D.x - transform.position.x, 
                        mousePos2D.y - transform.position.y, 
                        0);
                    holdingBall = true;
                    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                }
            }
        }
    }
}
