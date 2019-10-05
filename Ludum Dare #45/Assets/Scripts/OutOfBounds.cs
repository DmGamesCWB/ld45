using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    public Camera cam;
    public float bottomOffsetGameOver = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if Ball is out of the scene and GameOver
        Vector3 ballPositionOnScreen = cam.WorldToScreenPoint(transform.position);
        if (ballPositionOnScreen.y < -bottomOffsetGameOver)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
