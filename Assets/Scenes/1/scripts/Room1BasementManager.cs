using UnityEngine.Video;
using UnityEngine;

public class Room1BasementManager : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        wardrobeUpdate();
        if (GameManager.Room1Basement.lastPeiceCutScene && GameManager.Room1Basement.lastPeice)
        {
            lastPeice.SetActive(true);
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
            cutsceneCamera.SetActive(false);
        }
    }
}
