
using UnityEngine;

public class GlobalMouseControl : MonoBehaviour
{
    public Collider2D col;
    [HideInInspector] public string currentHover = "None";

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        print(col.name);
        currentHover = col.name;
        if (currentHover.Contains("interact"))
        {
            Helper.setMouseStatus(MouseStatus.Click);
        } 
        else if (currentHover.Contains("discover"))
        {
            Helper.setMouseStatus(MouseStatus.Inspect);
        } 
        else if(currentHover.Contains("grab"))
        {
            Helper.setMouseStatus(MouseStatus.Grap);
        }
        else
        {
            Helper.setMouseStatus(MouseStatus.Free);
        }
    }

    private void OnMouseExit()
    {
        Helper.setMouseStatus(MouseStatus.Free);
        currentHover = "None";
    }
}
