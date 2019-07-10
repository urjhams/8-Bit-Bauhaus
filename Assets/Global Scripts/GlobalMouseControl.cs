using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class GlobalMouseControl : GlobalEffectControl
{
    [SerializeField] public GameObject interactContainer;
    [SerializeField] public Canvas dialogCanvas;
    [SerializeField] public Text dialogBox;
    [SerializeField] public Text nameBox;
    public Collider2D col;
    [HideInInspector] public string currentHover = "None";
    [HideInInspector] public Button closeDialogButton;

    public virtual void OnMouseDown()
    {
        Helper.setMouseStatus(MouseStatus.Click);
        if (IsMouseOverUI())
            return;
    }

    void OnMouseUp()
    {
        Helper.setMouseStatus(MouseStatus.Free);
    }
    public bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    public virtual void Start()
    {
        closeDialogButton = GameObject.Find("dialog close").GetComponent<Button>();
        closeDialogButton.onClick.AddListener(() => this.endDetailView());
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
        print(col.name);
        this.toolTipHandle();
    }

    private void OnMouseExit()
    {
        Helper.setMouseStatus(MouseStatus.Free);
        Tooltip.hideToolTip_Static();
    }

    public virtual void toolTipHandle() { }

    public virtual void detailInteraction(string name, string nameText, string contentText)
    {
        if (!interactContainer.name.Equals(name))
            return;
        if (!Helper.inDetail)
        {
            startDetailView(nameText, contentText);
        }
    }

    public void startDetailView(string nameText, string contentText)
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
        Helper.inDetail = false;
        if (interactContainer != null)
            interactContainer.SetActive(false);
        if (dialogCanvas != null)
            dialogCanvas.enabled = false;
        Helper.setMouseStatus(MouseStatus.Free);
        Tooltip.hideToolTip_Static();
    }

    public void startDialogView(string nameText, string contentText)
    {
        Helper.inDetail = true;
        dialogBox.text = contentText;
        nameBox.text = nameText;
        dialogCanvas.enabled = true;
        Helper.setMouseStatus(MouseStatus.Free);
        Tooltip.hideToolTip_Static();
    }

    public void disableDialogView()
    {
        dialogCanvas.enabled = false;
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
