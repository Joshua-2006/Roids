using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{ 
    [Header ("Movement")]
    [SerializeField] private float turnspeed = 200f;
    [SerializeField] private float thrust = 5f;
    [SerializeField] private float drag = 0.99f;
    private float horizontal;
    private Rigidbody rb;

    [Header ("Bullet")]
    [SerializeField] GameObject bullet;
    public float bulletSpeed = 10f;  
    public float fireRate = 0.3f;    
    private float nextFireTime = 0f;
    private Vector3 offset = new Vector3(0f, 0f, -1f);
    private Vector3 one;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        one = transform.position - offset;
        //Movement
        horizontal = Input.GetAxis("Horizontal");
        float rotationAmount = horizontal * turnspeed * Time.deltaTime;

        transform.Rotate(0f, 0f, -rotationAmount);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))  
        {
            rb.AddForce(transform.up * thrust);
        }
        rb.velocity *= drag;

        //Shooting
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }
    void Fire()
    {
        bullet = Instantiate(bullet, one, transform.rotation);

        Rigidbody rb2 = bullet.GetComponent<Rigidbody>();

        rb2.velocity = transform.up * bulletSpeed;

        Destroy(bullet, 3f);
    }
}
