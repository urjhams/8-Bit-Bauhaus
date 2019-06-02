using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFader : GlobalEffectControl
{
        public CanvasGroup[] uiElement;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Screen.SetResolution(1366, 720, false);
    }
    void Start()
    {
        foreach (CanvasGroup element in uiElement)
        {
            element.alpha = 0;
        }
        this.FadeIn(uiElement);
    }
}
