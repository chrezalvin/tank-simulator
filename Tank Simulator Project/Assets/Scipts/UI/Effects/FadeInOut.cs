using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public float timeInterval = 0.5f;
    private bool fade = false;

    public CanvasGroup canvasGroup;

    void ToggleFade()
    {
        fade = !fade;
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            if (canvasGroup.alpha > 0)
                canvasGroup.alpha -= Time.unscaledDeltaTime / timeInterval;
            else
                ToggleFade();
        }
        else
        {
            if (canvasGroup.alpha < 1)
                canvasGroup.alpha += Time.unscaledDeltaTime / timeInterval;
            else
                ToggleFade();
        }
        
    }
}
