
public class lastPeiceCollect : selfCollect
{
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        GameManager.Room1Basement.lastPeice = false;
    }
}
