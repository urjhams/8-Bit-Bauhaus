using UnityEngine.SceneManagement;
public class KeyCollect : selfCollect
{
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        SceneManager.LoadScene("Room 3 End");
    }
}
