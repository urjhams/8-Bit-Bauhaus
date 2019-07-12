using UnityEngine;
public class BirdFoodCollect : CollectInside
{
    public override void OnMouseDown()
    {
        if (GameManager.Room1.birdFood)
        {
            base.OnMouseDown();
            try
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
            catch { }
            GameManager.Room1.birdFood = false;
        }
    }
}
