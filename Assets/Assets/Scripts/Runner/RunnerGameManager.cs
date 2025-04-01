using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerGameManager : MonoBehaviour
{
    public void restartScene()
    {
        //will later change this to display a ui menu with a restart button, but for now it just restarts on death
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
