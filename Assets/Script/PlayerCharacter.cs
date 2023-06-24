using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int baseAttack = 10;
    private float attackIncreasePercentage = 1.2525f;

    private int currentLevel = 1;
    private int maxLevel = 5;

    private int currentExperience;
    private int experienceToNextLevel = 100;

    private bool canLevelUp = false;
    private bool levelUpNotified = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LevelUpButtonPressed();
        }

        if (canLevelUp && !levelUpNotified)
        {
            Debug.Log("You can level up now! Press 'L' to level up.");
            levelUpNotified = true;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Debug.Log("Player defeated!");
            PlayerLost();
        }
    }

    public void GainExperience(int experience)
    {
        currentExperience += experience;

        if (currentExperience >= experienceToNextLevel)
        {
            canLevelUp = true;
        }

        Debug.Log("Gained " + experience + " experience!");

        // Show the experience needed for the next level
        Debug.Log("Experience needed for next level: " + (experienceToNextLevel - currentExperience));
    }

    private void LevelUpButtonPressed()
    {
        if (canLevelUp)
        {
            LevelUp();
            canLevelUp = false;
            levelUpNotified = false;
        }
        else
        {
            Debug.Log("Not enough experience to level up!");
        }
    }

    private void LevelUp()
    {
        if (currentLevel < maxLevel)
        {
            currentLevel++;
            Debug.Log("Level up! Player reached level " + currentLevel);

            // Increase the player's attack value by 125.25% (1.2525)
            baseAttack = Mathf.RoundToInt(baseAttack * attackIncreasePercentage);

            // Update the experience required for the next level
            experienceToNextLevel = Mathf.RoundToInt(experienceToNextLevel * 1.5f);
        }
        else
        {
            Debug.Log("Player reached the maximum level!");
            PlayerWon();
        }
    }

    private void Attack()
    {
        if (GameManager.Instance.CurrentEnemy != null)
        {
            int damage = baseAttack;
            Debug.Log("Player (Level " + currentLevel + ") attacks for " + damage + " damage.");
            GameManager.Instance.CurrentEnemy.TakeDamage(damage);
        }
    }

    private void PlayerWon()
    {
        Debug.Log("You win!");
        // Perform any necessary game end actions here
    }

    private void PlayerLost()
    {
        Debug.Log("You lost!");
        // Perform any necessary game end actions here
    }
}
