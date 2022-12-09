using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;
    [SerializeField] private int scoreDamage = 10;
    [SerializeField] private int consecutiveHits;
    [SerializeField] private GameObject skeletonPrefab;
    [SerializeField] private GameObject mushroomPrefab;

    [SerializeField] private float skeletonInterval = 3.5f;
    [SerializeField] private float mushroomInterval = 5f;
    private int mulitplier;
    private void OnEnable()
    {
        EnemyAI.OnDamageEnemy += AddPoints;
        Arrow.CheckConsecutive += increaseMultiplier;
    }

    private void OnDisable()
    {
        
    }

    private void Start()
    {
        StartCoroutine(spawnEnemy(skeletonInterval, skeletonPrefab));
        //StartCoroutine(spawnEnemy(mushroomInterval, mushroomPrefab));
    }

    private void Awake()
    {
        score = 0;
        mulitplier = 1;
        consecutiveHits = 0;
        //enemies = FindObjectsOfType<EnemyAI>().ToList();
        UpdateScore();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
    
    void UpdateScore()
    {
        scoreText.text = $"{mulitplier}x {score}";
    }

    void AddPoints(EnemyAI enemyAI)
    {
        score += (scoreDamage*mulitplier);
    }

    void increaseMultiplier(bool hit)
    {
        if (hit && consecutiveHits <= 3)
        {
            consecutiveHits++;
        }
        if (consecutiveHits >= 4)
        {
            consecutiveHits = 0;
            mulitplier++;
        }
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject spawn = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), 
                                        Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(skeletonInterval, skeletonPrefab));
    }
}
