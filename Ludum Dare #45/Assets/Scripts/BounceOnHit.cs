using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOnHit : MonoBehaviour
{
    public float bounceForceX = 5.0f;
    public float bounceForceY = 5.0f;
    public Camera cam;
    public GameObject score;
    public bool keepScore = true;

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
                if (!hit.collider.CompareTag("Fake"))
                {
                    // Everytime the ball is hit, the score increases by one
                    if (keepScore)
                    {
                        score.GetComponent<KeepScore>().AddScore(1);
                    }
                    hit.collider.attachedRigidbody.AddForce(
                        new Vector2(
                            (hit.collider.gameObject.transform.position.x - mousePos.x) * bounceForceX,
                            bounceForceY),
                        ForceMode2D.Impulse);

                    // Everytime the ball is hit, the score increases by one
                    score.GetComponent<KeepScore>().AddScore(1);
                    hit.collider.attachedRigidbody.AddForce(
                        new Vector2(
                            (hit.collider.gameObject.transform.position.x - mousePos.x) * bounceForceX,
                            bounceForceY),
                        ForceMode2D.Impulse);
                }
            }
        }
    }
}
