using UnityEngine;

public class SubMenuFader : GlobalEffectControl
{
    public CanvasGroup[] uiElement;
    private bool showUp = false;
    void Start()
    {
        foreach (CanvasGroup element in uiElement)
        {
            element.alpha = 0;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!showUp)
            {
                foreach (CanvasGroup element in uiElement)
                {
                    element.alpha = 0;
                }
                this.FadeIn(uiElement);
                Helper.hideInventory();
            }
            else
            {
                this.FadeOut(uiElement);
                Helper.showInventory();
            }
            showUp = !showUp;
        }

    }
}
