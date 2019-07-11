using UnityEngine;
using UnityEngine.UI;
public class Room1Manager : CursorHandle
{
    public Canvas dialogCanvas;
    public GameObject lastPeice;
    public GameObject[] fadeInGroup;
    [SerializeField] public Text dialogBox;
    private bool boxUnlocked = false;
    void Start()
    {
        Helper.setMouseStatus(MouseStatus.Free);
        Tooltip.hideToolTip_Static();
        Helper.showInventory();
        try
        {
            GameObject.Find("outside_dark").SetActive(GameManager.Room3.goal);
        }
        catch { }
        if (!GameManager.Room1.statuesDone)
        {
            dialogBox.text = "So here is the former room my grandma used to stay...";
            dialogCanvas.transform.Find("Text name").gameObject.GetComponent<Text>().text = "Sophia";
            dialogCanvas.enabled = true;
            Helper.inDetail = true;
        }
    }
    protected override void Update()
    {
        base.Update();
        updateStatuesArm();
        updateGoal();
    }
    public void updateStatuesArm()
    {
        try
        {
            for (int i = 0; i < GameManager.Room1.leftArm.Length; i++)
            {
                Helper.getSpriteRendererOf(GameManager.Room1.leftArm[i]).enabled =
                (i == GameManager.Room1.currentLeftArm);
            }
            for (int i = 0; i < GameManager.Room1.rightArm.Length; i++)
            {
                Helper.getSpriteRendererOf(GameManager.Room1.rightArm[i]).enabled =
                (i == GameManager.Room1.currentRightArm);
            }
        }
        catch { }
    }

    public void updateGoal()
    {
        if (GameManager.Room1.goal)
        {
            lastPeice.GetComponent<SpriteRenderer>().enabled = true;
            if (GameManager.Room1.addedPeice.Count >= 11)
            {
                dialogBox.text = "Wow the box is unlocked!";
                if (Helper.inDetail)
                {
                    if (!boxUnlocked)
                    {
                        try
                        {
                            GameObject.Find("puzzle box").GetComponent<AudioSource>().Play();
                        }
                        catch { }
                        boxUnlocked = true;
                    }
                }
            }
        }
        if (!Helper.inDetail && GameManager.Room1.goal && GameManager.Room1.addedPeice.Count >= 11)
        {
            if (GameManager.Room3.goal)
                return;
            Helper.inDetail = true;
            try
            {
                GameObject.Find("bowl with box_discover").SetActive(false);
                GameObject.Find("ladder_discover").GetComponent<Collider2D>().enabled = false;
            }
            catch { }
            foreach (var item in fadeInGroup)
            {
                item.GetComponent<ObjectFadeIn>().startFading();
                try
                {
                    item.GetComponent<Collider2D>().enabled = true;
                }
                catch { }
            }
        }
    }
}
