using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    private const string sceneName = "Game";

    public void Restart()
    {
        SceneManager.LoadScene(sceneName);
    }
}
