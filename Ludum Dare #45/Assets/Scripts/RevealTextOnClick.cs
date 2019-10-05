using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RevealTextOnClick : MonoBehaviour
{
    public int clicksToWait = 2;
    private int clickEvents = 0;

    public string text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void EraseHintText()
    {
        TextMeshProUGUI textmeshPro = GetComponent<TextMeshProUGUI>();
        textmeshPro.text = "";
    }

    void SetHintText(int levelId)
    {
        TextMeshProUGUI textmeshPro = GetComponent<TextMeshProUGUI>();

        if (levelId == 1)
        {
            textmeshPro.text = "1 - Click ";
        }
        else if (levelId == 2)
        {
            switch (clickEvents)
            {
                case 1:
                    textmeshPro.text += "2 - Click, ";
                    break;
                case 2:
                    textmeshPro.text += "click and ";
                    break;
                case 3:
                    textmeshPro.text += "click";
                    break;
                case 4:
                    //this.EraseHintText();
                    break;
            }
        }
    }

    int GetLevel()
    {
        Debug.Log("GetLevel()");
        string levelName = SceneManager.GetActiveScene().name;

        int levelId = 0;
        switch (levelName)
        {
            case "Level_1":
                levelId = 1;
                break;
            case "Level_2":
                levelId = 2;
                break;
        }
        Debug.Log("Return levelID " + levelId);

        return levelId;
    }

    // Update is called once per frame
    void Update()
    {
        // Show text after first mouse click
        if (Input.GetMouseButtonDown(0))
        {
            clickEvents++;
        

            if (clickEvents >= clicksToWait)
            {
                SetHintText(GetLevel());
            }
        }
    }
}
