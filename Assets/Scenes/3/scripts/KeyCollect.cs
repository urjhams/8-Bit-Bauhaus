public class KeyCollect : selfCollect
{
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        GameManager.Room3.goal = true;
    }
}
