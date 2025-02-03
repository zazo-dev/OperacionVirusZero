using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    public float minChaseDistance = 20f;
    public float attackDistance = 1f;
    public string targetTag = "Player";
    public float damage = 10f;
    public float damageTimer; // Tiempo de espera entre ataques

    private GameObject target;
    private NavMeshAgent navAgent;
    private Animator animator;
    private bool isAttacking;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = FindObjectByLayer(targetTag);
    }

    private GameObject FindObjectByLayer(string layerName)
    {
        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj.layer == LayerMask.NameToLayer(layerName))
            {
                return obj;
            }
        }
        return null;
    }

    private void Update()
    {
        damageTimer -= Time.deltaTime;

        if (target != null)
        {
            target = FindObjectByLayer(targetTag);
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

            if (distanceToTarget <= minChaseDistance)
            {
                ChaseOrAttackTarget(distanceToTarget);
            }
            else
            {
                StopChasing();
            }
        }
    }

    private void ChaseOrAttackTarget(float distanceToTarget)
    {
        if (distanceToTarget <= attackDistance)
        {
            return;
        }
        else
        {
            ChaseTarget();
        }
    }

    private void ChaseTarget()
    {
        navAgent.SetDestination(target.transform.position);
        animator.SetBool("IsWalking", true);
        animator.SetBool("IsAttacking", false);
    }

    private void StopChasing()
    {
        navAgent.ResetPath();
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsAttacking", false);
    }

    private void AttackTarget()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            navAgent.ResetPath();
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsAttacking", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.CompareTag("Player"))
        {

            AttackTarget();

            if (damageTimer <= 0)
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                Debug.Log("2");
                playerHealth.TakeDamage(damage);
                damageTimer = 5;
            }

        }
    }

    public void FinishAttack()
    {
        isAttacking = false;
    }
}
