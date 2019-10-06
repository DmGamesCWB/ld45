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
    public AudioClip duplicateSound;

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
                // Everytime the ball is hit, the score increases by one
                if (!hit.collider.CompareTag("Fake") &&
                    // If the instance of the Object is the same of the Object this component is attached to
                    hit.collider.gameObject.GetInstanceID() == gameObject.GetInstanceID())
                {
                    score.GetComponent<KeepScore>().AddScore(1);
                    hit.collider.attachedRigidbody.AddForce(
                        new Vector2(
                            (hit.collider.gameObject.transform.position.x - mousePos.x) * bounceForceX,
                            bounceForceY),
                        ForceMode2D.Impulse);
                    Instantiate(ball, new Vector3(ball.transform.position.x + 0.3f, ball.transform.position.y + 0.3f, ball.transform.position.z), Quaternion.identity);
                    AudioManager.inst.AudioPlay(duplicateSound);
                }
            }
        }
    }

}
