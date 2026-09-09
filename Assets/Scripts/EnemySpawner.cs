using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private float spwan_timer;
    public List<GameObject> Enemys = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spwan_timer = GameManager.instance.SpawnTimeRandomiser();
    }

    float ElapsedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > spwan_timer && ElapsedTime != 0)
        {
            Instantiate(Enemys[0],transform.position,Quaternion.identity);
            spwan_timer = GameManager.instance.SpawnTimeRandomiser();
            ElapsedTime = 0f;
        } 
    }
}
