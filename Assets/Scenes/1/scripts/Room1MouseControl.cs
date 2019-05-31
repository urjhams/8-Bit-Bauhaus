using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Room1MouseControl : GlobalMouseControl
{
    static string[] rightArm = { "right arm 4", "right arm 1" };
    static string[] leftArm = { "left arm 4", "left arm 3", "left arm 2" };
    static string[] rightArmDetail = { "interact_right arm 4", "interact_right arm 1" };
    static string[] leftArmDetail = { "interact_left arm 4", "interact_left arm 3", "interact_left arm 2" };

    void Start()
    {
        //this.setUpContext();
    }

    private void Awake()
    {
        this.setUpContext();
    }

    private void Update()
    {
        updateArm();
        checkStatues();
    }

    private void setUpContext()
    {
        //disable bowl without box
        Helper.getSpriteRendererOf("bowl without box").enabled = false;

        updateArm();
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
                detailInteraction("InteractContainer_statues", "Schmitz", "This statues... is that the same one in the picture?");
                break;
            case "rooftop door_interact":
                //TODO
                break;
            case "ladder_discover":
                SceneManager.LoadScene("Room 1 basement");
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
            Helper.room1_LeftArm = (Helper.room1_LeftArm == leftArm.Length - 1) ? 0 : Helper.room1_LeftArm + 1;
            print(Helper.room1_LeftArm);
        }

        if (currentHover.Contains("right arm"))
        {
            Helper.room1_RightArm = (Helper.room1_RightArm == rightArm.Length - 1) ? 0 : Helper.room1_RightArm + 1;
            print(Helper.room1_RightArm);
        }
        updateArm();
        checkStatues();
    }

    public static void updateArm()
    {
        try
        {
            for (int i = 0; i < leftArm.Length; i++)
            {
                Helper.getSpriteRendererOf(leftArm[i]).enabled = (i == Helper.room1_LeftArm);
                Helper.getSpriteRendererOf(leftArmDetail[i]).enabled = (i == Helper.room1_LeftArm);
            }
            for (int i = 0; i < rightArm.Length; i++)
            {
                Helper.getSpriteRendererOf(rightArm[i]).enabled = (i == Helper.room1_RightArm);
                Helper.getSpriteRendererOf(rightArmDetail[i]).enabled = (i == Helper.room1_RightArm);
            }
        }
        catch (NullReferenceException e)
        {

        }

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
        //ladder.active = true;
    }

    private void detailInteraction(string name, string nameText, string contentText)
    {
        if (!interactContainer.name.Equals(name))
            return;

        if (inDetail)
        {
            inDetail = false;
            interactContainer.SetActive(false);
            dialogBox.enabled = false;
            nameBox.enabled = false;
        }
        else
        {
            interactContainer.SetActive(true);
            dialogBox.text = contentText;
            nameBox.text = nameText;
            dialogBox.enabled = true;
            nameBox.enabled = true;
            inDetail = true;
            Helper.setMouseStatus(MouseStatus.Free);
            updateArm();
        }
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
