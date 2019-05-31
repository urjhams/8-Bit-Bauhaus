using UnityEngine;

public class Helper
{
    public static MouseStatus mouseStatus = MouseStatus.Free;
    public static int room1_RightArm = 0;
    public static int room1_LeftArm = 1;
    public static bool room1_ladder = false;

    public static bool inDetail = false;

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
    Click,
    Grap,
    Inspect
}
