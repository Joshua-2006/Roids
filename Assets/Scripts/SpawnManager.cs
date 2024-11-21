using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;
    [SerializeField] private int asteroids;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        asteroids = FindObjectsOfType<Asteroid>().Length;
        if(asteroids <= 0)
        {
            asteroids = 4;
            Spawn(asteroids);
        }
    }
    Vector3 SpawnPos()
    {
        float xRange = Random.Range(-11, 11);
        float yRange = Random.Range(-2.5f, 4.5f);
        Vector3 randomPos = new Vector3(xRange, yRange, 0f);
        return randomPos;
    }
    void Spawn(int roids)
    {
        for (int i = 0; i < roids; i++)
        {
            Instantiate(asteroid, SpawnPos(), asteroid.transform.rotation);
        }
    }
}
