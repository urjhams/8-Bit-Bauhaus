using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnClick : MonoBehaviour
{
    public AudioSource audioS;
    private void OnMouseDown() {
        audioS.Play();
    }
}
