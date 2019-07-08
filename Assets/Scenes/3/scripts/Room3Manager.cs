
public class Room3Manager : CursorHandle
{
    void Start()
    {
        Helper.setMouseStatus(MouseStatus.Free);
        Tooltip.hideToolTip_Static();
        Helper.inDetail = false;
        Helper.showInventory();
    }
    protected override void Update() 
    {
        base.Update();

    }
}
