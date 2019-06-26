using System.Collections;
using UnityEngine;

public class ObjectFadeIn : MonoBehaviour
{
    SpriteRenderer rend;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Color color = rend.material.color;
        color.a = 0f;
        rend.material.color = color;
    }
    
    IEnumerator FadeIn() {
        float betwwenTime = 0.05f;
        for (float f = 0; f <= 1.05f; f += betwwenTime)
        {
            Color color = rend.material.color;
            color.a = f;
            rend.material.color = color;
            yield return new WaitForSeconds(betwwenTime);
        }
    }

    public void startFading()
    {
        StartCoroutine("FadeIn");
    }
}
