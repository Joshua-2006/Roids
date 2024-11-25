using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroid : MonoBehaviour
{
    public SpawnManager sm;
    public float speed;
    private GameManager gm;
    private Audio child;
    // Start is called before the first frame update
    void Start()
    {
        
        float zRange = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(0f, 0f, zRange);
        gm = FindAnyObjectByType<GameManager>();
        child = FindAnyObjectByType<Audio>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.up * Time.deltaTime * speed);
    }
    private void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Fire"))
        {
            
            child.audio2 = true;
            gm.Score();
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(sm.asteroid2, sm.SpawnPos(), sm.asteroid.transform.rotation);
            Instantiate(sm.asteroid2, sm.SpawnPos(), sm.asteroid.transform.rotation);
        }
        
    }
    IEnumerator Wait()
    {
        gm.Score();
        yield return new WaitForSeconds(0.5f);
        gm.currentscore = gm.score;
    }
}
