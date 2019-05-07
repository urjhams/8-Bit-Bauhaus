using UnityEngine;

public class Room1MouseControl : MonoBehaviour
{
    public Collider2D col;
    string currentHover = "None";
    SpriteRenderer[] allEffect;

    private void Start()
    {
        allEffect = GameObject.Find("Effect").GetComponentsInChildren<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        print(col.name);
        currentHover = col.name;
        Helper.Global.setMouseStatus(Helper.MouseStatus.Inspect);
    }

    private void OnMouseExit()
    {
        Helper.Global.setMouseStatus(Helper.MouseStatus.Free);
        currentHover = "None";
    }

    private void OnMouseDown()
    {
        if (currentHover.Equals("lamp"))
        {
            foreach (SpriteRenderer spriteRenderer in allEffect)
            {
                if (spriteRenderer.sprite.name.Equals("lamp_light"))
                {
                    spriteRenderer.enabled = !spriteRenderer.enabled;
                }
            }
        }
    }


}
