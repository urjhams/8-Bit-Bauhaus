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
            for (int index = 0; index < triggerObjects.Length; index++)
            {
                if (triggerObjects[index] != null)
                {
                    switch (triggerObjects[index].name)
                    {
                        case "bird food_collect":
                            if (!GameManager.Room1.birdFoodGave)
                                GameManager.Room1.birdFood = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
