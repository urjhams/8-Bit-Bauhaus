using UnityEngine.Video;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public VideoPlayer player;
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
        print(currentTime);
        print(length);
        if (currentTime >= length - 0.05)
        {
            SceneManager.LoadScene("Room 1");
        }
    }
}
