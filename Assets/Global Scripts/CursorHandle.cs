using UnityEngine;

public class CursorHandle : MonoBehaviour
{
    public Texture2D freeMouse;
    public Texture2D clickMouse;

    private void Start()
    {
        Tooltip.hideToolTip_Static();
        if (freeMouse.height == 32)
            TextureScale.Bilinear(freeMouse, 14, 21);
        if (clickMouse.height == 32)
            TextureScale.Bilinear(clickMouse, 15, 21);
    }

    protected virtual void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;

        switch (Helper.mouseStatus)
        {
            case MouseStatus.Click:
                updateCursor(clickMouse);
                break;
            case MouseStatus.Free:
                updateCursor(freeMouse);
                break;
        }
    }

    private void updateCursor(Texture2D texture)
    {
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.ForceSoftware);
    }
}
