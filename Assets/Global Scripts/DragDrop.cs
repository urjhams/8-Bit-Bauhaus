using UnityEngine;

public class DragDrop : MonoBehaviour
{
    [HideInInspector] public bool locked = false;
    [HideInInspector] public bool selected;
    protected virtual void Start()
    {
    }
    protected virtual void Update()
    {
        if (selected && !locked)
        {
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPosition.x, cursorPosition.y);
            clickingSound();
        }
        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
        }
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            selected = true;
    }
    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("correct " + gameObject.name) && !selected)
        {
            transform.position = other.gameObject.transform.position;
            locked = true;
            selected = !selected;
            GameManager.Room1.addedPeice.Add(gameObject.name);
            correctingPuzzle(name);
        }
    }
    private void correctingPuzzle(string name)
    {
        bool exist = false;
        try
        {
            foreach (string item in GameManager.Room1.addedPeice)
            {
                if (item.Equals(name))
                {
                    if (!exist)
                    {
                        exist = true;
                    }
                    else
                    {
                        GameManager.Room1.addedPeice.Remove(item);
                    }
                }
            }
        }
        catch { }
    }
    public virtual void clickingSound()
    {
        try
        {
            GameObject.Find("Background").GetComponent<AudioSource>().Play();
        }
        catch { }
    }
}
