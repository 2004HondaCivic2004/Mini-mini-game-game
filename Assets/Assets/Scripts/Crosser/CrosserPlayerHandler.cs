using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.Compilation;
using UnityEngine;

public class CrosserPlayerHandler : MonoBehaviour
{
    public GameObject gameOverOverlay;
    public GameObject pauseOverlay;
    public SpriteRenderer cursorSprite;
    public Rigidbody2D rb;
    private bool canMove;
    public int crosserScore;
    public bool onPlatform;
    public TMP_Text scoreText;
    public TMP_Text crosserHighScoreText;
    public TMP_Text crosserHighScoreText2;
    static int crosserHighScore;
    public bool hasDied;
    public AudioSource crosserAudioSource;
    public AudioClip crosserMoveClip;
    public AudioClip crosserScoreClip;
    public AudioClip crosserHighScoreClip;
    public AudioClip crosserDieClip;
    public bool crosserBeatHighscore;
    public bool hasPlayedScoreClip;


    // Start is called before the first frame update
    void Awake()
    {
        crosserBeatHighscore = false;
        hasPlayedScoreClip = false;
        hasDied = false;
        onPlatform = false;
        canMove = true;
        crosserScore = 0;
        scoreText.SetText(crosserScore.ToString("000000"));
        crosserHighScoreText.SetText(crosserHighScore.ToString("000000"));
        crosserHighScoreText2.SetText(crosserHighScore.ToString("000000"));
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseOverlay.activeSelf == true || gameOverOverlay.activeSelf == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        if (crosserScore % 250 == 0 && crosserScore != 0 && hasPlayedScoreClip == false)
        {
            crosserAudioSource.PlayOneShot(crosserScoreClip);
            Debug.Log("Score milestone hit!");
            hasPlayedScoreClip = true;
            
        }
        if (crosserScore % 250 != 0)
        {
            hasPlayedScoreClip = false;
        }
        scoreText.SetText(crosserScore.ToString("000000"));
        if (crosserScore >= crosserHighScore && crosserScore != 0)
        {
            Debug.Log("Highscore beat!");
            if (crosserBeatHighscore == false)
            {
                crosserAudioSource.PlayOneShot(crosserHighScoreClip);
                crosserBeatHighscore = true;
            }
            crosserHighScore = crosserScore;
            crosserHighScoreText.SetText(crosserHighScore.ToString("000000"));
            crosserHighScoreText2.SetText(crosserHighScore.ToString("000000"));
        }
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && gameOverOverlay.activeSelf == false)
        {
            pauseOverlay.SetActive(!pauseOverlay.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.W) && canMove)
        {
            crosserAudioSource.PlayOneShot(crosserMoveClip);
            Debug.Log("Player moved up!");
            transform.position += Vector3.up * 2;
            crosserScore += 50;
        }
        if (Input.GetKeyDown(KeyCode.A) && canMove && transform.position.x > -8)
        {
            crosserAudioSource.PlayOneShot(crosserMoveClip);
            transform.position += Vector3.left * 2;
        }
        if (Input.GetKeyDown(KeyCode.S) && canMove)
        {
            crosserAudioSource.PlayOneShot(crosserMoveClip);
            transform.position += Vector3.down * 2;
        }
        if (Input.GetKeyDown(KeyCode.D) && canMove && transform.position.x < 8)
        {
            crosserAudioSource.PlayOneShot(crosserMoveClip);
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

        if (hasDied && onPlatform)
        {
            Debug.Log("Player is in river, but on a platform!");
            hasDied = false;
        }
        else if (hasDied)
        {
            
            GameOver();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.tag == "River" || other.tag == "Obstacle")
        {
            Debug.Log($"River/obstacle trigger staying! Collider of type: {other}");
            if (onPlatform == false)
            {
                hasDied = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"TriggerEnter occurring! Collider of type: {other}");
        if (other.tag == "Platform")
        {
            Debug.Log("Good collider hit!");
            rb.velocity = other.GetComponent<Rigidbody2D>().velocity;
            onPlatform = true;
            Debug.Log($"onPlatform = {onPlatform}");
        }
        else
        {
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"TriggerExit occurring! Collider of type: {other}");
        if (other.tag == "Platform")
        {
            rb.velocity = Vector3.zero;
            onPlatform = false;
            Debug.Log($"onPlatform = {onPlatform}");
        }
    }

    void GameOver()
    {
        crosserAudioSource.PlayOneShot(crosserDieClip);
        Debug.Log("Player died!");
        Destroy(cursorSprite);
        Destroy(GetComponent<BoxCollider2D>());
        canMove = false;
        hasDied = false;
        gameOverOverlay.SetActive(true);
        pauseOverlay.SetActive(false);
       
    }
}
