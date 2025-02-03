using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGController : MonoBehaviour
{
    [SerializeField]
    Transform RPGPoint;

    [SerializeField]
    GameObject RPGPrefab;

    [SerializeField]
    float lifeTime;

    [SerializeField]
    float force;

    Animator animator;

    public Ammo rocketAmmo;


    private void Awake()
    {       
       rocketAmmo = FindObjectOfType<Ammo>();
       animator = GetComponent<Animator>();
    }

    //Creación del clon de la bala de la basuca:
    public void OnShootRPG()
    {
        if (rocketAmmo.rockets > 0) 
        {
            rocketAmmo.rockets--;
            GameObject bullet = Instantiate(RPGPrefab, RPGPoint.position, RPGPoint.rotation);
            Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
            rigidbody.AddForce(-(bullet.transform.forward) * force, ForceMode.Force);
            Destroy(bullet, lifeTime);
        }

    }
}
