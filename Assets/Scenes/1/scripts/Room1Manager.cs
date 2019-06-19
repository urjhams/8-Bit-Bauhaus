using UnityEngine;

public class Room1Manager : CursorHandle
{
    
    public GameObject birdFood;
    public GameObject inventory;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (GameManager.staticInventory != null) {
            inventory = GameManager.staticInventory;
        } else {
            GameManager.staticInventory = inventory;
        }
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        birdFood.SetActive(GameManager.Room1.birdFood);
    }
    protected override void Update()
    {
        updateStatuesArm();
    }
    public void updateStatuesArm()
    {
        base.Update();
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
        catch {}
    }
}
