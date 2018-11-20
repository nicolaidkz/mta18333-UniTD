using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IronPython.Hosting;

public class WaveSpawner : MonoBehaviour
{
    // This works like boolean variable but instead of only states (true and false) this has 3 states
    public enum SpawnState { Spawning, Waiting, Counting };

    // This creates a headline in the unity inspector with the class wave
    [System.Serializable]
    public class Wave
    {
        // These are all variable related to the wave and they can all be changed in the inspector
        // names is the name of the wave in this case just a number, transform enemy is the enemy preFab, enemycount is the number of enemy's in that wave
        // and lastly spawnrate determines how fast the enemy's spawn in
        public string name;
        public Transform enemy;
        public Transform enemy2;
        public int enemyCount;
        public float spawnRate;
    }

    // This is an array that is created in the unity inspector with as many waves as we want to
    public Wave[] waves;
    // increments on this variable to spawn the next wave
    private int nextWave = 0;

    // This is a timer created to make the program check whether enemy's are alive or not every second rather than every frame
    private float searchCountdown = 1f;

    // here we create the state object and initialize it with counting
    private SpawnState state = SpawnState.Counting;

    // This is our spawnpoint (our start node)
    public Transform spawnPoint;

    // wave countdown text and a debugger text for the ironPython implementation
    public Text waveCountdownText;
    public Text pythonDebugNotif;

    // first we call up the scriptengine
    Microsoft.Scripting.Hosting.ScriptEngine cvEngine;

    private void Start()
    {
        // and assign the ironPython engine on start
        cvEngine = global::UnityPython.CreateEngine();
        PlayerStats.victoryDeterminator = false;
    }

    void Update()
    {
        if (state == SpawnState.Waiting)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (state != SpawnState.Spawning)
            {
                Debug.Log("Space bar pressed");
                waveCountdownText.text = "Wave " + (nextWave + 1).ToString() + " is spawning";
                StartCoroutine(SpawnWave(waves[nextWave]));
                state = SpawnState.Waiting;
            }
        }

        // adress of script
        var script = cvEngine.CreateScriptSourceFromFile("Assets/Python/test.py");
        // scope of script
        var scope = cvEngine.CreateScope();
        script.Execute(scope);
        // get variable from script
        string result = scope.GetVariable<string>("debugText");
        // set variable in text field
        pythonDebugNotif.text = result;
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.Counting;

        if (nextWave + 1 > waves.Length - 1)
        {
            waveCountdownText.text = " ";
            PlayerStats.victoryDeterminator = true;
            nextWave = 0;
            //Debug.Log("All waves complete! Looping back to start...");
        }
        else
        {
            waveCountdownText.text = "Press space to spawn next wave.";
            PlayerStats.waveCounter++;
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.Spawning;

        for (int i = 0; i < _wave.enemyCount; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.spawnRate);
            SpawnEnemy2(_wave.enemy2);
            yield return new WaitForSeconds(1f / _wave.spawnRate);
        }

        state = SpawnState.Waiting;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
        //Debug.Log("Spawning wave number: " + _enemy.name);
    }
    void SpawnEnemy2(Transform _enemy2)
    {
        Instantiate(_enemy2, spawnPoint.position, spawnPoint.rotation);
        //Debug.Log("Spawning wave number: " + _enemy.name);
    }
}