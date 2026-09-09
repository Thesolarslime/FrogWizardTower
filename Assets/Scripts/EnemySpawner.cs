using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private float spwan_timer;
    public List<GameObject> Enemys = new List<GameObject>();
    Vector2 randomPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spwan_timer = GameManager.instance.SpawnTimeRandomiser();
    }

    float ElapsedTime = 0f;
    private float RandomYSpawnLoaction;
    private float RandomXSpawnLocation;

    // Update is called once per frame
    void Update()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > spwan_timer && ElapsedTime != 0)
        {
            RandomXSpawnLocation = Random.Range(-10, 10);
            RandomYSpawnLoaction = Random.Range(-10, 10);

            randomPosition.x = transform.position.x + RandomXSpawnLocation;

            randomPosition.y = transform.position.y + RandomYSpawnLoaction;

            Instantiate(Enemys[Random.Range(0,Enemys.Count)],randomPosition,Quaternion.identity);
            spwan_timer = GameManager.instance.SpawnTimeRandomiser();
            ElapsedTime = 0f;
        } 
    }
}
