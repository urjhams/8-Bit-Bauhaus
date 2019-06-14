using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowlClickHandle : TurnOnObjectTrigger
{
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        if (triggerObjects != null)
        {
            foreach (var item in triggerObjects)
            {
                switch (item.name)
                {
                    case "bird food_collect":
                        GameManager.Room1.birdFood = true;
                        break;
                    case "the box_discover":
                        GameManager.Room1.boxOnTable = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
