using UnityEngine;
using UnityEngine.SceneManagement;


public class Room1BasementMouseControl : GlobalMouseControl
{
    private void OnMouseDown()
    {
        if (currentHover.Equals("Rooftop_new"))
        {
            SceneManager.LoadScene("Room 1");
        }
    }

    private void OnMouseEnter()
    {
        currentHover = col.name;
        if (currentHover.Equals("Rooftop_new"))
        {
            Helper.setMouseStatus(MouseStatus.Inspect);
            Tooltip.showTooltip_Static("Get back downstairs");
        }
        else
        {
            Helper.setMouseStatus(MouseStatus.Free);
        }

    }
}
