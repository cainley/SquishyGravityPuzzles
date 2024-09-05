using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 0.025f;
    public float jump = 25f;
    bool grounded;

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

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
            Debug.Log("Space key was pressed.");
        }

        //Mechanic (Squishing the Slime)
        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.localScale = new Vector3(0.25f, 1f, 1f);
            Debug.Log("Z key was pressed.");
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Debug.Log("Z key was released.");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            transform.localScale = new Vector3(1f, 0.25f, 1f);
            Debug.Log("X key was pressed.");
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Debug.Log("X key was released.");
        }

        

        //Gravity Shift

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Vector3 normal = other.GetContact(0).normal;
            if (normal == Vector3.up)
            {
                grounded = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }


}
