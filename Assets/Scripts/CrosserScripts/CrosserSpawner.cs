using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosserSpawner : MonoBehaviour
{
    public GameObject platformShort;
    public GameObject platformLong;
    public GameObject obstacleShort;
    public GameObject obstacleLong;
    public int floorType;
    public bool hasSpawnerStarted;
    public GameObject currentObject;

    void Awake()
    {
        floorType = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (floorType != 0 && hasSpawnerStarted == false)
        {
            hasSpawnerStarted = true;
            StartCoroutine(Spawn());
        }
    }

    public IEnumerator Spawn()
    {
        while (hasSpawnerStarted == true)
        {
            // Debug.Log("Spawn coroutine running!");
            int platformType = Random.Range(1, 3);
            switch (floorType)
            {
                case 1:
                    switch (platformType)
                    {
                        case 1:
                            currentObject = Instantiate(platformShort, transform.localPosition, Quaternion.identity, transform);
                            // Debug.Log("platformShort has been spawned.");
                            break;
                        case 2:
                            currentObject = Instantiate(platformLong, transform.localPosition, Quaternion.identity, transform);
                            // Debug.Log("platformLong has been spawned.");
                            break;
                    }
                    break;
                case 2:
                    switch (platformType)
                    {
                        case 1:
                            currentObject = Instantiate(obstacleShort, transform.localPosition, Quaternion.identity, transform);
                            // Debug.Log("obstacleShort has been spawned.");
                            break;
                        case 2:
                            currentObject = Instantiate(obstacleLong, transform.localPosition, Quaternion.identity, transform);
                            // Debug.Log("obstacleLong has been spawned.");
                            break;
                    }
                    break;
            }
            
            yield return new WaitForSeconds(Random.Range(2f, 3.2f));
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "River")
        {
            floorType = 1;
        }
        if (collision.tag == "Road")
        {
            floorType = 2;
        }
    }

    public void DestroyObjects()
    {
        Destroy(gameObject);
    }
}
