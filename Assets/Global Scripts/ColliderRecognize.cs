using UnityEngine;

public class ColliderRecognize : MonoBehaviour
{
    public Collider2D col;
    void OnMouseOver()
    {
        print(col.name);
        GameManager.currentOverGameObjectName = col.name;
    }
    void OnMouseExit()
    {
        GameManager.currentOverGameObjectName = "";
    }
}
