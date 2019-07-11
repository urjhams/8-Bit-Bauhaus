using UnityEngine.Video;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalIntroManager : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Escape) && currentTime >= length - 30)
            SceneManager.LoadScene("Menu");
        checkOver();
    }
    private void checkOver()
    {
        currentTime = player.time;
        if (currentTime >= length - 0.05)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
