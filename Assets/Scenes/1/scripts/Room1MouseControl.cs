using UnityEngine;

public class Room1MouseControl : GlobalMouseControl
{
    [SerializeField] GameObject ladder;
    void Start()
    {
        this.setUpContext();
       
    }

    void Update()
    {
        //ladder.SetActive(ladderAppear);
    }

    private void setUpContext()
    {
        //disable bowl without box
        var bowlWithoutBox = Helper.getSpriteRendererOf("bowl without box");
        bowlWithoutBox.enabled = false;

        //disable another arm
        Helper.getSpriteRendererOf("left arm 4").enabled = false;
        Helper.getSpriteRendererOf("left arm 2").enabled = false;
        Helper.getSpriteRendererOf("right arm 1").enabled = false;

        // hide the ladder
        if (ladder != null)
        {
            ladder.active = false;
        }
    }

   
    private void OnMouseDown()
    {
        switch (currentHover)
        {
            case "lamp_interact":
                onOffEffect("lamp_light");
                break;
            case "statues_discover":
                //TODO
                break;
            case "rooftop door_interact":
                //TODO
                break;
            case "ladder_discover":
                //TODO
                break;
            case "painting_discover":
                //TODO:
                break;
            default:
                break;
        }

        // show the ladder
        //if (ladder != null)
            //ladder.active = !ladder.active;
    }

    private void onOffEffect(string obj)
    {
        Helper.getSpriteRendererOf(obj).enabled = !Helper.getSpriteRendererOf(obj).enabled;
        //ladder.active = true;
    }
}
