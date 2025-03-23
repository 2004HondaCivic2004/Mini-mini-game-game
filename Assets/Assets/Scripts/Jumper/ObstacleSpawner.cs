using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] private List<GameObject> ObstacleSets = new List<GameObject>();

    private int previousSet;
    private Vector3 spawnPosition = new Vector3 (0, 0, 0);

    private void SpawnNewSet()
    {
        int i = 0;
        do
        {
            i = Random.Range(0, ObstacleSets.Count);
        }
        while (i == previousSet);
        
        Instantiate(ObstacleSets[i], spawnPosition, transform.rotation);
        previousSet = i;
        print($"set {i} spawned");
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewSet();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.position += new Vector3(0, 20, 0);
            spawnPosition += new Vector3(0, 20, 0);
            SpawnNewSet();
        }
    }
}
