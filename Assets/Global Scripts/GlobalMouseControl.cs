
using UnityEngine;

public class GlobalMouseControl : MonoBehaviour
{
    public Collider2D col;
    [HideInInspector] public string currentHover = "None";
    [HideInInspector] public bool inDetail = false;

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
            if (!inDetail)
                Helper.setMouseStatus(MouseStatus.Click);
        } 
        else if (currentHover.Contains("discover"))
        {
            if (!inDetail)
                Helper.setMouseStatus(MouseStatus.Inspect);
            else
                Helper.setMouseStatus(MouseStatus.Free);
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
}
