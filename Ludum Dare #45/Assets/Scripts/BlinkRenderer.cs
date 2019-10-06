using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkRenderer : MonoBehaviour
{
    private float timeSinceLastRendererToggle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastRendererToggle += Time.deltaTime;
        Renderer ballRenderer = this.GetComponent<Renderer>();
        if(timeSinceLastRendererToggle >= 0.1f)
        {
            timeSinceLastRendererToggle = 0.0f;
            ballRenderer.enabled = !ballRenderer.enabled;
        }
    }
}
