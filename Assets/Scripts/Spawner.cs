using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{

    public Transform[] SpawnPoints;
    public GameObject Enemy;

    private float timebtwnSpawns;
    public float timereset;
    // Start is called before the first frame update
    void Start()
    {
        timebtwnSpawns = timereset;
    }

    // Update is called once per frame
    void Update()
    {
        int RandSpawns = Random.Range(0, SpawnPoints.Length);
        if (timebtwnSpawns <= 0)
        {
            Instantiate(Enemy, SpawnPoints[RandSpawns].position, SpawnPoints[RandSpawns].rotation);
            timebtwnSpawns = timereset;
        }
        else
        {
            timebtwnSpawns -= Time.deltaTime;
        }
    }
}
