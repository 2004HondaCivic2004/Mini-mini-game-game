using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SliderObstacleMovement : MonoBehaviour
{
    public SliderObstacleSpawner spawnerScript;
    public float obstacleLocationX;
    public float destroyTimer;
    public float destroyTimerMax;
    private float lastY;

    void Awake()
    {
        destroyTimer = 0;
        spawnerScript = FindObjectOfType<SliderObstacleSpawner>();
        obstacleLocationX = transform.position.x;
    }



    void Update()
    {
        destroyTimer += 0.01f;
        
        if (destroyTimer >= spawnerScript.destroyTimerMax)
        {
            destroyTimer = 0;
            Destroy(gameObject);
            Debug.Log("obstacle has been destroyed!");
        }
        if (gameObject != null)
        {
            float currentY = transform.localPosition.y;
            bool condition = lastY > -3.55f && currentY <= -3.55f;
            Debug.Log("Score condition: " + condition);
            if (lastY > -3.55f && currentY <= -3.55f)
            {
                Debug.Log("Score condition triggered!");
                spawnerScript.score += 50;
            }
            lastY = currentY;
            switch (obstacleLocationX)
            {
                case -0.5f:
                    transform.position = Vector2.MoveTowards(transform.position, spawnerScript.laneEndA.position, (spawnerScript.obstacleSpeed / Mathf.Abs(Mathf.Acos((spawnerScript.laneEndA.position - transform.position).normalized.y))) * Time.deltaTime);
                    break;
                case 0:
                    transform.position = Vector2.MoveTowards(transform.position, spawnerScript.laneEndB.position, (spawnerScript.obstacleSpeed / Mathf.Abs(Mathf.Acos((spawnerScript.laneEndB.position - transform.position).normalized.y))) * Time.deltaTime);
                    break;
                case 0.5f:
                    transform.position = Vector2.MoveTowards(transform.position, spawnerScript.laneEndC.position, (spawnerScript.obstacleSpeed / Mathf.Abs(Mathf.Acos((spawnerScript.laneEndC.position - transform.position).normalized.y))) * Time.deltaTime);
                    break;
            }
        }
    }
}
