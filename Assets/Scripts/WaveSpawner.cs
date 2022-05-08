using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public static int enemiesAlive = 0;
    public Wave[] waves;
    public float timeBetweenWaves = 1f;
    private float countdown = 3f;
    private int waveIndex = 0;
    public Transform spawnPoint;
    public Text waveCountdownText;
    public GameManager gameManager;
    public bool stopRounds = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Pause after each wave

        if (enemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            Debug.Log("Level complete");
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (stopRounds)
        {
            return;
        }
        if (countdown <= 0) 
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
        //waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    /*IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];
        enemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;

        
    }*/

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];
        enemiesAlive = CalcEnemies(wave);
        for (int i = 0; i < wave.enemy.Length; i++)
        {
            for (int j = 0; j < wave.count[i]; j++)
            {
                SpawnEnemy(wave.enemy[i]);
                yield return new WaitForSeconds(1f / wave.rate[i]);
            }
            
        }

        waveIndex++;
        PlayerStats.Money += 100;


    }


    void SpawnEnemy(GameObject enemy) 
    {
        
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }


    int CalcEnemies(Wave wave)
    {
        int count = 0;
        for (int i = 0; i < wave.count.Length; i++)
        {
            count += wave.count[i];
        }

        return count;
    }

    public void StartStop()
    {
        stopRounds = !stopRounds;
    }
}
