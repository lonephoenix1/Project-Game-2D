using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float MaxSpeed = 10f;
    [SerializeField] private float stopForce = 10f;
    [SerializeField] GameObject prefab;

    private Rigidbody rb;
    private Vector3 movementDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        movementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            rb.velocity = Vector3.zero; 
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

    }
    void Shoot() 
    {
        GameObject pocisk = Instantiate(prefab, transform.position, Quaternion.identity);
    }
    private void FixedUpdate()
    {

        if (rb.velocity.magnitude < MaxSpeed)
        {
            rb.AddForce(movementDirection * movementSpeed);
        }
    }
}
