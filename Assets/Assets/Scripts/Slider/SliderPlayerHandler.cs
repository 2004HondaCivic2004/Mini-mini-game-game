using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPlayerHandler : MonoBehaviour
{
    public Transform playerPos;
    public Vector2 lane1PlayerPos;
    public Vector2 lane2PlayerPos;
    public Vector2 lane3PlayerPos;
    public GameObject gameOverOverlay;
    public GameObject pauseOverlay;
    public GameObject cursorSprite;
    public SliderObstacleSpawner spawnerScript;
    public AudioSource sliderAudioSource;
    public AudioClip sliderMoveClip;
    public AudioClip sliderScoreClip;
    public AudioClip sliderHighScoreClip;
    public AudioClip sliderDieClip;
    public bool sliderBeatHighscore;
    public bool hasPlayedScoreClip;

    // Start is called before the first frame update
    void Start()
    {
        hasPlayedScoreClip = false;
        gameOverOverlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnerScript.score % 250 == 0 && spawnerScript.score != 0 && hasPlayedScoreClip == false)
        {
            sliderAudioSource.PlayOneShot(sliderScoreClip);
            Debug.Log("Score milestone hit!");
            hasPlayedScoreClip = true;
        }
        if (spawnerScript.score % 250 != 0)
        {
            hasPlayedScoreClip = false;
        }
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && gameOverOverlay.activeSelf == false)
        {
            pauseOverlay.SetActive(!pauseOverlay.activeSelf);
        }
        switch (playerPos.position.x)
        {
            case -4:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    sliderAudioSource.PlayOneShot(sliderMoveClip);
                    playerPos.Translate(0f, 0f, 0f);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    sliderAudioSource.PlayOneShot(sliderMoveClip);
                    playerPos.Translate(4f, 0f, 0f);
                }
                break;
            case 0:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    sliderAudioSource.PlayOneShot(sliderMoveClip);
                    playerPos.Translate(-4f, 0f, 0f);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    sliderAudioSource.PlayOneShot(sliderMoveClip);
                    playerPos.Translate(4f, 0f, 0f);
                }
                break;
            case 4:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    sliderAudioSource.PlayOneShot(sliderMoveClip);
                    playerPos.Translate(-4f, 0f, 0f);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    sliderAudioSource.PlayOneShot(sliderMoveClip);
                    playerPos.Translate(0f, 0f, 0f);
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sliderAudioSource.PlayOneShot(sliderDieClip);
        Destroy(cursorSprite);
        spawnerScript.sliderOver = true;
        gameOverOverlay.SetActive(true);
        pauseOverlay.SetActive(false);
    }
}
