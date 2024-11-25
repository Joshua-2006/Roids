using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField ] private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * Time.deltaTime * bulletSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.CompareTag("Enemy"))
        {
        Destroy(this.gameObject);
        Destroy(collision.gameObject);
        }
    }
}
