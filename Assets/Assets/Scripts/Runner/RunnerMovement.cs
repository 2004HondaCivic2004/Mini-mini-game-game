using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float runSpeed = 2f;
    [SerializeField] private float speedMult = 1f;
    public float horizontalDist = 0f;

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
        transform.position += new Vector3(1*runSpeed, 0) * Time.deltaTime;
        runSpeed += Time.deltaTime * (speedMult * 0.01f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (horizontalDist < transform.position.x)
        {
            horizontalDist = transform.position.x;
        }

    }
}
