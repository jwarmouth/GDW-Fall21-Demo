using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public variables
    public float speed;
    public float jumpForce;
    public bool isGrounded;

    public Vector3 gravityNormal;
    public Vector3 gravityFast;
    public float gravityMod = 2;

    public float health = 10.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gravityNormal = Physics.gravity;
        gravityFast = gravityNormal * gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.AddForce(Vector3.right * h * speed);
        rb.AddForce(Vector3.forward * v * speed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3 (rb.velocity.x, 0.0f, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (rb.velocity.y < 0 && !isGrounded)
        {
            Physics.gravity = gravityFast;
        }













        //float forwardInput = Input.GetAxis("Vertical");
        //float sideInput = Input.GetAxis("Horizontal");

        //rb.AddForce(Vector3.right * sideInput * moveSpeed);
        //rb.AddForce(Vector3.forward * forwardInput * moveSpeed);

        ////transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * forwardInput);

        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        //{
        //    isGrounded = false;
        //    rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);
        //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //}
        ////transform.Translate(new Vector3(0f, 0f, 1f));

    }

    public void Damage (float howMuch)
    {
        Debug.Log("Player Damaged by " + howMuch + " points.");
        health -= howMuch;
        if (health <= 0)
        {
            Debug.Log("You Died");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Physics.gravity = gravityNormal;
        }
    }
}
