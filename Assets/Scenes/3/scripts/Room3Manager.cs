using UnityEngine.UI;
using UnityEngine;

public class Room3Manager : CursorHandle
{
    void Start()
    {
        Helper.setMouseStatus(MouseStatus.Free);
        Tooltip.hideToolTip_Static();
    }
    protected override void Update() 
    {
        base.Update();
        
    }
}
