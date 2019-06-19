﻿using UnityEngine;

public class ColliderRecognize : MonoBehaviour
{
    public Collider2D col;
    /// <summary>
    /// Called every frame while the mouse is over the GUIElement or Collider.
    /// </summary>
    void OnMouseOver()
    {
        print(col.name);
        GameManager.currentOverGameObjectName = col.name;
    }
    /// <summary>
    /// Called when the mouse is not any longer over the GUIElement or Collider.
    /// </summary>
    void OnMouseExit()
    {
        GameManager.currentOverGameObjectName = "";
    }
}
