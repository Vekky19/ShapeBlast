using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] ShapePrefabs;
    public float pos1, pos2;
    public float spawnTime = 50;
    public float timer;
    float spawnPos;

    Vector2 spawnVector;
    Quaternion randRot;

    void Start()
    {
        timer = 0;
    }

    void SpawnShape()
    {
        Instantiate(ShapePrefabs[Random.Range(0, ShapePrefabs.Length)], spawnVector, randRot);
    }

    
    void Update()
    {
        timer += 1;

        if (timer > spawnTime)
        {
            timer = 0;
            spawnPos = Random.Range(pos1,pos2);
            spawnVector = new Vector2(spawnPos, this.transform.position.y + Random.Range(0,10));
            randRot = new Quaternion(0,0, Random.Range(0,45),0);
            SpawnShape();
        }
    }
}
