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
            if (IsMouseOverUI())
                return;
            switch (currentHover)
            {
                case "words":
                    Helper.hideInventory();
                    SceneManager.LoadScene("Room 2 End");
                    break;
                case "worker":
                    if (!Helper.Scene2BaseOK)
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
                            dialogCanvas.transform.Find("dialog_worker close").GetComponentInChildren<Text>().text = "Next";
                            Helper.DialogState = 0;
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
                        endDetailView();
                        detailInteraction(
                        "InteractContainer_puzzle",
                        "Sophia:",
                        "\"Pipe? Oh so I need to change the direction of these parts to make the pipe\"");
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
                            try
                            {
                                dialog.GetComponent<AudioSource>().Play();
                            }
                            catch { }
                        }
                    }
                    break;
                case "Goethe_Schiller":
                    if (!Helper.inDetail)
                    {
                        detailInteraction(
                            "InteractContainer_gs",
                            "Sophia:",
                            "\"Ok, behind the statue...\"");
                    }
                    break;
                case "goethe_schiller_from behind":
                    Helper.inDetail = false;
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
                case "musician":
                    AudioSource[] audios = GetComponents<AudioSource>();
                    foreach (var audio in audios)
                    {
                        if (audio.isPlaying)
                        {
                            return;
                        }
                    }
                    System.Random rand = new System.Random();
                    int index = rand.Next(audios.Length);
                    audios[index].Play();
                    Animator animator = GetComponent<Animator>();
                    animator.SetTrigger("Active");
                    break;
                default:
                    break;
            }
        }
    }

    public override void toolTipHandle()
    {
        if (base.currentHover.Equals("other_stuff") && !GameManager.Room2.gotScrewDriver && Helper.Scene2BaseOK && Helper.DialogState != 0)
            Tooltip.showTooltip_Static("Take a look");
        else
        {
            Tooltip.hideToolTip_Static();
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
                dialogCanvas.GetComponent<AudioSource>().Stop();
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
                                    Tx.text = "\"A screwdriver? Well I'm currently using it, I can give you after I connect this pipe, It could be quicker if you help me.\"";
                            }
                            dialogCanvas.transform.Find("dialog_worker close").GetComponentInChildren<Text>().text = "Close";
                        }
                        Helper.DialogState = 1;
                        setClose = false;
                    }
                }
            }
        }

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
