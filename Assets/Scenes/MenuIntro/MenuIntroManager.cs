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
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("Intro");
        checkOver();
    }
    private void checkOver()
    {
        currentTime = player.time;
        print(currentTime);
        print(length);
        if (currentTime >= length - 0.05)
        {
            SceneManager.LoadScene("Intro");
        }
    }
}
