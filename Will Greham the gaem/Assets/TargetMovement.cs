using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
public class TargetMovement : MonoBehaviour, IHittable, SendData
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float moveSpeed = 2f;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //restart
            print("kuolit");
        }
    }


    int waypointIndex = 0;

    [SerializeField] MissionData _data;
    [SerializeField] MissionData _data2;

    public MissionData data { get { return _data; } private set { _data = value; } }
    public MissionData data2 { get { return _data2; } }

    void Start() { 
        transform.position = waypoints[waypointIndex].transform.position; } 
    void Update() { 
        Move(); 
    } 
    void Move() {
        Quaternion rotation;
        if(transform.position.x > waypoints[waypointIndex].transform.position.x)
        {
            rotation = Quaternion.LookRotation
           (waypoints[waypointIndex].transform.position - transform.position, transform.TransformDirection(Vector3.back));
        }
        else
        {
            rotation = Quaternion.LookRotation
            (waypoints[waypointIndex].transform.position - transform.position, transform.TransformDirection(Vector3.back));
        }
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        Vector2 movement = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        transform.position = movement;
        if (transform.position == waypoints[waypointIndex].transform.position) { 
            waypointIndex += 1; 
        } 
        if (waypointIndex == waypoints.Length) waypointIndex = 0;


    }

    public void TakeDamage(DamageData damage)
    {
        if(damage.type >= DamageData.WeaponType.Medium)
        {
            data.Name = (data.Name + damage.weaponName);
            Debug.Log(damage.weaponName);
            Die();
        }
    }

    void Die()
    {
        print("död");
        MissionDataManager.Instance.AddData(data);
        Destroy(gameObject);
    }
}
