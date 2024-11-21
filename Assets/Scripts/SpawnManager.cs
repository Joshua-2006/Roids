using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject asteroid2;
    [SerializeField] private int asteroids;
    [SerializeField] private Asteroid asteroidss;
    [SerializeField] private Asteroid asteroidsss;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        asteroids = FindObjectsOfType<Asteroid>().Length;
        if(asteroid!.activeInHierarchy)
        {
            Instantiate(asteroid2, asteroid.transform.position, asteroid.transform.rotation);
            Instantiate(asteroid2, asteroid.transform.position, asteroid.transform.rotation);
        }
        if(asteroids <= 0)
        {
            asteroidss.speed += 1; 
            asteroids = 4;
            Spawn(asteroids);
        }
    }
    public Vector3 SpawnPos()
    {
        float xRange = Random.Range(-11, 11);
        float yRange = Random.Range(-2.5f, 4.5f);
        Vector3 randomPos = new Vector3(xRange, yRange, -1f);
        return randomPos;
    }
    public void Spawn(int roids)
    {
        for (int i = 0; i < roids; i++)
        {
            Instantiate(asteroid, SpawnPos(), asteroid.transform.rotation);
        }
    }
}
