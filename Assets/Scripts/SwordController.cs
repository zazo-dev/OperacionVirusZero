using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
	[SerializeField]
	float swordDamageF;

	private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Boss"))
        {
			coll.GetComponent<Boss>().HP_Min -= swordDamageF;
        }    
    }
}
