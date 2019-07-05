using UnityEngine.Video;
using UnityEngine;

public class Room2Manager : CursorHandle
{
    public GameObject cutsceneCamera;
    public VideoPlayer player;
    public GameObject plate;
    public Canvas plateDialogCanvas;
    double length;
    double currentTime;
    void Start()
    {
        length = player.clip.length;
        try
        {
            GameObject.Find("inventory frame").GetComponent<CanvasRenderer>().SetAlpha(1);
        }
        catch { }
    }
    protected override void Update()
    {
        base.Update();
        if (GameManager.Room2.scewDriverCutScene && GameManager.Room2.goal)
        {
            cutsceneCamera.SetActive(true);
            player.Play();
            GameManager.Room2.scewDriverCutScene = false;
            plateDialogCanvas.enabled = false;
        }
        PlayScewDriverCutScene();
    }
        private void PlayScewDriverCutScene()
    {
        currentTime = player.time;
        if (currentTime >= length - 0.05)
        {
            try
            {
                cutsceneCamera.SetActive(false);
                plate.SetActive(false);
                plateDialogCanvas.enabled = true;
                GameObject.Find("words").GetComponent<Collider2D>().enabled = true;
            }
            catch { }
        }
    }
}
