using UnityEngine;
using UnityEngine.UI;

public class Room1MouseControl : GlobalMouseControl
{
    [SerializeField] GameObject ladder;
    [SerializeField] GameObject interactContainer;
    [SerializeField] Text dialogBox;
    [SerializeField] Text nameBox;

    void Start()
    {
        this.setUpContext();
    }

    private void setUpContext()
    {
        //disable bowl without box
        Helper.getSpriteRendererOf("bowl without box").enabled = false;

        //disable another arms
        Helper.getSpriteRendererOf("left arm 4").enabled = false;
        Helper.getSpriteRendererOf("left arm 2").enabled = false;
        Helper.getSpriteRendererOf("right arm 1").enabled = false;
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
                //TODO
                break;
            case "painting_discover":
                detailInteraction("InteractContainer_paint", "Schmitz", "Hmm... this picture look nice...");
                break;
            default:
                break;
        }

        //// show the ladder
        //if (ladder != null)
        //ladder.active = !ladder.active;
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
            this.subDetail(name);
        }
    }
    private void subDetail(string name)
    {
        if (name.Equals("InteractContainer_statues"))
        {
            Helper.getSpriteRendererOf("interact_left arm 4").enabled = false;
            Helper.getSpriteRendererOf("interact_left arm 2").enabled = false;
            Helper.getSpriteRendererOf("interact_right arm 1").enabled = false;
        }
    }
}
