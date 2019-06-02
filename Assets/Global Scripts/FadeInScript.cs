using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInScript : MonoBehaviour
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
        for (float f = 0.05f; f <= 1; f += 0.05f) {
            Color color = rend.material.color;
            color.a = f;
            rend.material.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void startFading() {
        StartCoroutine("FadeIn");
    }
}
