using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private float movementX;
    private SpriteRenderer flipPlayer;
    private Rigidbody2D playerRb;
    private float jumpForce = 8f;
    private bool isGround = true;
    private AudioSource audioSourcePlayer;
    public AudioClip diamondCollectSound, jumpSound, axeSound;
    public GameObject cameraPlayer;
    public GameObject explosionPrefab;
    private Animator animatorPlayer;
    public GameObject panelGameOver;

    // Start is called before the first frame update
    void Start()
    {
        flipPlayer=GetComponent<SpriteRenderer>();
        playerRb=GetComponent<Rigidbody2D>();
        audioSourcePlayer = GetComponent<AudioSource>();
        animatorPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movementX=Input.GetAxis("Horizontal");
        if(movementX>0)
        {
            flipPlayer.flipX=false;
        }
        if(movementX<0)
        {
            flipPlayer.flipX = true;
        }
        transform.position += new Vector3(movementX,0,0) * speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            audioSourcePlayer.PlayOneShot(jumpSound);
            playerRb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            animatorPlayer.SetTrigger("attack");
            audioSourcePlayer.PlayOneShot(axeSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Muerte del player. Fin del juego");
            cameraPlayer.transform.parent = null;
            Instantiate(explosionPrefab,transform.position + new Vector3(0,0.4f,0),Quaternion.identity);
            panelGameOver.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }

    public void DiamondSound()
    {
        audioSourcePlayer.PlayOneShot(diamondCollectSound);
    }
}
