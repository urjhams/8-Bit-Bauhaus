using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Room1MouseControl : GlobalMouseControl
{
    [SerializeField] public GameObject ladder;
    private void Update()
    {
        updateStatueDetailArm();
        checkStatues();
        if (GameManager.Room1.statuesDone)
        {
            var collider = GameObject.Find("statues_discover").GetComponent<Collider2D>();
            collider.enabled = false;
        }
        if (GameManager.Room1.ladderDone && ladder != null)
        {
            ladder.SetActive(true);
        }
    }
    public void OnMouseDown()
    {
        switch (currentHover)
        {
            case "lamp_interact":
                onOffEffect("lamp_light");
                break;
            case "statues_discover":
                if (!GameManager.Room1.statuesDone)
                    detailInteraction(
                    "InteractContainer_statues",
                    "Schmitz",
                    "This statues... is that the same one in the picture?");
                break;
            case "rooftop door_interact":
                startDialogView("Schmitz", "Hmm, is it locked?");
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
                Destroy(gameObject);
                Helper.getSpriteRendererOf("bowl without box").enabled = true;
                break;
            default:
                break;
        }
        if (Helper.inDetail && !GameManager.Room1.statuesDone)
        {
            if (currentHover.Contains("left arm"))
                GameManager.Room1.currentLeftArm =
                (GameManager.Room1.currentLeftArm == GameManager.Room1.leftArm.Length - 1) ?
                0 :
                GameManager.Room1.currentLeftArm + 1;

            if (currentHover.Contains("right arm"))
                GameManager.Room1.currentRightArm =
                (GameManager.Room1.currentRightArm == GameManager.Room1.rightArm.Length - 1) ?
                0 :
                GameManager.Room1.currentRightArm + 1;

            checkStatues();
        }
    }
    public void updateStatueDetailArm()
    {
        try
        {
            for (int i = 0; i < GameManager.Room1.leftArm.Length; i++)
            {
                Helper.getSpriteRendererOf(GameManager.Room1.leftArmDetail[i]).enabled =
                (i == GameManager.Room1.currentLeftArm);
            }
            for (int i = 0; i < GameManager.Room1.rightArm.Length; i++)
            {
                Helper.getSpriteRendererOf(GameManager.Room1.rightArmDetail[i]).enabled =
                (i == GameManager.Room1.currentRightArm);
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
                GameManager.Room1.ladderDone = true;
                if (interactContainer != null &&
                interactContainer.name.Equals("InteractContainer_statues") &&
                interactContainer.activeSelf)
                {
                    GameManager.Room1.statuesDone = true;
                    GameManager.Room1.ladderDone = true;
                    try
                    {
                        var door = GameObject.Find("rooftop door_interact");
                        door.SetActive(false);
                    }
                    catch { }
                    startDialogView("Schmitz", "I just hear somthing on the roof top door, should I check it?");
                }
            }
        }
    }
    private void onOffEffect(string obj)
    {
        Helper.getSpriteRendererOf(obj).enabled = !Helper.getSpriteRendererOf(obj).enabled;
    }
    public override void toolTipHandle()
    {
        if (Helper.inDetail)
        {
            Tooltip.hideToolTip_Static();
            return;
        }
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
