using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumperMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] GameObject cameraManager;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float strafeSpeed = 0.1f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip dieSFX;
    [SerializeField] private GameObject tmpParent;
    private TextMeshProUGUI textMeshPro;

    public float verticalDist = 0f;
    public JumperGameManager gameManager;

    private IEnumerator waitOnDie()
    {
        audioSource.clip = dieSFX;
        audioSource.Play();
        print("jumper die");
        yield return new WaitForSeconds(3);
        gameManager.restartScene();
    }

    private void Jump()
    {
        rb2d.AddForce(new Vector2(0, jumpForce));
        print("jumping");
        audioSource.clip = jumpSFX;
        audioSource.Play();
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
            StartCoroutine(waitOnDie());
            //tell the game manager to play the restart screen
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<JumperGameManager>();
        textMeshPro = tmpParent.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
            textMeshPro.text = ((int)verticalDist / 3).ToString();
        }
        cameraManager.transform.position = new Vector3 (0f ,verticalDist, 0f);
    }
}
