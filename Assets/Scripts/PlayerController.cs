using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private Rigidbody playerRb;
    public float movementSpeed = 5.0f;
    public float turnSpeed = 5.0f;
    public float horizontalTurn;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    public bool isOnGround = true;
    public bool midAir = false;

    void Update()
    {
        horizontalTurn = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
           playerRb.AddForce(Vector3.up * 7, ForceMode.Impulse);
           isOnGround = false;
           midAir = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && midAir)
        {
            playerRb.AddForce(Vector3.up * 7, ForceMode.Impulse);
            midAir = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * movementSpeed);
        }
        
        transform.Rotate(Vector3.up * horizontalTurn  * turnSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
        isOnGround = true;
        }
    }
}
