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

    // Update is called once per frame
    void Update()
    {
        // Show text after first mouse click
        if (Input.GetMouseButtonDown(0))
        {
            clickEvents++;
            if (clickEvents >= clicksToWait)
            {
                TextMeshProUGUI textmeshPro = GetComponent<TextMeshProUGUI>();
                textmeshPro.text = text;
            }
        }
    }
}
