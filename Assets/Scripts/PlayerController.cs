using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnimation;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private bool isOnGround = true;
    public float jumpForce = 10;
    public float gravityScaler;
    public bool gameOver = false;
    public int jumpTimes = 2;
   
    // Start is called before the first frame update
    void Start()
    {
       
        playerRb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
        Physics.gravity *= gravityScaler;
        playerAudio = GetComponent<AudioSource>();
        playerRb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !gameOver || Input.GetKeyDown(KeyCode.Space) && !gameOver && jumpTimes >0)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimation.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            jumpTimes -= 1;
        }

        
    }
 

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            if (!gameOver)
            {
                dirtParticle.Play();
                jumpTimes = 2;
            }
            else
            {
                dirtParticle.Stop();
            }
        }
        if (collision.gameObject.CompareTag("Obstacle") && !gameOver || collision.gameObject.CompareTag("ObstacleDestroy") && !gameOver)
        {
            playerAudio.PlayOneShot(crashSound);
            explosionParticle.Play();
            dirtParticle.Stop();
            gameOver = true;
            playerAnimation.SetBool("Death_b", true);
            playerAnimation.SetInteger("DeathType_int", 1);
            Debug.Log("Game over");
        }
    }
}
