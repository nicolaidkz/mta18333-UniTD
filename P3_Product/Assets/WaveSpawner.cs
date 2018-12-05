using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public GameObject posMaster;

    // This works like boolean variable but instead of only states (true and false) this has 3 states
    public enum SpawnState { Spawning, Waiting, Counting };

    // true if you are allowed to place towers, false if not.
    public bool place;

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

    private void Start()
    {
        // the victoryDeterminator is set to false in the start method to make sure that the game starts fresh everytime the scene is loaded which happens when we press retry or play again
        PlayerStats.victoryDeterminator = false;
        // set place to true, since we need to be able to place towers at start of game
        place = true;
    }

    void Update()
    {
        // if the spawnState is waiting and the enemy is not alive the wave had been completed and the waveCompleted method is called otherwise it simply returns and since there are stil enemy's on the board
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

        // here we spawn the wave of enemy's once the space bar is pressed this is done with the GetKeyDown method
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // this is where we initiate the CV to get our positions. TODO: base spawn state on whether we are detecting.

            var cScript = posMaster.GetComponent<ClientScript>();
            cScript.GetPosition();

            // if the spawnState is spawning we first write a log to the console window that let us know that the space bar has been pressed
            // it then sets the two text canvas's to be invisible
            // it then write to that same text canvas that the wave # is spawning
            // it the spawns the wave using the StartCoroutine method which takes in our SpawnWave method which takes in the argument of a wave which in this case is our nextWave variable
            // lastly it sets our spawnstate to be waiting
            if (state != SpawnState.Spawning)
            {
                Debug.Log("Space bar pressed");
                waveCountdownText.text = "Wave " + (nextWave + 1).ToString() + " is spawning";
                StartCoroutine(SpawnWave(waves[nextWave]));
                state = SpawnState.Waiting;

                //Set place to false, since wave is starting.
                place = false;
            }
        }
    }

    // this method is run once the wave is either killed by the towers or the end node and is called in the update method
    void WaveCompleted()
    {
        // set our debug text to be nothing received again after a wave is done!
        var cScript = posMaster.GetComponent<ClientScript>();
        cScript.debugText.text = "NOTHING RECEIVED!";

        // writes a log to the console that we completed the wave
        Debug.Log("Wave Completed!");

        // Set place to true since we are between waves
        place = true;
        
        // sets the spawnstate to be counting
        state = SpawnState.Counting;

        // say we have three waves then nextWave will be 0 1 2 and waves.length will be 3 so by adding one to nextwave and subtracting 1 from waves.Length we have 3 > 2 which is true
        // when this happens the game is over and in this case won so the victoryDeterminator variable from the playerStats class is set to true and the nextWave variable is set to 0 so it's ready for a new game
        if (nextWave + 1 > waves.Length - 1)
        {
            waveCountdownText.text = " ";
            PlayerStats.victoryDeterminator = true;
            nextWave = 0;
            //Debug.Log("All waves complete! Looping back to start...");
        }
        // otherwise is if there are still more waves left this piece of code is run
        // first the Text canvas's are set to visible between the waves
        // then the text is set
        // then the waveCounter from the playerStats class is incremented
        // lastly the nextWave variable is incremented
        else
        {
            waveCountdownText.text = "Press space to spawn next wave.";
            PlayerStats.waveCounter++;
            nextWave++;
        }
    }

    // this method determines whether an enemy is alive or not and returns a boolean value
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            // it searches for any game object with the tag "Enemy" and checks if any of them are alive if not it returns false to let the program know there are no enemy's on the map
            // other wise it jumps down and return true to signal that there are still enemy's on the map
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    // this method spawns the wave that it is passed as it's arguement when it's called
    IEnumerator SpawnWave(Wave _wave)
    {
        // sets the spawnstate to spawning
        state = SpawnState.Spawning;

        // if we are at wave number 2 and that wave have 20 enemy's then it says 2 < 2.20 in the second part of the for loop and it does this for every wave
        for (int i = 0; i < _wave.enemyCount; i++)
        {
            if (i == 4 || i == 8 || i == 12 || i == 16 || i == 20 || i == 24) { // If i is any of these values, spawn enemy type 2
                SpawnEnemy2(_wave.enemy2);
                yield return new WaitForSeconds(1f / _wave.spawnRate);
            }
            else // else spawn enemy type 1
            {
                SpawnEnemy(_wave.enemy);
                yield return new WaitForSeconds(1f / _wave.spawnRate);
            }
        }

        // then the spawnstate is set to waiting and then we break from the method. we have to either yield break or yield return since it's an IEnumerator method
        state = SpawnState.Waiting;

        yield break;
    }

    // here we spawn the enemy's by passing it a wave and an enemy prefab
    void SpawnEnemy(Transform _enemy)
    {
        // instantiate's the enemy's that where passed in the spawnPoint Start
        Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
        //Debug.Log("Spawning wave number: " + _enemy.name);
    }
    void SpawnEnemy2(Transform _enemy2)
    {
        Instantiate(_enemy2, spawnPoint.position, spawnPoint.rotation);
        //Debug.Log("Spawning wave number: " + _enemy.name);
    }
}