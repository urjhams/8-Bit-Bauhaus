using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPuzzleDragDrop : DragDrop
{
    private bool onStart = true;
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
        onStart = false;
        print("start");
    }

    protected override void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("correct " + gameObject.name) && !selected)
        {
            transform.position = other.gameObject.transform.position;
            locked = true;
            setLayerOrder(2);
            selected = !selected;
            GameManager.Room1.boxCorrectPeices.Add(gameObject.name);
        }
    }
}
