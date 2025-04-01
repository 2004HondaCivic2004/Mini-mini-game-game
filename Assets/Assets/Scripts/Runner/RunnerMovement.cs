using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunnerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] GameObject cameraManager;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float runSpeed = 2f;
    [SerializeField] private float speedMult = 1f;
    [SerializeField] private float rayDist = 1f;
    public float horizontalDist = 0f;
    private Vector3 rayDisplace = new Vector3 (0.51f, 0f, 0f);
    public RunnerGameManager gameManager;
    private void Jump()
    {
        rb2d.AddForce(new Vector2(0, jumpForce));
        print("jumping");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            print("runner die");
            gameManager.restartScene();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<RunnerGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if the runner is blocked by an obstacle in front
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position + rayDisplace, Vector3.right, rayDist);
        if (raycastHit2D && raycastHit2D.collider.gameObject.tag == "Platform")
        {
            print(raycastHit2D.collider.name);
        }
        else
        {
            transform.position += new Vector3(1 * runSpeed, 0) * Time.deltaTime;
            runSpeed += Time.deltaTime * (speedMult * 0.01f);
        }

        Debug.DrawRay(transform.position + rayDisplace, Vector3.right*rayDist, Color.red);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (horizontalDist < transform.position.x)
        {
            horizontalDist = transform.position.x;
        }
        cameraManager.transform.position = new Vector3(horizontalDist, 0, 0);
    }
}
