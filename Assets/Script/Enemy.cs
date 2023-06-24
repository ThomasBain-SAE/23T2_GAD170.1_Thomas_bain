using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int baseHealth = 25;
    public int currentHealth;

    public int experienceReward;
    public int enemyLevel;


    private int minExperienceReward = 50;
    private int maxExperienceReward = 100;

    private void Start()
    {
        // Assign a random level between 1 and 6
        enemyLevel = Random.Range(1, 5);

        // Scale the enemy's health based on their level
        currentHealth = Mathf.RoundToInt(baseHealth * enemyLevel);

        // Calculate a random experience reward within the specified range
        experienceReward = Random.Range(minExperienceReward, maxExperienceReward + 1);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            Debug.Log("Enemy took " + damage + " damage!");

            // Display the updated enemy status
            DisplayEnemyStatus();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy defeated! Player gains " + experienceReward + " experience.");

        PlayerCharacter player = FindObjectOfType<PlayerCharacter>();
        if (player != null)
        {
            player.GainExperience(experienceReward);
        }
        else
        {
            Debug.LogError("PlayerCharacter not found in the scene!");
        }

        Destroy(gameObject);

        GameManager.Instance.SpawnEnemy(); // Spawn a new enemy
    }

    public string GetEnemyStatus()
    {
        return string.Format("Enemy Level: {0}\nHealth: {1}/{2}\nExperience Reward: {3}", enemyLevel, currentHealth, baseHealth * enemyLevel, experienceReward);
    }

    public void DisplayEnemyStatus()
    {
        Debug.Log(GetEnemyStatus());
    }
}
