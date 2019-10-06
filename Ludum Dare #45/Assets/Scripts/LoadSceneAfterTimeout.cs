using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterTimeout : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene("MainMenu");
    }
}
