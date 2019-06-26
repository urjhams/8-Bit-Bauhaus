using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        for (int i = 0; i < gameObject.scene.GetRootGameObjects().Length; i++)
        {
            if (i > 1)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
