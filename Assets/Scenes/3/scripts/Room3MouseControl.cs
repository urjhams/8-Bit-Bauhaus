using UnityEngine.SceneManagement;
using UnityEngine;

public class Room3MouseControl : GlobalMouseControl
{
    private GameObject key;
    public override void Start()
    {
        base.Start();
        try
        {
            key = GameObject.Find("key_box");
            key.GetComponent<Collider2D>().enabled = false;
        }
        catch { }
    }
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
                    try
                    {
                        key = GameObject.Find("key_box");
                        if (GameManager.Room3.puzzleSoved)
                        {
                            key.GetComponent<Collider2D>().enabled = true;
                        }
                        else
                        {
                            key.GetComponent<Collider2D>().enabled = false;
                        }
                    }
                    catch { }
                }
                break;
            case "lock":
                endDetailView();
                try
                {
                    interactContainer.SetActive(true);
                }
                catch { }
                detailInteraction(
                    "InteractContainer_lock",
                    "Sophia:",
                    "\"I need to find the right code to open it.\"");
                break;
            case "closeup_dot":
                if (!GameManager.Room3.puzzleSoved)
                    return;
                try
                {
                    GameObject.Find("InteractContainer_lock").SetActive(false);
                    key.GetComponent<Collider2D>().enabled = true;
                }
                catch { }
                detailInteraction(
                        "InteractContainer_locker",
                        "Sophia:",
                        "\"R.Schmidt! That must be the former locker of my grandma. Maybe i can find something inside.\"");
                break;
            case "way back":
                if (GameManager.Room3.goal)
                {
                    Helper.hideInventory();
                    SceneManager.LoadScene("Room 3 End");
                }
                break;
            case "room plate":
                detailInteraction(
                        "InteractContainer_roomPlate",
                        "Sophia:",
                        ".....");
                break;
            default:
                break;
        }
        Helper.setMouseStatus(MouseStatus.Free);
    }
    public override void toolTipHandle()
    {
        if (base.currentHover.Equals("way back") && GameManager.Room3.goal)
            Tooltip.showTooltip_Static("Get back to my apartment");
        else
        {
            Tooltip.hideToolTip_Static();
        }
    }
}
