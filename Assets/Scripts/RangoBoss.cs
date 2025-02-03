using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoBoss : MonoBehaviour
{
    public Animator ani;
    public Boss boss;
    public int melee;

    // Start is called before the first frame update

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            melee = Random.Range(0, 4);
            switch (melee)
            {
                case 0:
                    //hit1
                    ani.SetFloat("skills", 0);
                    boss.hit_Select = 0;
                    break;
                case 1:
                    //hit2
                    ani.SetFloat("skills", 0.02539683f);
                    boss.hit_Select = 1;
                    break;
                case 2:
                    //jump
                    ani.SetFloat("skills", 0.05079366f);
                    boss.hit_Select = 2;
                    break;
                case 3:
                    //fireball
                    if (boss.fase == 2)
                    {
                        ani.SetFloat("skills", 0.07619049f);
                    }
                    else
                    {
                        melee = 0;
                    }
                    break;
            }

            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack", true);
            boss.atacando = true;
            GetComponent<CapsuleCollider>().enabled = false;


        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
