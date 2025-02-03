using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;

    [SerializeField]
    float currentHealth;

    [SerializeField]
    Image healthBar;

    float healthProbeta = 0;

    bool valMedkit;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }


    public void TakeDamage(float damage)
    {
        if (IsAlive())
        {
            currentHealth -= damage;
        }

        if (!IsAlive())
        {
            Die();
        }
    }

    public bool IsAlive()
    {
        return currentHealth > 0f;
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        SceneManager.LoadScene("GameOver");
    }

    public void TakeDamageOfZombies(float damage)
    {
        currentHealth -= Mathf.Abs(damage);

        if (currentHealth <= 0.0F)
        {
            Die();
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Player")
    //    {
    //        RestoreHealth(true);
    //    }
    //}

    public void RestoreHealth(bool takeMedkit)
    {
        Debug.Log("¡¡Se entro al proceso de recuperación!!");
        valMedkit = takeMedkit;
        if (valMedkit)
        {
            healthProbeta = 25;
			Debug.Log(healthProbeta);
			currentHealth += healthProbeta;
        }        
    }
}
