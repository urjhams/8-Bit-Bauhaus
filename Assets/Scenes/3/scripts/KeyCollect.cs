using UnityEngine;
using UnityEngine.UI;
public class KeyCollect : selfCollect
{
    public Text dialogContent;
    public override void OnMouseDown()
    {
        gameObject.transform.parent.GetComponent<AudioSource>().Play();
        base.OnMouseDown();
        dialogContent.text = "This key seem useful some where, probably I should back again to my apartment to take a look";
        GameManager.Room3.goal = true;
    }
}
