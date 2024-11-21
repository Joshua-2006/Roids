using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        float zRange = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(0f, 0f, zRange);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.up * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        BoxCollider bc = GetComponent<BoxCollider>();
        bc.isTrigger = false;
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        BoxCollider bc = GetComponent<BoxCollider>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            bc.isTrigger = true;
        }
        else if(collision.gameObject.CompareTag("Fire"))
        {
            bc.isTrigger = false;
        }
    }
  
}
