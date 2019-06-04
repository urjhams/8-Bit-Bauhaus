using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalEffectControl : MonoBehaviour
{
    // ---------------- fading in canvas
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

    // ------------------ Fading game object 's sprite
    SpriteRenderer getSpriteRenderer(GameObject obj)
    {
        return obj.GetComponent<SpriteRenderer>();
    }
    IEnumerator FadeOut(SpriteRenderer rend)
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color color = rend.material.color;
            color.a = f;
            rend.material.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void startFadingOut(GameObject obj)
    {
        SpriteRenderer rend = getSpriteRenderer(obj);
        StartCoroutine(FadeOut(rend));
    }

    IEnumerator FadeIn(SpriteRenderer rend)
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color color = rend.material.color;
            color.a = f;
            rend.material.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void startFadingIn(GameObject obj)
    {
        foreach (var rend in obj.GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = rend.material.color;
            color.a = 0f;
            rend.material.color = color;
            StartCoroutine(FadeIn(rend));
        }
    }

    public void FadeToLevel(string name)
    {
        // var animator = GameObject.Find("room changer").GetComponent<Animator>();
        // animator.Play("ScreenFadeOut");
        SceneManager.LoadScene(name);
        Helper.setMouseStatus(MouseStatus.Free);
    }
}
