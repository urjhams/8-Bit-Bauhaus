using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Room2MouseControl : GlobalMouseControl
{
    public override void Start()
    {
        closeDialogButton = dialogCanvas.GetComponentInChildren<Button>();
        if (closeDialogButton != null)
            closeDialogButton.onClick.AddListener(() => this.endDetailView());
    }
    public override void OnMouseDown()
    {
        bool runAction = true;
        GameObject dialog = null;

        if (currentHover == "other_stuff" & Helper.DialogState != 1)
            runAction = false;
        if (runAction)
        {
            base.OnMouseDown();
            switch (currentHover)
            {
                case "words":
                    Helper.hideInventory();
                    SceneManager.LoadScene("Room 2 End");
                    break;
                case "worker":
                    if (Helper.Scene2BaseOK == false)
                    {
                        detailInteraction(
                            "InteractContainer_worker",
                            "Worker:",
                            "\"Hey! This is a construction site. Get out!\"");
                        GameObject worker_zoom = GameObject.Find("worker_zoom");
                        if (worker_zoom != null)
                        {
                            Animator workerAnimator = worker_zoom.GetComponent<Animator>();
                            if (workerAnimator != null)
                            {
                                workerAnimator.SetBool("Play", true);
                            }
                        }
                    }
                    else
                    {
                        if (!GameManager.Room2.gotScrewDriver)
                        {
                            detailInteraction(
                                "InteractContainer_worker",
                                "Sophia:",
                                "\"Excuse me, could I borrow a screwdriver?\"");
                            Helper.DialogState = 0;
                            Helper.inDetail = false;
                        }
                        else
                        {
                            return;
                        }
                    }
                    break;
                case "other_stuff":
                    if (!GameManager.Room2.gotScrewDriver)
                    {
                        detailInteraction(
                        "InteractContainer_puzzle",
                        "Sophia:",
                        "\"Puzzle?\"");
                        dialog = GameObject.Find("dialog_worker canvas");
                        if (dialog != null)
                        {
                            Image[] Images = dialog.GetComponentsInChildren<Image>();
                            foreach (Image Im in Images)
                            {
                                Im.enabled = false;
                            }
                            Text[] Texte = dialog.GetComponentsInChildren<Text>();
                            foreach (Text Tx in Texte)
                            {
                                Tx.enabled = false;
                            }
                        }
                    }
                    break;
                case "Goethe_Schiller":
                    if (!Helper.inDetail)
                    {
                        detailInteraction(
                            "InteractContainer_gs",
                            "Sophia:",
                            "\"What is that on the pedastal?\"");
                        Helper.inDetail = false;
                    }
                    break;
                case "goethe_schiller_from behind":
                    detailInteraction(
                        "InteractContainer_gs_base",
                        "Sophia:",
                        "\"There is something behind this shield. I probably need a screwdriver!\"");
                    dialog = GameObject.Find("dialog canvas");
                    if (dialog != null)
                    {
                        Image[] Images = dialog.GetComponentsInChildren<Image>();
                        foreach (Image Im in Images)
                        {
                            Im.enabled = false;
                        }
                        Text[] Texte = dialog.GetComponentsInChildren<Text>();
                        foreach (Text Tx in Texte)
                        {
                            Tx.enabled = false;
                        }
                    }
                    Helper.Scene2BaseOK = true;
                    break;
                default:
                    break;
            }
        }
    }

    public override void endDetailView()
    {
        bool setClose = true;

        if (dialogCanvas != null)
        {
            if (dialogCanvas.name == "dialog1 canvas")
            {
                GameObject dialog = GameObject.Find("dialog canvas");
                if (dialog != null)
                {
                    Image[] Images = dialog.GetComponentsInChildren<Image>();
                    foreach (Image Im in Images)
                    {
                        Im.enabled = true;
                    }
                    Text[] Texte = dialog.GetComponentsInChildren<Text>();
                    foreach (Text Tx in Texte)
                    {
                        Tx.enabled = true;
                    }
                }
            }
            else if (dialogCanvas.name == "dialog canvas")
            {
                GameObject dialog = GameObject.Find("dialog_worker canvas");
                if (dialog != null)
                {
                    Image[] Images = dialog.GetComponentsInChildren<Image>();
                    foreach (Image Im in Images)
                    {
                        Im.enabled = true;
                    }
                    Text[] Texte = dialog.GetComponentsInChildren<Text>();
                    foreach (Text Tx in Texte)
                    {
                        Tx.enabled = true;
                        if (GameManager.Room2.gotScrewDriver)
                        {
                            if (Tx.name == "Text_worker name")
                                Tx.text = "Worker:";
                            if (Tx.name == "Text_worker content")
                                Tx.text = "\"Excellent! Here you have the screwdriver.\"";
                        }
                    }
                }
            }
            else if (dialogCanvas.name == "dialog_worker canvas")
            {
                if (GameManager.Room2.gotScrewDriver)
                {
                    GameObject.Find("RoomManager").GetComponent<ScewDriverCollect>().checkCollect();
                }
            }
        }
        if (interactContainer != null)
        {
            if (interactContainer.name == "InteractContainer_worker" & Helper.Scene2BaseOK)
            {
                if (!GameManager.Room2.gotScrewDriver)
                {
                    if (Helper.DialogState == 0)
                    {
                        GameObject dialog = GameObject.Find("dialog_worker canvas");
                        if (dialog != null)
                        {
                            Text[] Texte = dialog.GetComponentsInChildren<Text>();
                            foreach (Text Tx in Texte)
                            {
                                if (Tx.name == "Text_worker name")
                                    Tx.text = "Worker:";
                                if (Tx.name == "Text_worker content")
                                    Tx.text = "\"A screwdriver? Do you even know how to use that? I do not care ... you could actually help me with something. The pipes in the hole there have to be reconnected.\"";
                            }
                        }
                        Helper.DialogState = 1;
                        setClose = false;
                    }
                }
            }
        };

        if (setClose)
        {
            Helper.inDetail = false;
            if (interactContainer != null)
                interactContainer.SetActive(false);
            if (dialogCanvas != null)
                dialogCanvas.enabled = false;
            Helper.setMouseStatus(MouseStatus.Free);
            Tooltip.hideToolTip_Static();
        }
    }
}
