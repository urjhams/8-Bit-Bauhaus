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
        if (SceneManager.GetActiveScene().name.Equals("Final End") || SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            Destroy(gameObject);
        }
    }
}
