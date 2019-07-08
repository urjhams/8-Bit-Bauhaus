using UnityEngine.Video;
using UnityEngine;

public class Room2Manager : CursorHandle
{
    public GameObject mainObject;
    public GameObject cutsceneCamera;
    public VideoPlayer player;
    public GameObject plate;
    public Canvas plateDialogCanvas;
    double length;
    double currentTime;
    void Start()
    {
        Helper.setMouseStatus(MouseStatus.Free);
        Tooltip.hideToolTip_Static();
        length = player.clip.length;
        Helper.showInventory();
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
        mainObject.SetActive(!Helper.inDetail);
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
    private void HideMainIfNeed() {
        if (Helper.inDetail)
            mainObject.SetActive(true);
        else
            mainObject.SetActive(false);
    }
}
