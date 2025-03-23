using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float strafeSpeed = 0.1f;
    public float verticalDist = 0f;

    private void Jump()
    {
        rb2d.AddForce(new Vector2(0, jumpForce));
        print("jumping");
    }

    private void StrafeLeft()
    {
        transform.position += new Vector3(-strafeSpeed, 0, 0 * Time.deltaTime);
    }
    private void StrafeRight()
    {
        transform.position += new Vector3(strafeSpeed, 0, 0 * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Jump();
        }
        if (collision.gameObject.tag == "Hazard")
        {
            print("jumper die");
            //tell the game manager to play the restart screen
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            StrafeRight();
        }
        if (Input.GetKey(KeyCode.A))
        {
            StrafeLeft();
        }
        if (verticalDist < transform.position.y)
        {
            verticalDist = transform.position.y;
        }
        
    }
}
