using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCrumbling : MonoBehaviour
{
    IEnumerator Crumble()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Crumble());
    }
}
