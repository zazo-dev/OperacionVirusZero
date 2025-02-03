using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField]
    float rocketDamageF;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Boss"))
        {
            coll.GetComponent<Boss>().HP_Min -= rocketDamageF;
        }
    }
}
