using UnityEngine;

public class CursorHandle : MonoBehaviour
{
    public Texture2D freeMouse;
    public Texture2D grabMouse;
    public Texture2D clickMouse;
    public Texture2D inspectMouse;

    private void Start()
    {
        TextureScale.Bilinear(freeMouse, freeMouse.width / 2, freeMouse.height / 2);
        TextureScale.Bilinear(grabMouse, grabMouse.width / 2, grabMouse.height / 2);
        TextureScale.Bilinear(clickMouse, clickMouse.width / 2, clickMouse.height / 2);
        TextureScale.Bilinear(inspectMouse, inspectMouse.width / 2, inspectMouse.height / 2);
    }

    void Update()
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
            case MouseStatus.Grap:
                updateCursor(grabMouse);
                break;
            case MouseStatus.Inspect:
                updateCursor(inspectMouse);
                break;
        }
    }
    private void updateCursor(Texture2D texture)
    {
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.ForceSoftware);
    }
}
