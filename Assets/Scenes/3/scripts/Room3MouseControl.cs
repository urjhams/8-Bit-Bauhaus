using UnityEngine;
using UnityEngine.UI;

public class Room3MouseControl : GlobalMouseControl
{
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        switch (currentHover)
        {
            case "poster1":
                detailInteraction(
                    "InteractContainer_poster1",
                    "Sophia:",
                    "\"Looks like some interesting information.\"");
                break;
            case "poster2":
                detailInteraction(
                    "InteractContainer_poster2",
                    "Sophia:",
                    "\"Hmm...looks like maths. But maybe it's useful.\"");
                break;
            case "locker":
                if (GameObject.Find("locker").GetComponent<SpriteRenderer>().sprite.name == "Locker_close")
                {
                    detailInteraction(
                        "InteractContainer_locker",
                        "Sophia:",
                        "\"R.Schmidt! That must be the former locker of my grandma. Maybe i can find something inside.\"");
                }
                else
                {
                    detailInteraction(
                        "InteractContainer_locker",
                        "Sophia:",
                        "\"Oh, i think i know what the key is for.\"");
                }
                break;
            case "lock":
                endDetailView();
                try {
                    interactContainer.SetActive(true);
                } catch {}
                detailInteraction(
                    "InteractContainer_lock",
                    "Sophia:",
                    "\"I need to find the right code to open it.\"");
                break;
            default:
                break;
        }
    }
}
