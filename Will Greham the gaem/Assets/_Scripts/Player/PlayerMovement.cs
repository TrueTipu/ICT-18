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
        //ker‰‰ liikeinputin
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
            Hit();
        }
        
    }
    void Hit()
    {
        DamageData _dData = damageData;
        if (handItem.itemData != null)
        {
            if (handItem.itemData.itemType == Item.ItemType.Weapon)
            {
                _dData = handItem.itemData.GetWeapon().damageData;
            }
            if (handItem.itemData.itemType == Item.ItemType.Gun)
            {
                Shoot(handItem.itemData.GetGun().damageData);
                return;
            }
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
        if(dir > 0) {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (dir < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (dirY > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (dirY < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 270);
        }
    }

    void Shoot(DamageData _dData)
    {
        //k‰yt‰n hitposia, kannattaa vaihtaa varmaa
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

