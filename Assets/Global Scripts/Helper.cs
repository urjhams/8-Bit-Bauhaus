using UnityEngine;

public class Helper
{
    public static MouseStatus mouseStatus = MouseStatus.Free;
    public static bool inDetail = false;
    public static bool Scene2BaseOK = false;
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
}

public enum MouseStatus
{
    Free,
    Click
}
