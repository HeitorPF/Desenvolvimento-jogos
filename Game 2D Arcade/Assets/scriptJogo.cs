using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class scriptJogo : MonoBehaviour
{
    private bool pause;
    public EventSystem eventSystem;
    // Start is called before the first frame update
    void Start()
    {
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            tooglePause();
        }
    }

    void tooglePause()
    {
        if (pause)
        {
            eventSystem.enabled = true;
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync(0);
        }

        else
        {
            eventSystem.enabled = false;
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
        }
        pause = !pause;
    }
}
