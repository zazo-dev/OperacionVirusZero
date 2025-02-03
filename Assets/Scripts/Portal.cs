using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalGamePortal : MonoBehaviour
{
    private bool portalUsed = false; // Bandera para verificar si el portal ha sido utilizado

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el portal no ha sido utilizado y el objeto que colisiona es el jugador
        if (!portalUsed && other.CompareTag("Player"))
        {
            // Desactivar el collider del portal para evitar su reutilización
            GetComponent<Collider>().enabled = false;
            portalUsed = true; // Marcar el portal como utilizado

            // Colocar al jugador de vuelta en la escena MainMap
            SceneManager.LoadScene("MainMap"); // Reemplaza "MainMap" con el nombre de tu escena principal
        }
    }
}
