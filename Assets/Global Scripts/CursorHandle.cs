using UnityEngine;

public class CursorHandle : MonoBehaviour
{
    public Sprite freeMouse;
    public Sprite grabMouse;
    public Sprite clickMouse;
    public Sprite inspectMouse;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        Cursor.visible = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;

        switch (Helper.Global.mouseStatus)
        {
            case Helper.MouseStatus.Click:
                updateSprite(clickMouse);
                break;
            case Helper.MouseStatus.Free:
                updateSprite(freeMouse);
                break;
            case Helper.MouseStatus.Grap:
                updateSprite(grabMouse);
                break;
            case Helper.MouseStatus.Inspect:
                updateSprite(inspectMouse);
                break;
        }
    }
    private void updateSprite(Sprite sprite)
    {
        //print(message: spriteRenderer.sprite.name);
        spriteRenderer.sprite = sprite;
    }
}
