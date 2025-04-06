using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Compilation;
using UnityEngine;

public class CrosserPlayerHandler : MonoBehaviour
{
    public GameObject gameOverOverlay;
    public GameObject pauseOverlay;
    public SpriteRenderer cursorSprite;
    public Rigidbody2D rb;
    private bool canMove;
    public int score;
    public bool onPlatform;
    public TMP_Text scoreText;
    public TMP_Text crosserHighScoreText;
    public TMP_Text crosserHighScoreText2;
    static int crosserHighScore;

    // Start is called before the first frame update
    void Awake()
    {
        onPlatform = false;
        canMove = true;
        score = 0;
        scoreText.SetText(score.ToString("000000"));
        crosserHighScoreText.SetText(crosserHighScore.ToString("000000"));
        crosserHighScoreText2.SetText(crosserHighScore.ToString("000000"));
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(score.ToString("000000"));
        if (score >= crosserHighScore)
        {
            crosserHighScore = score;
            crosserHighScoreText.SetText(crosserHighScore.ToString("000000"));
            crosserHighScoreText2.SetText(crosserHighScore.ToString("000000"));
        }
        if (Input.GetKeyDown(KeyCode.P) && gameOverOverlay.activeSelf == false)
        {
            pauseOverlay.SetActive(!pauseOverlay.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.W) && canMove)
        {
            transform.position += Vector3.up * 2;
            score += 50;
        }
        if (Input.GetKeyDown(KeyCode.A) && canMove && transform.position.x > -8)
        {
            transform.position += Vector3.left * 2;
        }
        if (Input.GetKeyDown(KeyCode.S) && canMove)
        {
            transform.position += Vector3.down * 2;
        }
        if (Input.GetKeyDown(KeyCode.D) && canMove && transform.position.x < 8)
        {
            transform.position += Vector3.right * 2;
        }
        if (transform.position.x > 8.385)
        {
            transform.position = new Vector3(8.385f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -8.385)
        {
            transform.position = new Vector3(-8.385f, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "River" || other.tag == "Obstacle")
        {
            if (onPlatform == false)
            {
                Debug.Log("Bad collider hit!");
                Destroy(cursorSprite);
                canMove = false;
                gameOverOverlay.SetActive(true);
                pauseOverlay.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            Debug.Log("Good collider hit!");
            rb.velocity = other.GetComponent<Rigidbody2D>().velocity;
            onPlatform = true;
        }
        else
        {
            rb.velocity = Vector3.zero;
            onPlatform = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            onPlatform = false;
        }
    }
}
