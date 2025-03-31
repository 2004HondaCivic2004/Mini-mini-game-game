using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject runner;
    private Vector3 newLocation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newLocation = runner.transform.position;
        this.transform.position = new Vector3(newLocation.x, 0f, 0f);
    }
}
