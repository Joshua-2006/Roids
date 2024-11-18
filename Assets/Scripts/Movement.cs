using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float vertical;
    private float horizontal;
    [SerializeField] private float turnspeed = 200f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float drag = 0.99f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        float rotationAmount = horizontal * turnspeed * Time.deltaTime;

        transform.Rotate(0f, 0f, -rotationAmount);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))  // Thrust when pressing "W" key
        {
            // Add force in the direction the ship is facing
            rb.AddForce(transform.up * speed);
        }
        rb.velocity *= drag;
    }
}
