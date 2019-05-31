using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Room1MouseControl : GlobalMouseControl
{
    private void Awake()
    {
        this.setUpContext();
    }

    private void setUpContext()
    {
        //disable bowl without box
        Helper.getSpriteRendererOf("bowl without box").enabled = false;
        checkStatues();
    }

    private void OnMouseDown()
    {
        switch (currentHover)
        {
            case "lamp_interact":
                onOffEffect("lamp_light");
                break;
            case "statues_discover":
                this.detailInteraction("InteractContainer_statues", "Schmitz", "This statues... is that the same one in the picture?");
                break;
            case "rooftop door_interact":
                //TODO
                break;
            case "ladder_discover":
                SceneManager.LoadScene("Room 1 basement");
                break;
            case "painting_discover":
                this.detailInteraction("InteractContainer_paint", "Schmitz", "Hmm... this picture look nice...");
                break;
            case "bowl with box_discover":
                this.detailInteraction("InteractContainer_box", "Schmitz", "A box, with a puzzle...?");
                break;
            default:
                break;
        }

        if (currentHover.Contains("left arm"))
        {
            Helper.room1_LeftArm = (Helper.room1_LeftArm == Room1Manager.leftArm.Length - 1) ? 0 : Helper.room1_LeftArm + 1;
        }

        if (currentHover.Contains("right arm"))
        {
            Helper.room1_RightArm = (Helper.room1_RightArm == Room1Manager.rightArm.Length - 1) ? 0 : Helper.room1_RightArm + 1;
        }
        checkStatues();
    }

    private void checkStatues()
    {
        if (Helper.room1_LeftArm == 0 && Helper.room1_RightArm == 0)
        {
            if (ladder != null)
            {
                ladder.SetActive(true);
                dialogBox.text = "Wow The basement's door suddenly open.";
            }
        }
    }

    private void onOffEffect(string obj)
    {
        Helper.getSpriteRendererOf(obj).enabled = !Helper.getSpriteRendererOf(obj).enabled;
    }
}
