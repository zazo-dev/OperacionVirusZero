using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbetaFinalGameController : MonoBehaviour
{
    [SerializeField]
	float healthProbeta;

	[SerializeField]
	bool ProbetaSelected;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Debug.Log("¡¡Recogiste una probeta!!, obtuviste un total de: " + healthProbeta + " de HP.");
			other.GetComponent<ThirdPersonController>().HP_Min += healthProbeta;
			if (ProbetaSelected)
			{
				Destroy(gameObject);
			}
		}
	}
}
