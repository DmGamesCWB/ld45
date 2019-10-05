using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    void SetHintText()
    {
        TextMeshProUGUI textmeshPro = GetComponent<TextMeshProUGUI>();

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

    // Update is called once per frame
    void Update()
    {
        // Show text after first mouse click
        if (Input.GetMouseButtonDown(0))
        {
            clickEvents++;
            if (clickEvents >= clicksToWait)
            {
                SetHintText();
            }
        }
    }
}
