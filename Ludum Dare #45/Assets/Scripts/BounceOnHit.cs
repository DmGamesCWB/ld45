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
    public float shrinkRate = 1.0f; // By default do not shrink

    public AudioClip bounceSound;

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

            // If a gameObject collides with the Raycast in MousePosition
            if (hit.collider != null)
            {
                // If the GameObject in this position does not have a "Fake" tag
                if (!hit.collider.CompareTag("Fake") && 
                    // If the instance of the Object is the same of the Object this component is attached to
                    hit.collider.gameObject.GetInstanceID() == gameObject.GetInstanceID())
                {
                    AudioManager.inst.AudioPlay(bounceSound);

                    // Shrink ball
                    transform.localScale *= shrinkRate;

                    // Everytime the ball is hit, the score increases by one
                    if (keepScore)
                    {
                        score.GetComponent<KeepScore>().AddScore(1);
                    }

                    // If it is a object of type, it must be destroyed after click
                    if (hit.collider.CompareTag("Blink"))
                    {
                        Destroy(hit.collider.gameObject);
                    }

                    hit.collider.attachedRigidbody.AddForce(
                        new Vector2(
                            (hit.collider.gameObject.transform.position.x - mousePos.x) * bounceForceX,
                            bounceForceY),
                        ForceMode2D.Impulse);

                    // Everytime the ball is hit, the score increases by one
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
