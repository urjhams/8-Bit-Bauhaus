using System.Collections;
using UnityEngine;

public class GlobalEffectControl : MonoBehaviour
{
    public void FadeIn(CanvasGroup[] uiElement)
    {
        foreach (CanvasGroup element in uiElement)
            StartCoroutine(FadeCanvasGroup(element, element.alpha, 1));
    }

    public void FadeOut(CanvasGroup[] uiElement)
    {
        foreach (CanvasGroup element in uiElement)
            StartCoroutine(FadeCanvasGroup(element, element.alpha, 0));
    }
    //TODO: add a fade in, fade out function for game
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
