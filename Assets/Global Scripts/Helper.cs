using UnityEngine;

public class Helper
{
    public static MouseStatus mouseStatus = MouseStatus.Free;
    public static bool inDetail = false;
    public static bool Scene2BaseOK = false;
    public static bool PipelinePuzzleOK = false;
    public static int DialogState = 0;
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
        try
        {
            GameObject.Find("inventory frame").GetComponent<CanvasRenderer>().SetAlpha(0);
            GameObject.Find("inventory frame").transform.Find("Image").GetComponent<CanvasRenderer>().SetAlpha(0);
        }
        catch { }
    }

    public static void showInventory() {
        try
        {
            GameObject.Find("inventory frame").GetComponent<CanvasRenderer>().SetAlpha(1);
            GameObject.Find("inventory frame").transform.Find("Image").GetComponent<CanvasRenderer>().SetAlpha(1);
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
