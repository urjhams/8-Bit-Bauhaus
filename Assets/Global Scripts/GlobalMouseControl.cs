using UnityEngine.UI;
using UnityEngine;

public class GlobalMouseControl : MonoBehaviour
{
    [SerializeField] public GameObject ladder;
    [SerializeField]public  GameObject interactContainer;
    [SerializeField]public Text dialogBox;
    [SerializeField]public Text nameBox;
    public Collider2D col;
    [HideInInspector] public string currentHover = "None";
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

    public virtual void toolTipHandle()
    {
        if (currentHover.Contains("discover"))
        {
            if (currentHover.Equals("ladder_discover"))
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
