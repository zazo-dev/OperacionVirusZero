using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoss : MonoBehaviour
{
    public int damage;
	// Start is called before the first frame update

	void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            coll.GetComponent<ThirdPersonController>().HP_Min -= damage;
        }
       
       
    }
}
