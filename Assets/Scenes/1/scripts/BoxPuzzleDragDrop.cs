﻿using System;
using UnityEngine;
using System.Collections.Generic;

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
        if (selected && !locked)
            setLayerOrder(4);
        if (Input.GetMouseButtonUp(0))
        {
            if (containerCollider.bounds.Contains(gameObject.GetComponent<Collider2D>().bounds.min) &&
            containerCollider.bounds.Contains(gameObject.GetComponent<Collider2D>().bounds.max))
            {
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
        try {
            foreach (var item in GameManager.Room1.boxPeices)
            {
                if (item.Item1.Equals(name)) {
                    GameManager.Room1.boxPeices.Remove(item);
                }
            }
        } catch {}
    }
}
