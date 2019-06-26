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
                    "Sophia", 
                    "There is a box here, is it possible to open?"
                    );
                break;
            case "bird":
                startDialogView(
                    "Sophia",
                    "Is the bird keeping something? Maybe I can distract it with something..."
                    );
                break;
            case "chest":
                detailInteraction(
                    "InteractContainer_emptyBox",
                    "Sophia",
                    "There is nothing here"
                );
                break;
            default:
                break;
        }
    }
    private void OnMouseEnter()
    {
        if (IsMouseOverUI())
            Helper.setMouseStatus(MouseStatus.Free);
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
