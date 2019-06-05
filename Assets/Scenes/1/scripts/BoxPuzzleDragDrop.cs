using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPuzzleDragDrop : DragDrop
{
    protected override void Start()
    {
        base.Start();
        foreach (var name in GameManager.Room1.boxCorrectPeices)
        {
            if (gameObject.name.Equals(name))
            {
                transform.position = GameObject.Find("correct " + gameObject.name).transform.position;
            }
        }
        foreach (var item in GameManager.Room1.boxPeices)
        {
            if (item.Item1.Equals(name))
            {
                transform.position = item.Item2;
            }
        }
        print("start");
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetMouseButtonUp(0))
        {
            if (containerCollider.bounds.Contains(gameObject.GetComponent<Collider2D>().bounds.min) &&
            containerCollider.bounds.Contains(gameObject.GetComponent<Collider2D>().bounds.max))
            {
                GameManager.Room1.boxPeices.Add(Tuple.Create(name, transform.position));
            }
        }
    }

    protected override void OnTriggerStay2D(Collider2D other)
    {
        base.OnTriggerStay2D(other);
        if (other.gameObject.name.Equals("correct " + gameObject.name) && !selected)
        {
            GameManager.Room1.boxCorrectPeices.Add(gameObject.name);
        }
    }
}
