using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] Transform enemyPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] TextMeshProUGUI waveCountdownText;

    private float countdown = 2f;
    private int waveIndex = 0;

    private void Update()
    {
        //Countdown for next wave.
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;

        }
        countdown -= Time.deltaTime;

        //Mathf.Round removes decimals and rounds it down.
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }
    IEnumerator SpawnWave()
    {
        //Spawns wave inc. enemy's.
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }        
    }
    //Spawns the enemy's at the right place.
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
