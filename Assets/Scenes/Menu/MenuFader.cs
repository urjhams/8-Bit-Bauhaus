using UnityEngine;

public class MenuFader : GlobalEffectControl
{
        public CanvasGroup[] uiElement;

    void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
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
