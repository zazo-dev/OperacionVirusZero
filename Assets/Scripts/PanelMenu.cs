using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelMenu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("MainMap");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode(); // Salir del modo de juego en el editor
#else
        Application.Quit(); // Salir del juego en una build final
#endif
    }
}
