using UnityEngine;

public class Helper
{
    public static MouseStatus mouseStatus = MouseStatus.Free;
    public static bool inDetail = false;
    // ---------------- global variable used in 2nd room
    public static bool Scene2BaseOK = false;
    public static bool PipelinePuzzleOK = false;
    public static int DialogState = 0;
    // ---------------------------------------------------
    public static void setMouseStatus(MouseStatus status)
    {
        mouseStatus = status;
    }

    public static SpriteRenderer getSpriteRendererOf(string objectName)
    {
        return GameObject.Find(objectName).GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
    }

    public static SpriteRenderer[] getSpriteRenderersOf(string objectName)
    {
        return GameObject.Find(objectName).GetComponentsInChildren<SpriteRenderer>();
    }

    public static void hideInventory()
    {
        setInventoryAlpha(0);
    }

    public static void showInventory()
    {
        setInventoryAlpha(1);
    }

    private static void setInventoryAlpha(float alpha)
    {
        try
        {
            GameObject.Find("inventory frame").GetComponent<CanvasRenderer>().SetAlpha(alpha);
            GameObject.Find("inventory frame").transform.Find("Image").GetComponent<CanvasRenderer>().SetAlpha(alpha);
            var slots = GameObject.Find("inventory frame").transform.Find("Slot area").transform;
            foreach (Transform item in slots)
            {
                try
                {
                    if (item.GetChild(0) != null)
                    {
                        item.GetChild(0).GetComponent<CanvasRenderer>().SetAlpha(alpha);
                    }
                }
                catch { }
            }
        }
        catch { }
    }
    public static void showInventory(GameObject inventoryObject)
    {
        try
        {
            inventoryObject.transform.Find("Inventory frame").GetComponent<CanvasRenderer>().SetAlpha(1);
            inventoryObject.transform.Find("Inventory frame").transform.Find("Image").GetComponent<CanvasRenderer>().SetAlpha(1);
        }
        catch { }
    }
}

public enum MouseStatus
{
    Free,
    Click
}
