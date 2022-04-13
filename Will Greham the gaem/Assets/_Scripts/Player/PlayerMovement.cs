using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//hallitsee 2d osuuksissa pelaajahahmon liikkeen
public class PlayerMovement : MonoBehaviour
{
    [Header("Basics")]
    [SerializeField] Rigidbody2D rb2;

    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    float dir;

    bool flipped;

    [Header("Jumping")]
    [SerializeField] Transform jumpPos;
    [SerializeField] Vector2 area;
    [SerializeField] LayerMask groundLayer;

    bool isGround;
    [SerializeField] float groundTime;
    float groundTimer;

    //float health;
    //[SerializeField] float maxHealth;

    [Header("Camera")]
    public Transform camPos;



    private void Update()
    { 
        //ker‰‰ liikeinputin
        dir = Input.GetAxisRaw("Horizontal");

        //k‰‰nt‰‰ pelaajan naaman
        if (dir > 0)
        {
            flipped = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (dir < 0)
        {
            flipped = false;
            transform.localScale = Vector3.one;
        }

        //tarkistaa koskettaako pelaaja maata
        isGround = GroundCheck();

        //tarkistaa hyppynapin
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }

    }

     //hallitsee hypp‰‰misen
    private void Jump()
    {
        isGround = false;
        rb2.velocity = new Vector2(rb2.velocity.x, Time.fixedDeltaTime * jumpHeight);
    }

    //tarkistaa koskettaako pelaaja maata ja palauttaa sen mukaan arvoja + kojootti aika
    bool GroundCheck()
    {

        if (Physics2D.OverlapBox(jumpPos.position, area, 6, groundLayer))
        {
            groundTimer = groundTime;
            return true;
        }
        else if (groundTimer > 0)
        {
            groundTimer -= Time.deltaTime;
            return true;
        }
        else
        {
            return false;
        }
    }

    //piirt‰‰ hyppyhitboxin
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(jumpPos.position, area);
    }

    //liikuttaa pelaajaa inputin mukaan
    private void FixedUpdate()
    {
        rb2.velocity = new Vector2(speed * Time.fixedDeltaTime * dir, rb2.velocity.y);
    }
}

