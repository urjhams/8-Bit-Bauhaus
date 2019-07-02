using UnityEngine;

public class Room2Manager : CursorHandle
{
    void Start()
    {
        try
        {
            GameObject.Find("inventory frame").GetComponent<CanvasRenderer>().SetAlpha(1);
        }
        catch { }
    }
    protected override void Update()
    {
        base.Update();
    }
}
