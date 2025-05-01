using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class CrosserLevelGenerator : MonoBehaviour
{
    private Vector2 platform1PosY = new Vector2(0f, 4f);
    private Vector2 platform2PosY = new Vector2(0f, 2f);
    private Vector2 platform3PosY = new Vector2(0f, 0f);
    private Vector2 platform4PosY = new Vector2(0f, -2f);
    private Vector2 platform5PosY = new Vector2(0f, -4f);
    public GameObject floorBlank;
    public GameObject floorGoal;
    public GameObject floorRoad;
    public GameObject floorRiver;
    public GameObject spawner;
    public Transform player;
    public CrosserPlayerHandler playerScript;
    private int randomValue;
    private int randomValue2;
    private GameObject floorGoalCurrent;
    private GameObject floorStartCurrent;
    private GameObject floorMiddleCurrentA;
    private GameObject floorMiddleCurrentB;
    private GameObject floorMiddleCurrentC;
    private GameObject spawnerCurrentA;
    private GameObject spawnerCurrentB;
    private GameObject spawnerCurrentC;

    void Awake()
    {
        GenerateNewLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y == 4 && player.position.x >= -1f && player.position.x <= 1f)
        {
            playerScript.crosserScore += 50;
            GenerateNewLevel();
            player.position = new Vector3(0, -4, player.position.z);
        }
    }

    void GenerateNewLevel()
    {
        BroadcastMessage("DestroyObjects");
        Debug.Log("Level generated!");
        if (floorGoalCurrent != null)
        {
            Destroy(floorGoalCurrent);
        }
        if (floorStartCurrent != null)
        {
            Destroy(floorStartCurrent);
        }
        if (floorMiddleCurrentA != null)
        {
            Destroy(floorMiddleCurrentA);
        }
        if (floorMiddleCurrentB != null)
        {
            Destroy(floorMiddleCurrentB);
        }
        if (floorMiddleCurrentB != null)
        {
            Destroy(floorMiddleCurrentC);
        }
        floorGoalCurrent = Instantiate(floorGoal, platform1PosY, Quaternion.identity);
        floorStartCurrent = Instantiate(floorBlank, platform5PosY, Quaternion.identity);
        randomValue = Random.Range(1, 3);
        switch (randomValue)
        {
            case 1:
                floorMiddleCurrentA = Instantiate(floorRiver, platform2PosY, Quaternion.identity);
                break;
            case 2:
                floorMiddleCurrentA = Instantiate(floorRoad, platform2PosY, Quaternion.identity);
                break;
        }
        randomValue2 = Random.Range(1, 3);
        switch (randomValue2)
        {
            case 1:
                spawnerCurrentA = Instantiate(spawner, new Vector3(-11, platform2PosY.y, -0.5f), Quaternion.identity, transform);
                break;
            case 2:
                spawnerCurrentA = Instantiate(spawner, new Vector3(11, platform2PosY.y, -0.5f), Quaternion.identity, transform);
                break;
        }
        randomValue = Random.Range(1, 5);
        switch (randomValue)
        {
            case 1:
                floorMiddleCurrentB = Instantiate(floorRiver, platform3PosY, Quaternion.identity);
                randomValue2 = Random.Range(1, 3);
                switch (randomValue2)
                {
                    case 1:
                        spawnerCurrentB = Instantiate(spawner, new Vector3(-11, platform3PosY.y, -0.5f), Quaternion.identity, transform);
                        break;
                    case 2:
                        spawnerCurrentB = Instantiate(spawner, new Vector3(11, platform3PosY.y, -0.5f), Quaternion.identity, transform);
                        break;
                }
                break;
            case 2:
                floorMiddleCurrentB = Instantiate(floorRoad, platform3PosY, Quaternion.identity);
                randomValue2 = Random.Range(1, 3);
                switch (randomValue2)
                {
                    case 1:
                        spawnerCurrentB = Instantiate(spawner, new Vector3(-11, platform3PosY.y, -0.5f), Quaternion.identity, transform);
                        break;
                    case 2:
                        spawnerCurrentB = Instantiate(spawner, new Vector3(11, platform3PosY.y, -0.5f), Quaternion.identity, transform);
                        break;
                }
                break;
            default:
                floorMiddleCurrentB = Instantiate(floorBlank, platform3PosY, Quaternion.identity);
                break;
        }
        randomValue = Random.Range(1, 3);
        switch (randomValue)
        {
            case 1:
                floorMiddleCurrentC = Instantiate(floorRiver, platform4PosY, Quaternion.identity);
                break;
            case 2:
                floorMiddleCurrentC = Instantiate(floorRoad, platform4PosY, Quaternion.identity);
                break;
        }
        randomValue2 = Random.Range(1, 3);
        switch (randomValue2)
        {
            case 1:
                spawnerCurrentC = Instantiate(spawner, new Vector3(-11, platform4PosY.y, -0.5f), Quaternion.identity, transform);
                break;
            case 2:
                spawnerCurrentC = Instantiate(spawner, new Vector3(11, platform4PosY.y, -0.5f), Quaternion.identity, transform);
                break;
        }
    }
}
