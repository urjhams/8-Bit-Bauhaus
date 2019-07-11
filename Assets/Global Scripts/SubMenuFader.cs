using UnityEngine;

public class SubMenuFader : GlobalEffectControl
{
    public CanvasGroup[] uiElement;
    public Canvas menuCanvas;
    private bool showUp = false;
    void Start()
    {
        foreach (CanvasGroup element in uiElement)
        {
            element.alpha = 0;
        }
        menuCanvas.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!showUp)
            {
                menuCanvas.enabled = true;
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
                menuCanvas.enabled = false;
            }
            showUp = !showUp;
        }

    }
}
