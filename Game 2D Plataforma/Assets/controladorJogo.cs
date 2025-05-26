using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class controladorJogo : MonoBehaviour
{
    private bool pause = false;
    private controladorObjetivo objetivo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                SceneManager.UnloadSceneAsync(2);
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
                SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
                
            }

            pause = !pause;
        }
    }

}
