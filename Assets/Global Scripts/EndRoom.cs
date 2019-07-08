using UnityEngine.Video;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRoom : MonoBehaviour
{
    public VideoPlayer player;
    public string nextRoomName;
    double length;
    double currentTime;

    void Start()
    {
        length = player.clip.length;
    }

    void Update()
    {
        checkOver();
    }
    private void checkOver()
    {
        currentTime = player.time;
        if (currentTime >= length - 0.05)
        {
            try {
                SceneManager.LoadScene(nextRoomName);
            } catch {}
        }
    }
}
