using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class SliderObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacle;
    [SerializeField]
    private Animator obstacleAnimator;
    private GameObject currentObstacleA;
    private GameObject currentObstacleB;
    private int obstacleAmount;
    private int obstacleLocationA;
    private int obstacleLocationB;
    public bool isObstacleAInEnd;
    public bool isObstacleBInEnd;
    public Transform laneStartA;
    public Transform laneStartB;
    public Transform laneStartC;
    public Transform laneEndA;
    public Transform laneEndB;
    public Transform laneEndC;
    public float playerPosY;
    public bool sliderRunning;
    public bool sliderOver;
    public float spawnTimer;
    public float obstacleSpeed;
    public float animationSpeed;
    public TMP_Text scoreText;
    public int score;
    public TMP_Text sliderHighScoreText;
    public TMP_Text sliderHighScoreText2;
    static int sliderHighScore;
    public float timerInterval;
    public float destroyTimerMax;

    // Start is called before the first frame update
    void Awake()
    {
        sliderRunning = false;
        sliderOver = false;
        score = 0;
        scoreText.SetText(score.ToString("000000"));
        sliderHighScoreText.SetText(sliderHighScore.ToString("000000"));
        sliderHighScoreText2.SetText(sliderHighScore.ToString("000000"));
        StartCoroutine(SpawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
        scoreText.SetText(score.ToString("000000"));
        if (score >= sliderHighScore)
        {
            sliderHighScore = score;
            sliderHighScoreText.SetText(sliderHighScore.ToString("000000"));
            sliderHighScoreText2.SetText(sliderHighScore.ToString("000000"));
        }
        if (sliderRunning == false && sliderOver == false)
        {
            sliderRunning = true;
            StartCoroutine(Spawner());
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sliderOver = false;
        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            sliderOver = true;
        }
        if (sliderOver == true)
        {
            StopCoroutine(Spawner());
        }

        
    }

    public IEnumerator Spawner()
    {
        while (sliderRunning)
        {
            if (sliderOver == true)
            {
                sliderRunning = false;
            }    
            Debug.Log("Spawner while loop is running!");
            yield return new WaitForSeconds(spawnTimer);
            obstacleAmount = Random.Range(1, 6);
            if (obstacleAmount == 1 || obstacleAmount == 2 || obstacleAmount == 3)
            {
                Debug.Log("obstacleAmount has been generated! It equals: " + obstacleAmount);
                obstacleLocationA = Random.Range(1, 4);
                Debug.Log("obstacleLocationA has been generated! It equals: " + obstacleLocationA);
                switch (obstacleLocationA)
                {
                    case 1:
                        currentObstacleA = Instantiate(obstacle, laneStartA);
                        Debug.Log("currentObstacleA has been instantiated!");
                        break;
                    case 2:
                        currentObstacleA = Instantiate(obstacle, laneStartB);
                        Debug.Log("currentObstacleA has been instantiated!");
                        break;
                    case 3:
                        currentObstacleA = Instantiate(obstacle, laneStartC);
                        Debug.Log("currentObstacleA has been instantiated!");
                        break;
                }
            }
            else
            {
                Debug.Log("obstacleAmount has been generated! It equals: " + obstacleAmount);
                obstacleLocationA = Random.Range(1, 4);
                Debug.Log("obstacleLocationA has been generated! It equals: " + obstacleLocationA);
                obstacleLocationB = Random.Range(1, 4);
                if (obstacleLocationB == obstacleLocationA && obstacleLocationB > 1)
                {
                    obstacleLocationB--;
                }
                else if (obstacleLocationB == obstacleLocationA && obstacleLocationB < 3)
                {
                    obstacleLocationB++;
                }
                Debug.Log("obstacleLocationB has been generated! It equals: " + obstacleLocationB);
                switch (obstacleLocationA)
                {
                    case 1:
                        currentObstacleA = Instantiate(obstacle, laneStartA);
                        Debug.Log("currentObstacleA has been instantiated!");
                        break;
                    case 2:
                        currentObstacleA = Instantiate(obstacle, laneStartB);
                        Debug.Log("currentObstacleA has been instantiated!");
                        break;
                    case 3:
                        currentObstacleA = Instantiate(obstacle, laneStartC);
                        Debug.Log("currentObstacleA has been instantiated!");
                        break;
                }
                switch (obstacleLocationB)
                {
                    case 1:
                        currentObstacleB = Instantiate(obstacle, laneStartA);
                        Debug.Log("currentObstacleB has been instantiated!");
                        break;
                    case 2:
                        currentObstacleB = Instantiate(obstacle, laneStartB);
                        Debug.Log("currentObstacleB has been instantiated!");
                        break;
                    case 3:
                        currentObstacleB = Instantiate(obstacle, laneStartC);
                        Debug.Log("currentObstacleB has been instantiated!");
                        break;
                }
            }
        }
        yield return null;
    }

    public IEnumerator SpawnTimer()
    {
        while (true)
        {
            spawnTimer -= 0.01f;
            destroyTimerMax += 0.01f;
            yield return new WaitForSeconds(timerInterval);
        }
    }
}
