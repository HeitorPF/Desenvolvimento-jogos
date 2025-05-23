using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class scriptMenu : MonoBehaviour
{
    public EventSystem eventSystem;
    public void Start()
    {
        eventSystem.enabled = true;
    }
    // Start is called before the first frame update
    public void iniciar()
    {
        Time.timeScale = 1;
        eventSystem.enabled = false;
        SceneManager.LoadSceneAsync(1);
        
    }
    
    public void sair()
    {
        Application.Quit();
    }
}
