using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GlobalMouseControl : GlobalEffectControl
{
    [SerializeField] public GameObject interactContainer;
    [SerializeField] public Canvas dialogCanvas;
    [SerializeField] public Text dialogBox;
    [SerializeField] public Text nameBox;
    public Collider2D col;
    [HideInInspector] public string currentHover = "None";
    private Button closeDialogButton;

    public virtual void OnMouseDown()
    {
        Helper.setMouseStatus(MouseStatus.Click);
    }

    void OnMouseUp()
    {
        Helper.setMouseStatus(MouseStatus.Free);
    }
    public bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    void Start()
    {
        if (dialogCanvas != null)
        {
            //closeDialogButton = GameObject.Find("dialog close").GetComponent<Button>();
            closeDialogButton = dialogCanvas.GetComponentInChildren<Button>();
            if(closeDialogButton != null)
                closeDialogButton.onClick.AddListener(() => this.endDetailView());
        }
    }

    void OnDestroy()
    {
        if (closeDialogButton != null)
            closeDialogButton.onClick.RemoveListener(() => this.endDetailView());
    }

    private void OnMouseEnter()
    {
        if (IsMouseOverUI())
            Helper.setMouseStatus(MouseStatus.Free);
        currentHover = col.name;
        this.toolTipHandle();
    }

    private void OnMouseExit()
    {
        Helper.setMouseStatus(MouseStatus.Free);
        Tooltip.hideToolTip_Static();
    }

    public virtual void toolTipHandle() {}

    public void detailInteraction(string name, string nameText, string contentText)
    {
        if (!interactContainer.name.Equals(name))
            return;
        if (!Helper.inDetail)
        {
            startDetailView(nameText, contentText);
        }
    }

    void startDetailView(string nameText, string contentText)
    {
        Helper.inDetail = true;
        interactContainer.SetActive(true);
        dialogBox.text = contentText;
        nameBox.text = nameText;
        dialogCanvas.enabled = true;
        Helper.setMouseStatus(MouseStatus.Free);
        Tooltip.hideToolTip_Static();
    }

    public virtual void endDetailView()
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
                    }
                }
            }
        }
        if (interactContainer != null)
        {
            if (interactContainer.name == "InteractContainer_worker" & Helper.Scene2BaseOK)
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

    public void startDialogView(string nameText, string contentText) {
        Helper.inDetail = true;
        dialogBox.text = contentText;
        nameBox.text = nameText;
        dialogCanvas.enabled = true;
        Helper.setMouseStatus(MouseStatus.Free);
        Tooltip.hideToolTip_Static();
    }

    public void disableGameObjectList(string[] names)
    {
        foreach (var name in names)
        {
            GameObject[] objArray = GameObject.FindGameObjectsWithTag(name);
            foreach (var obj in objArray)
            {
                obj.SetActive(false);
            }
        }
    }

    public void enableGameObjectList(string[] names)
    {
        foreach (var name in names)
        {
            GameObject[] objArray = GameObject.FindGameObjectsWithTag(name);
            foreach (var obj in objArray)
            {
                obj.SetActive(true);
            }
        }
    }
}
