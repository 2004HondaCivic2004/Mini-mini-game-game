using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScript : MonoBehaviour
{

    private IEnumerator killTimer()
    {
        yield return new WaitForSeconds(10);
        GameObject.Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(killTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
