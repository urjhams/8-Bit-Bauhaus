﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public bool locked = false;
    private bool selected;
    void Update()
    {
        if (selected && !locked) {
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPosition.x, cursorPosition.y);
        }
        if (Input.GetMouseButtonUp(0)) {
            selected = false;
        }
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            selected = true;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("correct " + gameObject.name) && !selected) {
            transform.position = other.gameObject.transform.position;
            locked = true;
            setLayerOrder(2);
            selected = !selected;
        }
    }
    private void setLayerOrder(int order) {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = order;
    }
}
