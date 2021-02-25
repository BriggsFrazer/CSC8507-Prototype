using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public float spawnRate;
    public float xRange;
    public float zRange;

    public GameObject box;
    float counter = 0;
    // Update is called once per frame

    private void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        Vector3 SpawnPoint = this.transform.position + new Vector3(Random.Range(-xRange, xRange), 0.8f, Random.Range(-zRange, zRange));
        Instantiate(box, SpawnPoint, new Quaternion(0, 0, 0, 0));
    }
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > spawnRate)
        {
            Random.InitState((int)System.DateTime.Now.Ticks);
            Vector3 SpawnPoint = this.transform.position + new Vector3(Random.Range(-xRange, xRange), 0.8f, Random.Range(-zRange, zRange));
            Instantiate(box, SpawnPoint, new Quaternion(0, 0, 0, 0));
            counter = 0;
        }
    }
}
