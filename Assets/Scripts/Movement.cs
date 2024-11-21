using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float turnspeed = 200f;
    public float thrust = 5f;
    [SerializeField] public float drag = 0.99f;
    private float horizontal;
    private float vertical;
    private Rigidbody rb;

    [Header("Bullet")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
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

       
    }
    private void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        
    }
}
