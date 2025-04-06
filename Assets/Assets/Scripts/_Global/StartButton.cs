using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject buttonHitbox;
    public GameObject buttonIdle;
    public GameObject buttonHighlight;
    public GameObject buttonPressed;
    public string minigameScene;

    private void OnMouseEnter()
    {
        buttonIdle.SetActive(false);
        if (buttonPressed != null)
        {
            buttonPressed.SetActive(false);
        }
        buttonHighlight.SetActive(true);

    }
    private void OnMouseExit()
    {
        buttonIdle.SetActive(true);
        if (buttonPressed != null)
        {
            buttonPressed.SetActive(false);
        }
        buttonHighlight.SetActive(false);
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(minigameScene);
        if (buttonPressed != null)
        {
            buttonPressed.SetActive(true);
            buttonIdle.SetActive(false);
            buttonHighlight.SetActive(false);
        }
    }
}
