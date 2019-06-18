using UnityEngine;
using UnityEngine.SceneManagement;


public class Room1BasementMouseControl : GlobalMouseControl
{
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        if (currentHover.Equals("ladder"))
        {
            SceneManager.LoadScene("Room 1");
        }
    }
    private void OnMouseEnter()
    {
        currentHover = col.name;
        if (currentHover.Equals("ladder"))
        {
            Tooltip.showTooltip_Static("Get back downstairs");
        }
        else
        {
            Tooltip.hideToolTip_Static();
        }
    }
}
