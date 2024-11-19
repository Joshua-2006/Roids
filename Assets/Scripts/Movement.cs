using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{ 
    [Header ("Movement")]
    [SerializeField] private float turnspeed = 200f;
    public float thrust = 5f;
    [SerializeField] public float drag = 0.99f;
    private float horizontal;
    private float vertical;
    private Rigidbody rb;

    [Header ("Bullet")]
    [SerializeField] GameObject bullet;
    [SerializeField] private float fireRate = 0.3f;    
    [SerializeField ]private float nextFireTime = 0f;
    private Vector3 offset = new Vector3(0f, 0f, -1f);
    private Vector3 one;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        one = transform.position - offset;
        //Movement
        horizontal = Input.GetAxis("Horizontal");
        float rotationAmount = horizontal * turnspeed * Time.deltaTime;

        transform.Rotate(0f, 0f, -rotationAmount);

        
        vertical = Input.GetAxis("Vertical");

        
        if (vertical > 0) 
        {
            Vector2 thrustDirection = transform.up; 
            rb.AddForce(thrustDirection * vertical * thrust);
        }

        rb.velocity *= drag;

        //Shooting
        if (Input.GetButtonDown("Fire") && Time.time > nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
            
        }
    }
    void Fire()
    {
        Instantiate(bullet, one, transform.rotation);
        Destroy(bullet, 2f);
    }
}
