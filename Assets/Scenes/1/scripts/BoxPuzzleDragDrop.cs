using System;
using UnityEngine;

public class BoxPuzzleDragDrop : DragDrop
{
    [HideInInspector] public Collider2D containerCollider;
    private Vector2 initPosition;
    protected override void Start()
    {
        base.Start();
        initPosition = gameObject.transform.position;
        containerCollider = GameObject.Find("puzzle frame").transform.GetComponent<Collider2D>();
        foreach (var item in GameManager.Room1.boxPeices)
        {
            if (item.Item1.Equals(name))
            {
                transform.position = item.Item2;
            }
        }
    }

    protected override void Update()
    {
        base.Update();
        if (selected)
        {
            if (!locked)
                setLayerOrder(10);
        }
        else
        {
            bool correct = false;
            foreach (var element in GameManager.Room1.addedPeice)
            {
                if (element.Equals(name))
                    correct = true;
            }
            if (!correct)
            {
                setLayerOrder(4);
                locked = false;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (containerCollider.bounds.Contains(gameObject.GetComponent<Collider2D>().bounds.min) &&
            containerCollider.bounds.Contains(gameObject.GetComponent<Collider2D>().bounds.max))
            {
                bool exist = false;
                foreach (var item in GameManager.Room1.boxPeices)
                {
                    if (item.Item1.Equals(name))
                        exist = true;
                }
                if (!exist)
                    GameManager.Room1.boxPeices.Add(Tuple.Create(name, transform.position));
                setLayerOrder(2);
            }
            else
            {
                transform.position = initPosition;
                RemoveFromBox(name);
            }
            correctingPuzzle(name);
        }
    }
    protected override void OnTriggerStay2D(Collider2D other)
    {
        base.OnTriggerStay2D(other);
        if (other.gameObject.name.Equals("correct " + gameObject.name) && !selected)
        {
            setLayerOrder(2);
        }
    }
    private void setLayerOrder(int order)
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = order;
    }
    private void correctingPuzzle(string name)
    {
        bool exist = false;
        try
        {
            foreach (var item in GameManager.Room1.boxPeices)
            {
                if (item.Item1.Equals(name))
                {
                    if (!exist)
                    {
                        exist = true;
                    }
                    else
                    {
                        GameManager.Room1.boxPeices.Remove(item);
                    }
                }
            }
        }
        catch { }
    }
    private void RemoveFromBox(string name)
    {
        try
        {
            foreach (var item in GameManager.Room1.boxPeices)
            {
                if (item.Item1.Equals(name))
                {
                    GameManager.Room1.boxPeices.Remove(item);
                }
            }
        }
        catch { }
    }

    public override void clickingSound()
    {
        try
        {
            GameObject.Find("Background").GetComponent<AudioSource>().Play();
        }
        catch { }
    }
}
