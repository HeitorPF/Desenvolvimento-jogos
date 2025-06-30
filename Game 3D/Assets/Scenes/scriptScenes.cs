using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        SceneManager.UnloadSceneAsync(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReiniciarGame()
    {
        SceneManager.LoadScene(1);
        SceneManager.UnloadSceneAsync(2);
    }
}