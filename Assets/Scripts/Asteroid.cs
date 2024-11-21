using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroid : MonoBehaviour
{
    public SpawnManager sm;
    public float speed;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        float zRange = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(0f, 0f, zRange);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.up * Time.deltaTime * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm.lives1 -= 1;
            //SceneManager.LoadScene("Game Over");
        }
        if(collision.gameObject.CompareTag("Fire"))
        {
            Instantiate(sm.asteroid2, sm.SpawnPos(), sm.asteroid.transform.rotation);
            Instantiate(sm.asteroid2, sm.SpawnPos(), sm.asteroid.transform.rotation);
        }
    }
}
