public class BirdFoodCollect : CollectInside
{
    public override void OnMouseDown()
    {
        if (GameManager.Room1.birdFood)
        {
            base.OnMouseDown();
            GameManager.Room1.birdFood = false;
        }
    }
}
