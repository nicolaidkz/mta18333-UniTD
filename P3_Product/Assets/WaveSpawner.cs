using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IronPython.Hosting;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPreFab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5.5f;
    private float countdown = 2f;

    public Text waveCountdownText;
    public Text pythonDebugNotif;
    private int waveIndex = 0;

    Microsoft.Scripting.Hosting.ScriptEngine cvEngine;                                                              // first we call up the scriptengine

    private void Start()
    {
        cvEngine = global::UnityPython.CreateEngine();                                                              // and assign the ironPython engine on start

    }

    void Update ()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;

        }
    
        var script = cvEngine.CreateScriptSourceFromFile("Assets/Python/test.py");                                  // adress of script
        var scope = cvEngine.CreateScope();                                                                         // scope of script
        script.Execute(scope);
        string result = scope.GetVariable<string>("debugText");                                                     // get variable from script
        pythonDebugNotif.text = result;                                                                             // set variable in text field
        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave ()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("Wave Incoming!");
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPreFab, spawnPoint.position, spawnPoint.rotation);
    }
}