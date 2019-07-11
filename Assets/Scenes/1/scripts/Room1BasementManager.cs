using UnityEngine.SceneManagement;
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

    void Awake()
    {
        if (!GameManager.Room3.goal)
        {
            GameObject.Find("ambient daylight").GetComponent<AudioSource>().playOnAwake = true;
        } else
        {
            GameObject.Find("ambient night").GetComponent<AudioSource>().playOnAwake = true;
        }
    }
    void Start()
    {
        Helper.setMouseStatus(MouseStatus.Free);
        Tooltip.hideToolTip_Static();
        length = player.clip.length;
        lastPeice.SetActive(GameManager.Room1Basement.lastPeice);
        try
        {
            GameObject.Find("basement_outside_dark").SetActive(GameManager.Room3.goal);
        }
        catch { }
    }

    protected override void Update()
    {
        base.Update();
        try
        {
            GameObject.Find("bird").SetActive(!GameManager.Room1Basement.lastPeiceCollected);
            GameObject.Find("bird_fulfilled").GetComponent<SpriteRenderer>().enabled = GameManager.Room1Basement.lastPeiceCollected && !GameManager.Room3.goal;
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
        if (GameManager.Room1Basement.goal)
        {
            SceneManager.LoadScene("Final End");
        }
    }

    private void wardrobeUpdate()
    {
        try
        {
            GameObject wardrobe = GameObject.Find("wardrobe");
            wardrobe.GetComponent<Collider2D>().enabled = !GameManager.Room1Basement.wardrobeOpen;
            wardrobe.GetComponent<SpriteRenderer>().enabled = !GameManager.Room1Basement.wardrobeOpen;
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
