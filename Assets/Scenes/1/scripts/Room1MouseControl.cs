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
                detailInteraction(
                    "InteractContainer_statues",
                    "Schmitz",
                    "This statues... is that the same one in the picture?");
                break;
            case "rooftop door_interact":
                //TODO
                break;
            case "ladder_discover":
                if (!Helper.inDetail)
                    FadeToLevel("Room 1 basement");
                break;
            case "painting_discover":
                detailInteraction(
                    "InteractContainer_paint",
                    "Schmitz",
                    "Hmm... this picture look nice...");
                break;
            case "bowl with box_discover":
                detailInteraction(
                    "InteractContainer_box",
                    "Schmitz",
                    "A box, with a puzzle...?");
                break;
            default:
                break;
        }

        if (currentHover.Contains("left arm"))
        {
            GameManager.Room1.currentLeftArm = (GameManager.Room1.currentLeftArm == GameManager.Room1.leftArm.Length - 1) ? 0 : GameManager.Room1.currentLeftArm + 1;
            print(GameManager.Room1.currentLeftArm);
        }

        if (currentHover.Contains("right arm"))
        {
            GameManager.Room1.currentRightArm = (GameManager.Room1.currentRightArm == GameManager.Room1.rightArm.Length - 1) ? 0 : GameManager.Room1.currentRightArm + 1;
            print(GameManager.Room1.currentRightArm);
        }
        checkStatues();
    }

    public void updateStatueDetailArm()
    {
        try
        {
            for (int i = 0; i < GameManager.Room1.leftArm.Length; i++)
            {
                Helper.getSpriteRendererOf(GameManager.Room1.leftArmDetail[i]).enabled = (i == GameManager.Room1.currentLeftArm);
            }
            for (int i = 0; i < GameManager.Room1.rightArm.Length; i++)
            {
                Helper.getSpriteRendererOf(GameManager.Room1.rightArmDetail[i]).enabled = (i == GameManager.Room1.currentRightArm);
            }
        }
        catch { }
    }

    private void checkStatues()
    {
        if (GameManager.Room1.currentLeftArm == 0 && GameManager.Room1.currentRightArm == 1)
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
