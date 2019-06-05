using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    [HideInInspector] public bool locked = false;
    [HideInInspector] public bool selected;
    private Vector2 initPosition;
    private Collider2D containerCollider;
    protected virtual void Start()
    {
        initPosition = gameObject.transform.position;
        containerCollider = gameObject.transform.parent.GetComponent<Collider2D>();
    }
    protected virtual void Update()
    {
        if (selected && !locked)
        {
            setLayerOrder(4);
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPosition.x, cursorPosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
            if (containerCollider.bounds.Contains(gameObject.GetComponent<Collider2D>().bounds.min) &&
            containerCollider.bounds.Contains(gameObject.GetComponent<Collider2D>().bounds.max))
            {
                setLayerOrder(2);
            }
            else
            {
                transform.position = initPosition;
            }
        }
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            selected = true;
    }
    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("correct " + gameObject.name) && !selected)
        {
            transform.position = other.gameObject.transform.position;
            locked = true;
            setLayerOrder(2);
            selected = !selected;
        }
    }
    public void setLayerOrder(int order)
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = order;
    }
}
