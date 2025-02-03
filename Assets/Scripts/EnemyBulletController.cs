using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField]
    float damage;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("BUSCANDO");
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            Debug.Log("ATQUE POR BALA");
            playerHealth.TakeDamage(damage);
        }
    }

}
