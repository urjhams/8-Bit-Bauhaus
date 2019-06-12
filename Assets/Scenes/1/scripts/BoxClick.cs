using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxClick : MonoBehaviour
{
    [SerializeField] public GameObject interactContainer;
    [SerializeField] public Canvas dialogCanvas;
    [SerializeField] public Text dialogBox;
    [SerializeField] public Text nameBox;
    private Button closeDialogButton;
    void Start()
    {
        closeDialogButton = GameObject.Find("dialog close").GetComponent<Button>();
        closeDialogButton.onClick.AddListener(() => this.endDetailView());
    }

    void OnDestroy()
    {
        closeDialogButton.onClick.RemoveListener(() => this.endDetailView());
    }
    void clickPuzzleBox()
    {
        if (!Helper.inDetail)
        {
            Helper.inDetail = true;
            interactContainer.SetActive(true);
            dialogBox.text = "A box, with a puzzle...?";
            nameBox.text = "Schmitz";
            dialogCanvas.enabled = true;
            Helper.setMouseStatus(MouseStatus.Free);
            Tooltip.hideToolTip_Static();
        }
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
    
}
