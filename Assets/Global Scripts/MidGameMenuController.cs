using UnityEngine.SceneManagement;
using UnityEngine;

public class MidGameMenuController : MonoBehaviour
{
    public void toMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
