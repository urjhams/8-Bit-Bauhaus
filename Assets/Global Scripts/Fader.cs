using System.Collections;
using UnityEngine;


public class Fader : MonoBehaviour
{
    public CanvasGroup[] uiElement;

    private void Start()
    {
        foreach (CanvasGroup element in uiElement)
        {
            element.alpha = 0;
        }
        this.FadeIn();
    }

    public void FadeIn()
    {
        foreach (CanvasGroup element in uiElement)
            StartCoroutine(FadeCanvasGroup(element, element.alpha, 1));
    }

    public void FadeOut()
    {
        foreach (CanvasGroup element in uiElement)
            StartCoroutine(FadeCanvasGroup(element, element.alpha, 0));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {
        float timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
    }
}
