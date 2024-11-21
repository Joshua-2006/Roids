using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroid : MonoBehaviour
{
    public SpawnManager sm;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(collision.gameObject);
            //SceneManager.LoadScene("Game Over");
        }
        if(collision.gameObject.CompareTag("Fire"))
        {
            Instantiate(sm.asteroid2, sm.asteroid.transform.position, sm.asteroid.transform.rotation);
            Instantiate(sm.asteroid2, sm.asteroid.transform.position, sm.asteroid.transform.rotation);
        }
    }
}
