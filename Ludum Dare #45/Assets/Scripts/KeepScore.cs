using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class KeepScore : MonoBehaviour
{
    public int score = 0;
    public int scoreGoal = 10;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelOverText;

    private bool levelEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score > 0)
        {
            scoreText.SetText("{0}", score);
        }

        if (score >= scoreGoal)
        {
            levelOverText.SetText("You've Got It!");
            levelEnded = true;
            StartCoroutine(LoadNextLevel());
        }
    }

    public void AddScore(int i)
    {
        score += i;
    }

    IEnumerator LoadNextLevel()
    {
        // Wait for 3 seconds and load next scene
        yield return new WaitForSeconds(3);
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        
        // Remember: Zero based count
        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void GameOver()
    {
        // Avoid reloading game after another event already triggered a loadScene
        if (!levelEnded)
        {
            levelOverText.SetText("Try Again!");
            levelEnded = true;
            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator RestartLevel()
    {
        // Wait for 3 seconds and reload
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
