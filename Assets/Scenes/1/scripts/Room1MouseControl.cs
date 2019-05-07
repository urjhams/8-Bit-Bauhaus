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
        switch (currentHover)
        {
            case "lamp":
                onOffEffect("lamp", "light");
                break;
            default:
                break;
        }
    }

    private void onOffEffect(string obj, string effect)
    {
        foreach (SpriteRenderer spriteRenderer in allEffect)
        {
            string spriteName = spriteRenderer.sprite.name;
            if (spriteName.Equals(obj + "_" + effect))
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
            }
        }
    }
}
