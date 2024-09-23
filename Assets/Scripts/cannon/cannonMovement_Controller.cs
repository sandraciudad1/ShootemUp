using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonMovement_Controller : MonoBehaviour
{
    Vector3 movement;
    Rigidbody2D rb;
    float speed = 60f;

    [SerializeField] GameObject rightWheel;
    [SerializeField] GameObject leftWheel;
    float rotationSpeed = 360f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f) * speed * Time.deltaTime;
        rb.velocity = movement * speed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8f, 8.13f), transform.position.y, transform.position.z);

        if (movement.x > 0)
        {
            RotateWheels(-rotationSpeed);  
        }
        else if (movement.x < 0)
        {
            RotateWheels(rotationSpeed);  
        }
    }

    void RotateWheels(float rotationAmount)
    {
        rightWheel.transform.Rotate(0f, 0f, rotationAmount * Time.deltaTime);
        leftWheel.transform.Rotate(0f, 0f, rotationAmount * Time.deltaTime);
        rightWheel.transform.position = gameObject.transform.position + new Vector3(0.47f, -0.729f, 0f);
        leftWheel.transform.position = gameObject.transform.position + new Vector3(-0.58f, -0.729f, 0f); ;
    }
}
