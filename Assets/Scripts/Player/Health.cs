using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int health = 20;

    private int MAX_HEALTH = 20;

    // Update is called once per frame

    public void Damage(int amount)
    {
        Debug.Log("Damage");
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Healing");
        }

        if (health + amount > MAX_HEALTH)
        {
            health = MAX_HEALTH;
        }

        health += amount;
    }

    public int GetHealth()
    {
        return health;
    }
    
    private void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Opening_Scene");
    }
}
