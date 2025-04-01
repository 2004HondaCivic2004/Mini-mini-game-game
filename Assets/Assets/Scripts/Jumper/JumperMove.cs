using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] GameObject cameraManager;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float strafeSpeed = 0.1f;
    public float verticalDist = 0f;
    public JumperGameManager gameManager;

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
            gameManager.restartScene();
            //tell the game manager to play the restart screen
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<JumperGameManager>();
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
        cameraManager.transform.position = new Vector3 (0f ,verticalDist, 0f);
    }
}
