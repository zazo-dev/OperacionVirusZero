using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("MainMap"); // Cargar la escena para jugar de nuevo
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Cargar la escena del menú principal
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
