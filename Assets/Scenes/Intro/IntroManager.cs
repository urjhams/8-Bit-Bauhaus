using System;
using UnityEngine.Video;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public VideoPlayer player;
    double length;
    double currentTime;
    // Start is called before the first frame update
    void Start()
    {
        length = player.clip.length;
    }

    private void Awake()
    {
        Screen.SetResolution(1366, 720, false);
    }

    // Update is called once per frame
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
            print("end");
            SceneManager.LoadScene("Room 1");
        }
    }
}
