using UnityEngine.SceneManagement;


public class Room1BasementMouseControl : GlobalMouseControl
{
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        switch (currentHover)
        {
            case "ladder":
                SceneManager.LoadScene("Room 1");
                break;
            case "wardrobe":
                if (!GameManager.Room1Basement.wardrobeOpen)
                    GameManager.Room1Basement.wardrobeOpen = true;
                break;
            case "wardrobe_opened":
                detailInteraction(
                    "InteractContainer_wardrobe", 
                    "Schmitz", 
                    "There is a box here, is it possible to open?");
                break;
            default:
                break;
        }
    }
    private void OnMouseEnter()
    {
        currentHover = col.name;
        if (currentHover.Equals("ladder"))
        {
            Tooltip.showTooltip_Static("Get back downstairs");
        }
        else
        {
            Tooltip.hideToolTip_Static();
        }
    }
}
