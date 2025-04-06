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

    // Start is called before the first frame update
    void Start()
    {
        gameOverOverlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameOverOverlay.activeSelf == false)
        {
            pauseOverlay.SetActive(!pauseOverlay.activeSelf);
        }
        switch (playerPos.position.x)
        {
            case -4:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    playerPos.Translate(0f, 0f, 0f);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    playerPos.Translate(4f, 0f, 0f);
                }
                break;
            case 0:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    playerPos.Translate(-4f, 0f, 0f);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    playerPos.Translate(4f, 0f, 0f);
                }
                break;
            case 4:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    playerPos.Translate(-4f, 0f, 0f);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    playerPos.Translate(0f, 0f, 0f);
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(cursorSprite);
        spawnerScript.sliderOver = true;
        gameOverOverlay.SetActive(true);
        pauseOverlay.SetActive(false);
    }
}
