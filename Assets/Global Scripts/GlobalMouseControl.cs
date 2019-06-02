using UnityEngine.UI;
using UnityEngine;

public class GlobalMouseControl : GlobalEffectControl
{
    [SerializeField] public GameObject interactContainer;
    [SerializeField] public Canvas dialogCanvas;
    [SerializeField] public Text dialogBox;
    [SerializeField] public Text nameBox;
    public Collider2D col;
    [HideInInspector] public string currentHover = "None";

    private Button closeDialogButton;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        closeDialogButton = GameObject.Find("dialog close").GetComponent<Button>();
        closeDialogButton.onClick.AddListener(() => this.endDetailView());
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        closeDialogButton.onClick.RemoveListener(() => this.endDetailView());
    }

    private void OnMouseEnter()
    {
        print(col.name);
        currentHover = col.name;
        if (currentHover.Contains("interact"))
        {
            Helper.setMouseStatus(MouseStatus.Click);
        }
        else if (currentHover.Contains("discover"))
        {
            if (!Helper.inDetail)
                Helper.setMouseStatus(MouseStatus.Inspect);
            else
                Helper.setMouseStatus(MouseStatus.Free);
        }
        else if (currentHover.Contains("grab"))
        {
            Helper.setMouseStatus(MouseStatus.Grap);
        }
        else
        {
            Helper.setMouseStatus(MouseStatus.Free);
        }
        this.toolTipHandle();
    }

    private void OnMouseExit()
    {
        Helper.setMouseStatus(MouseStatus.Free);
        Tooltip.hideToolTip_Static();
    }

    public virtual void toolTipHandle() { }

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

    void endDetailView()
    {
        Helper.inDetail = false;
        if (interactContainer != null)
            interactContainer.SetActive(false);
        if (dialogCanvas != null)
            dialogCanvas.enabled = false;
        Helper.setMouseStatus(MouseStatus.Free);
        Tooltip.hideToolTip_Static();
    }

    void disableGameObjectList(string[] names)
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

    void enableGameObjectList(string[] names)
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
