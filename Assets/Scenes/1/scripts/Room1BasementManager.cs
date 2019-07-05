using UnityEngine.Video;
using UnityEngine;

public class Room1BasementManager : CursorHandle
{
    public GameObject wardrobeOpened;
    public GameObject cutsceneCamera;
    public GameObject lastPeice;
    public VideoPlayer player;
    double length;
    double currentTime;
    // Start is called before the first frame update
    void Start()
    {
        length = player.clip.length;
        lastPeice.SetActive(GameManager.Room1Basement.lastPeice);
    }

    protected override void Update()
    {
        base.Update();
        try
        {
            GameObject.Find("bird").SetActive(!GameManager.Room1Basement.lastPeiceCollected);
            GameObject.Find("bird_fulfilled").GetComponent<SpriteRenderer>().enabled = GameManager.Room1Basement.lastPeiceCollected;
        }
        catch { }
        wardrobeUpdate();
        if (GameManager.Room1Basement.lastPeiceCutScene && GameManager.Room1Basement.lastPeice)
        {
            cutsceneCamera.SetActive(true);
            player.Play();
            GameManager.Room1Basement.lastPeiceCutScene = false;
        }
        PlayBirdCutCcene();
    }

    private void wardrobeUpdate()
    {
        try
        {
            GameObject wardrobe = GameObject.Find("wardrobe");
            wardrobe.SetActive(!GameManager.Room1Basement.wardrobeOpen);
        }
        catch { }
        wardrobeOpened.SetActive(GameManager.Room1Basement.wardrobeOpen);
    }

    private void PlayBirdCutCcene()
    {
        currentTime = player.time;
        if (currentTime >= length - 0.05)
        {
            try
            {
                cutsceneCamera.SetActive(false);
                lastPeice.SetActive(true);
            }
            catch { }

        }
    }
}
