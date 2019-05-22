using UnityEngine;

public class CursorHandle : MonoBehaviour
{
    public Texture2D freeMouse;
    public Texture2D grabMouse;
    public Texture2D clickMouse;
    public Texture2D inspectMouse;

    void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;

        switch (Helper.mouseStatus)
        {
            case MouseStatus.Click:
                updateSprite(clickMouse);
                break;
            case MouseStatus.Free:
                updateSprite(freeMouse);
                break;
            case MouseStatus.Grap:
                updateSprite(grabMouse);
                break;
            case MouseStatus.Inspect:
                updateSprite(inspectMouse);
                break;
        }
    }
    private void updateSprite(Texture2D texture)
    {
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
    }
}
