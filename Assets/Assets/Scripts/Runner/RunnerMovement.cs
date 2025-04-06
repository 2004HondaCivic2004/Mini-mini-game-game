using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RunnerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] GameObject cameraManager;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject restartMenu;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float runSpeed = 2f;
    [SerializeField] private float speedMult = 1f;
    [SerializeField] private float rayDist = 1f;
    [SerializeField] private float stunTime = 0.1f;
    [SerializeField] private bool stunned = false;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip dieSFX;
    [SerializeField] private AudioClip flapSFX;
    [SerializeField] private GameObject tmpParent;
    
    private TextMeshProUGUI textMeshPro;
    private bool isDead;

    public float horizontalDist = 0f;
    private Vector3 rayDisplace = new Vector3 (0.51f, 0f, 0f);
    public RunnerGameManager gameManager;
    private IEnumerator stunTimer()
    {
        stunned = true;
        yield return new WaitForSeconds(stunTime);
        stunned = false;
    }

    private IEnumerator waitOnDie()
    {
        isDead = true;
        audioSource.clip = dieSFX;
        audioSource.Play();
        print("jumper die");
        yield return new WaitForSeconds(1);
        restartMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    private void Jump()
    {
        rb2d.AddForce(new Vector2(0, jumpForce));
        print("jumping");
        audioSource.clip = flapSFX;
        audioSource.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard" && isDead == false)
        {
            StartCoroutine(waitOnDie());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<RunnerGameManager>();
        textMeshPro = tmpParent.GetComponent<TextMeshProUGUI>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        //check if the runner is blocked by an obstacle in front
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position + rayDisplace, Vector3.right, rayDist);
        if (raycastHit2D && raycastHit2D.collider.gameObject.tag == "Platform")
        {
            print(raycastHit2D.collider.name);
            StartCoroutine(stunTimer());
        }
        else if (isDead == false)
        {
            transform.position += new Vector3(1 * runSpeed, 0) * Time.deltaTime;
            runSpeed += Time.deltaTime * (speedMult * 0.01f);
        }

        Debug.DrawRay(transform.position + rayDisplace, Vector3.right*rayDist, Color.red);

        if (Input.GetKeyDown(KeyCode.Space) && stunned == false && isDead == false)
        {
            Jump();
        }

        if (horizontalDist < transform.position.x)
        {
            horizontalDist = transform.position.x;
            textMeshPro.text = ((int)horizontalDist/3).ToString();
        }
        cameraManager.transform.position = new Vector3(horizontalDist, 0, 0);

        if (Input.GetKeyDown(KeyCode.P) && restartMenu.activeSelf == false)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }

}
