using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        for (int i = 0; i < gameObject.scene.GetRootGameObjects().Length; i++)
        {
            if (i > 1)
            {
                Destroy(gameObject);
                if (!SceneManager.GetActiveScene().name.Contains("End"))
                {
                    Helper.showInventory(gameObject);
                }
            }
        }
    }

    void Update()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Room 1":
                break;
            case "Room 1 basement":
                break;
            default:
                if (gameObject.name.Contains("background music"))
                    Destroy(gameObject);
                break;
        }
        if (SceneManager.GetActiveScene().name.Equals("Final End") || SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            Destroy(gameObject);
        }
    }
}
