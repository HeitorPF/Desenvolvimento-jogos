using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class controladorObjetivo : MonoBehaviour
{
    public void Reiniciar()
    {
        SceneManager.LoadScene(1);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
