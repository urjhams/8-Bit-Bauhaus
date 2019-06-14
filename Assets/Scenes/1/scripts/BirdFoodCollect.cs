public class BirdFoodCollect : selfCollect
{
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        GameManager.Room1.birdFood = false;
    }
}
