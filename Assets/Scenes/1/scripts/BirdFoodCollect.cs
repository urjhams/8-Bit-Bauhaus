public class BirdFoodCollect : CollectInside
{
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        GameManager.Room1.birdFood = false;
    }
}
