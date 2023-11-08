using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float MaxSpeed = 10f;
    [SerializeField] private float stopForce = 10f;
    private Rigidbody rb;
    private Vector3 movementDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            rb.velocity = Vector3.zero; 
        }
    }

    private void FixedUpdate()
    {

        if (rb.velocity.magnitude < MaxSpeed)
        {
            rb.AddForce(movementDirection * movementSpeed);
        }
    }
}
