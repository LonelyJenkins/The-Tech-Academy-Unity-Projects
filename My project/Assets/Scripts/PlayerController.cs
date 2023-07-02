using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    public float gravityModifier = 1f;
    public GameManager gameManager;

    private Rigidbody rb;
    private bool hasJumped = false;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();
        Physics.gravity = Physics.gravity * gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (hasJumped == false)
            {
                rb.AddForce(Vector3.up * jumpForce);
                hasJumped = true;
            }
        }

    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            hasJumped = false;
        }

        if(collision.gameObject.CompareTag("FinishLine"))
        {
            gameManager.hasWon = true;
        }
    }


}
