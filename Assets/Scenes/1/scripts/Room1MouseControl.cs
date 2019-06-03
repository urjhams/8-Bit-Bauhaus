using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Room1MouseControl : GlobalMouseControl
{
    [SerializeField] public GameObject ladder;
    private void Awake()
    {
        this.setUpContext();
    }

    private void Update()
    {
        updateStatueDetailArm();
        checkStatues();
    }

    private void setUpContext()
    {
        //disable bowl without box
        Helper.getSpriteRendererOf("bowl without box").enabled = false;
    }
    
    private void OnMouseDown()
    {
        switch (currentHover)
        {
            case "lamp_interact":
                onOffEffect("lamp_light");
                break;
            case "statues_discover":
                detailInteraction("InteractContainer_statues", "Schmitz", "This statues... is that the same one in the picture?");
                break;
            case "rooftop door_interact":
                //TODO
                break;
            case "ladder_discover":
                SceneManager.LoadScene("Room 1 basement");
                Helper.setMouseStatus(MouseStatus.Free);
                break;
            case "painting_discover":
                detailInteraction("InteractContainer_paint", "Schmitz", "Hmm... this picture look nice...");
                break;
            case "bowl with box_discover":
                detailInteraction("InteractContainer_box", "Schmitz", "A box, with a puzzle...?");
                break;
            default:
                break;
        }

        if (currentHover.Contains("left arm"))
        {
            Helper.room1_LeftArm = (Helper.room1_LeftArm == Helper.leftArm.Length - 1) ? 0 : Helper.room1_LeftArm + 1;
            print(Helper.room1_LeftArm);
        }

        if (currentHover.Contains("right arm"))
        {
            Helper.room1_RightArm = (Helper.room1_RightArm == Helper.rightArm.Length - 1) ? 0 : Helper.room1_RightArm + 1;
            print(Helper.room1_RightArm);
        }
        checkStatues();
    }

    public void updateStatueDetailArm()
    {
        try
        {
            for (int i = 0; i < Helper.leftArm.Length; i++)
            {
                Helper.getSpriteRendererOf(Helper.leftArmDetail[i]).enabled = (i == Helper.room1_LeftArm);
            }
            for (int i = 0; i < Helper.rightArm.Length; i++)
            {
                Helper.getSpriteRendererOf(Helper.rightArmDetail[i]).enabled = (i == Helper.room1_RightArm);
            }
        }
        catch (NullReferenceException e)
        {
            
        }
    }

    private void checkStatues()
    {
        if (Helper.room1_LeftArm == 0 && Helper.room1_RightArm == 1)
        {
            if (ladder != null)
            {
                ladder.SetActive(true);
                if (interactContainer != null && 
                interactContainer.name.Equals("InteractContainer_statues") && 
                interactContainer.activeSelf)
                    dialogBox.text = "Wow The basement's door suddenly open.";
            }
        }
    }

    private void onOffEffect(string obj)
    {
        Helper.getSpriteRendererOf(obj).enabled = !Helper.getSpriteRendererOf(obj).enabled;
    }

    public override void toolTipHandle()
    {
        base.toolTipHandle();
        // if (Helper.inDetail) {
        //     return;
        // }
        if (base.currentHover.Contains("discover"))
        {
            if (base.currentHover.Equals("ladder_discover"))
                Tooltip.showTooltip_Static("Get upstair to take a look");
            else
                Tooltip.showTooltip_Static("Discover");
        }
        else
        {
            Tooltip.hideToolTip_Static();
        }
    }
}
