using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    public Camera cam;
    public float bottomOffsetGameOver = 100f;
    public AudioClip gameOverSound;
    private bool gameOverSoundPlayed = false;
    public bool updside = false;

    public GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if Ball is out of the scene and GameOver
        Vector3 ballPositionOnScreen = cam.WorldToScreenPoint(transform.position);

        if (updside)
        {
            if (ballPositionOnScreen.y > bottomOffsetGameOver)
            {
                score.GetComponent<KeepScore>().GameOver();
                if (!gameOverSoundPlayed)
                {
                    AudioManager.inst.AudioPlay(gameOverSound);
                    gameOverSoundPlayed = true;
                }
            }
        }
        else if (ballPositionOnScreen.y < -bottomOffsetGameOver)
        {
            score.GetComponent<KeepScore>().GameOver();
            if (!gameOverSoundPlayed)
            {
                AudioManager.inst.AudioPlay(gameOverSound);
                gameOverSoundPlayed = true;
            }
        }
    }
}
