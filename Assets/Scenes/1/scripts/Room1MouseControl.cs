using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Room1MouseControl : GlobalMouseControl
{
    string[] rightArm = {"right arm 4", "right arm 1"};
    string[] leftArm = {"left arm 4", "left arm 3", "left arm 2"};
    string[] rightArmDetail = { "interact_right arm 4", "interact_right arm 1" };
    string[] leftArmDetail = { "interact_left arm 4", "interact_left arm 3", "interact_left arm 2" };
    public static Room1MouseControl instace;

    void Start()
    {
        //this.setUpContext();
    }

    private void Awake()
    {
        this.setUpContext();
        instace = this;
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

    private void updateArm()
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

    public static void getStatusState()
    {
        print("Instance");
        instace.updateArm();
        instace.checkStatues();
    }

    private void onOffEffect(string obj)
    {
        Helper.getSpriteRendererOf(obj).enabled = !Helper.getSpriteRendererOf(obj).enabled;
        //ladder.active = true;
    }

    public override void detailInteraction(string name, string nameText, string contentText) {
        base.detailInteraction(name, nameText, contentText);
        if (!Helper.inDetail) {
            updateArm();
        }
    }
}
