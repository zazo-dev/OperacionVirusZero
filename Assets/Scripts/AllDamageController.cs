using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDamageController : MonoBehaviour
{
	[SerializeField]
	int swordDamage; //Maneja el daño de la espada.

	[SerializeField]
	int rocketDamage; //Maneja el daño de la bala del cohete.

	[SerializeField]
	int health; //Maneja la vida de los enemigos (normales y jefe).

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("SwordRocketImpact"))
		{
			Debug.Log("¡¡Hiciste daño al enemigo!!");
			health -= swordDamage;
		}


		if (other.gameObject.layer == LayerMask.NameToLayer("SwordRocketImpact"))
		{
			Debug.Log("¡¡Hiciste daño al enemigo!!");
			health -= rocketDamage;
		}


		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}

}

