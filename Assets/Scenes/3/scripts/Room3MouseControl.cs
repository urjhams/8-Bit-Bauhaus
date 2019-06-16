using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3MouseControl : GlobalMouseControl
{
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        if (IsMouseOverUI())
            return;
        switch (currentHover)
        {
            case "poster1":
                detailInteraction(
                    "InteractContainer_poster1",
                    "Sophia",
                    "Looks like some interesting information.");
                break;
            case "poster2":
                detailInteraction(
                    "InteractContainer_poster2",
                    "Sophia",
                    "Hmm...looks like maths. But maybe it's useful.");
                break;
            case "locker":
                if (GameObject.Find("locker").GetComponent<SpriteRenderer>().sprite.name == "Locker_close")
                {
                    detailInteraction(
                        "InteractContainer_locker",
                        "Sophia",
                        "R.Schmidt! That must be the former locker of my grandma. Maybe i can find something inside.");
                    Helper.inDetail = false;
                }
                else
                {
                    detailInteraction(
                        "InteractContainer_locker",
                        "Sophia",
                        "Oh, i think i know what the key is for.");
                    Helper.inDetail = false;
                }
                break;
            case "lock":
                detailInteraction(
                    "InteractContainer_lock",
                    "Sophia",
                    "I need to find the right code to open it.");
                break;
            default:
                break;
        }
    }
}
