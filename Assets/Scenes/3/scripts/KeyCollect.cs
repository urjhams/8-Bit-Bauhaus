using UnityEngine.SceneManagement;
public class KeyCollect : selfCollect
{
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        Helper.hideInventory();
        SceneManager.LoadScene("Room 3 End");
    }
}
