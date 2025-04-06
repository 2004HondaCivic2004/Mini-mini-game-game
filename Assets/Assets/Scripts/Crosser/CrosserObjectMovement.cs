using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CrosserObjectMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Awake()
    {
        if (transform.position.x > 0)
        {
            rb.velocity = Vector2.left * speed;
        }
        else
        {
            rb.velocity = Vector2.right * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 11 || transform.position.x < -11)
        {
            Destroy(gameObject);
        }
    }

    public void DestroyObjects()
    {
        Destroy(gameObject);
    }
}
