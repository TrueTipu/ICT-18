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
    float dir;
    float dirY;
    //float health;
    //[SerializeField] float maxHealth;

    [SerializeField] Inventory inventory;
    public Inventory GetInventory() { return inventory; }

    [Header("Camera")]
    public Transform camPos;



    private void Update()
    {
        //ker‰‰ liikeinputin
        dir = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");


    }

    //liikuttaa pelaajaa inputin mukaan
    private void FixedUpdate()
    {
        float speedValue;
        if(dir != 0 && dirY != 0)
        {
            speedValue = speed / 1.4f;         
        }
        else
        {
            speedValue = speed;
        }
        rb2.velocity = new Vector2(speedValue * Time.fixedDeltaTime * dir, speedValue * Time.fixedDeltaTime * dirY);
    }
}

