using System;
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

    [SerializeField] GameObject handPos;
    [SerializeField] HoldItem handItem;

    [SerializeField] Inventory inventory;


    public Inventory GetInventory() { return inventory; }

    [Header("Camera")]
    public Transform camPos;


    [Header("Attack")]
    [SerializeField] DamageData damageData;

    [SerializeField] Transform hitPos;
    [SerializeField] LayerMask layer;

    [SerializeField] List<Item> startItems;

    //for audio(/animations)
    bool moving = false;
    string name = "Player_Run1";

    public bool HasBody { get; private set; }
    Body body;

    private void Start()
    {
        inventory.Init(this, handItem);
        inventory.gameObject.SetActive(false);

        foreach (Item item in startItems)
        {
            GetInventory().ItemAdded(item);
        }
    }

    private void Update()
    {
        //ker�� liikeinputin
        dir = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");

        DirManager();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventory.gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            inventory.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (HasBody) DropBody();
            Hit();
        }
        if(moving == false && (dir != 0 || dirY != 0))
        {
            moving = true;
            name = AudioManager.Instance.Randomize(new string[] { "Player_Run1", "Player_Run2" });
        }
        else if(moving == true && (dir == 0 && dirY == 0))
        {
            //Debug.Log(name);
            AudioManager.Instance.Stop(name);
            moving = false;
        }
        
    }

    private void DropBody()
    {

        HasBody = false;

        body.Leave();
        body = null;
    }

    public void SetBody(Body body)
    {
        if(handItem.itemData != null)
        {
            Inventory.ChangeHoldItem(null);
        }
        HasBody = true;
        this.body = body;

    }

    void Hit()
    {
        DamageData _dData = damageData;
        if (handItem.itemData != null)
        {
            if (handItem.itemData.itemType == Item.ItemType.Weapon)
            {
                AudioManager.Instance.Play("Weapon");
                _dData = handItem.itemData.GetWeapon().damageData;
            }
            if (handItem.itemData.itemType == Item.ItemType.Gun)
            {
                Shoot(handItem.itemData.GetGun().damageData);
                return;
            }
        }
        else
        {
            AudioManager.Instance.Play("Hit");
        }
       

        Collider2D hit = Physics2D.OverlapCircle(hitPos.transform.position, damageData.radius, layer);
        Debug.Log(_dData);
        if (hit != null)
        {
            IHittable hittable;
            hit.transform.TryGetComponent<IHittable>(out hittable);
            hittable?.TakeDamage(_dData);
        }
    }

    void DirManager()
    {
        if (dir > 0 && dirY == 0) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 270 + 90), 1);
        if (dir < 0 && dirY == 0) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90 + 90),1);
        if (dir == 0 && dirY > 0) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0 + 90), 1);
        if (dir == 0 && dirY < 0) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 180 + 90), 1);
        if (dir > 0 && dirY > 0) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 315 + 90), 1);
        if (dir > 0 && dirY < 0) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 225 + 90), 1);
        if (dir < 0 && dirY > 0) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 45 + 90), 1);
        if (dir < 0 && dirY < 0) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 135 + 90), 1);
    }

    void Shoot(DamageData _dData)
    {
        AudioManager.Instance.Play("Gun");
        //k�yt�n hitposia, kannattaa vaihtaa varmaa
        RaycastHit2D hit = Physics2D.Raycast(hitPos.position, hitPos.right, _dData.radius, layer);
        Debug.Log(_dData);
        if (hit)
        {
            IHittable hittable;
            hit.transform.TryGetComponent<IHittable>(out hittable);
            hittable?.TakeDamage(_dData);
        }
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

