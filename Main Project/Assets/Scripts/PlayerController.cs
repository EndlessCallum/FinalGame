using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private float horizontalInpit;
    private float verticalInput;
    private float speed = 10.0f;

    private GameManager gameManager;

    private Vector3 startPos;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isOnGround = true;

    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip gameOverSound;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        startPos = transform.position;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive == true) { 

            horizontalInpit = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameManager.isGameActive == true)
        {
            isOnGround = false;
            playerRB.AddForce(jump * jumpForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
}

    private void FixedUpdate()
    {
        if (gameManager.isGameActive == true)
        {
            playerRB.AddForce(new Vector3(horizontalInpit, 0.0f, verticalInput) * speed);
        }
        else
        {
            playerRB.velocity = Vector3.zero;
            transform.position = startPos;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Game Over Plane"))
        {
            gameManager.GameOver();
            playerAudio.PlayOneShot(gameOverSound, 1.0f);
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            gameManager.GameFinished();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            // rolling ball sound
        }
    }
}
