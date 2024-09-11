using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 0.035f;
    public float jump = 25f;
    bool grounded;
    bool topGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0, 0);
            Debug.Log("A key was pressed.");
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0);
            Debug.Log("D key was pressed.");
        }

        //Jump (Ground)
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
            Debug.Log("Space key was pressed.");
        }
        //Jump (Ceiling)
        if (Input.GetKeyDown(KeyCode.Space) && topGrounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, -jump * 10));
            Debug.Log("Space key was pressed.");
        }

        //Mechanic (Squishing the Slime)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.localScale = new Vector3(0.25f, 1f, 1f);
            Debug.Log("Q key was pressed.");
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Debug.Log("Q key was released.");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.localScale = new Vector3(1f, 0.25f, 1f);
            Debug.Log("E key was pressed.");
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Debug.Log("E key was released.");
        }



        //Gravity Shift
        if (Input.GetKeyDown(KeyCode.W)) //Up Grav
        {
            Physics2D.gravity = new Vector2(0f, 9.8f);
        }
        if (Input.GetKeyDown(KeyCode.S)) //Down Grav
        {
            Physics2D.gravity = new Vector2(0f, -9.8f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Jumping on the Ground
        if (other.gameObject.CompareTag("Ground"))
        {
            Vector3 normal = other.GetContact(0).normal;
            if (normal == Vector3.up)
            {
                grounded = true;
            }
        }

        //Jumping on the Ceiling
        if (other.gameObject.CompareTag("Ceiling"))
        {
            Vector3 normal = other.GetContact(0).normal;
            if (normal == Vector3.up)
            {
                topGrounded = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        //Ground
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
        //Ceiling
        if (other.gameObject.CompareTag("Ceiling"))
        {
            topGrounded = false;
        }
    }


}
