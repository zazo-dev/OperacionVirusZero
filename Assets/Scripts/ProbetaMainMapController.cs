using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbetaMainMapController : MonoBehaviour
{
    [SerializeField]
    bool ProbetaSelected;

    PlayerHealth playerHealth;

	private void Awake()
	{
        playerHealth = FindObjectOfType<PlayerHealth>();
	}

	private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("¡¡Recogiste la probeta, obtienes 50 HP!!");
            playerHealth.RestoreHealth(true);
			if (ProbetaSelected)
            {
                Destroy(gameObject);
            }
        }
    }
}
