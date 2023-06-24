using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject enemyPrefab;

    public Enemy CurrentEnemy { get; private set; }

    private int currentLevel = 1;
    private int maxLevel = 5;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        if (currentLevel <= maxLevel)
        {
            GameObject enemyObject = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            CurrentEnemy = enemyObject.GetComponent<Enemy>();
        }
        else
        {
            PlayerWon();
        }
    }

    public void PlayerWon()
    {
        Debug.Log("You win!");
    }
}
