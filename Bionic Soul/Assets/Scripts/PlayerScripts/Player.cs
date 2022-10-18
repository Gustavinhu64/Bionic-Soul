using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Player : MonoBehaviour
{
    public SpriteRenderer spritex;
    public float speedX, jumpStrength;
    public float horizontal;
    private Rigidbody2D body;
    private GameController gc;
    private bool groundCheck;
    private Transform foot;
    public Transform swordSpawn;
    public GameObject bulletPrefab;
    Grounded grundchereca;
    Animator anim;
    PhotonView view;
    public bool paraDireita;
    public float firerate, bulletforce;
    float nextfire;
    Health healthSCP;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        grundchereca = GetComponent<Grounded>();
        spritex = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        gc = FindObjectOfType(typeof(GameController)) as GameController;
        foot = GameObject.FindGameObjectWithTag("groundCheck").transform;
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
            controls();

            if (Input.GetButtonDown("D"))
            {
                paraDireita = true;

                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                }

            }
            else if (Input.GetButtonDown("A"))
            {
                paraDireita = false;
                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                }
        }


    }
    void controls()
    {  // Left and Right UwU
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0 || horizontal < 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        body.velocity = new Vector2(horizontal * speedX, body.velocity.y);
        if (Input.GetButtonDown("W") && groundCheck)
        {
            body.velocity = new Vector2(body.velocity.x, jumpStrength);
        }
        //BOT�O DE GATINHO PRA ARMA
        if (Input.GetButtonDown("Jump"))
        {
            if(Time.time > nextfire)
            {
            nextfire = Time.time + firerate;
            //anim.SetTrigger("Shoot");            
            Instantiate(bulletPrefab, swordSpawn.position, swordSpawn.rotation);      
            }

        }
        else
        {
            //anim.SetBool("shoot", true);
        }
    }
    public void SetGroundCheck(bool grounded)
    {
        groundCheck = grounded;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("BalaInimigo"))
        {
            healthSCP.currentHealth -= 1;
        }
    }

}