using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string finalGameSceneName = "FinalGame"; // Nombre de la nueva escena (FinalGame)
    public string finalGamePortalTag = "FinalGamePortal"; // Etiqueta del portal en la escena FinalGame

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisiona es el jugador
        if (other.CompareTag("Player"))
        {
            // Desactivar el collider del portal para evitar su reutilización
            GetComponent<Collider>().enabled = false;

            // Colocar al jugador en la posición del portal actual antes de cargar la nueva escena
            Transform playerTransform = other.transform;
            Transform portalTransform = transform; // Transform del portal actual

            // Guardar la posición y rotación del jugador en relación con el portal
            Vector3 offset = playerTransform.position - portalTransform.position;
            Quaternion rotationOffset = Quaternion.Inverse(portalTransform.rotation) * playerTransform.rotation;

            // Cargar la nueva escena (FinalGame)
            SceneManager.LoadScene(finalGameSceneName);

            // Después de cargar la escena, buscar el portal en FinalGame y colocar al jugador en su posición
            SceneManager.sceneLoaded += (scene, mode) =>
            {
                if (scene.name == finalGameSceneName)
                {
                    GameObject finalGamePortal = GameObject.FindGameObjectWithTag(finalGamePortalTag);
                    if (finalGamePortal != null)
                    {
                        // Verificar si el jugador aún existe y no ha sido destruido
                        if (playerTransform != null)
                        {
                            // Colocar al jugador en la posición del portal en FinalGame
                            playerTransform.position = finalGamePortal.transform.position + offset;
                            playerTransform.rotation = finalGamePortal.transform.rotation * rotationOffset;

                            // Mostrar mensaje de teletransporte exitoso
                            Debug.Log("¡Jugador teletransportado exitosamente!");
                        }
                        
                    }                  
                    else
                    {
                        Debug.LogWarning("No se encontró el portal en la escena FinalGame.");
                    }
                }

                // Desuscribirse del evento de carga de escena una vez completado
                SceneManager.sceneLoaded -= null;
            };
        }
    }
}
