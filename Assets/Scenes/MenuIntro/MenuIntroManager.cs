using UnityEngine.Video;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuIntroManager : MonoBehaviour
{
    public VideoPlayer player;
    double length;
    double currentTime;
    void Start()
    {
        length = player.clip.length;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Room 1 Intro");
        checkOver();
    }
    private void checkOver()
    {
        currentTime = player.time;
        if (currentTime >= length - 0.05)
        {
            SceneManager.LoadScene("Room 1 Intro");
        }
    }
}
