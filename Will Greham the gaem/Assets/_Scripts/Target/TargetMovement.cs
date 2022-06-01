using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
public class TargetMovement : MonoBehaviour, IHittable, SendData
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float moveSpeed = 2f;

    [SerializeField] GameObject body;

    [SerializeField]bool level1;
    [SerializeField] bool tutorial;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //restart
            print("kuolit");
            Game_Manager.Instance.SetGameOver();
        }
    }


    int waypointIndex = 0;

    [SerializeField] MissionData _data;
    [SerializeField] MissionData _data2;

    public MissionData data { get { return _data; } private set { _data = value; } }
    public MissionData data2 { get { return _data2; } }

    void Start() { 
        if(waypoints.Length != 0)
        transform.position = waypoints[waypointIndex].transform.position; } 
    void Update() { 
        Move(); 
    } 
    void Move() {
        if (waypoints.Length == 0) return;
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

    public static Transform Distances(Transform[] _waypoints, Vector3 _position)
    {
        if (_waypoints.Length == 0) return null;
        Transform _closest = _waypoints[0];
        float _closeDis = 1000000000;
        foreach (Transform wayPoint in _waypoints)
        {
            float dis = Vector2.Distance(wayPoint.position, _position);
            if(dis < _closeDis)
            {
                _closeDis = dis;
                _closest = wayPoint;
            }
        }
        return _closest;
    }

    public void TakeDamage(DamageData damage)
    {
        if(damage.type >= DamageData.WeaponType.Medium)
        {
            if(!tutorial)
            data.Name = (data.Name + " " + damage.weaponName);
            else
            {
                data.Name = (data.Name);
            }
           // Debug.Log(damage.weaponName);
            if(Distances(waypoints, transform.position) != null)
            {
                data2.Name = (data2.Name+ " " + Distances(waypoints, transform.position).name);
            }
            Die();
        }
    }

    void Die()
    {
        //print("död");
        MissionDataManager.Instance.AddData(data);
        if(!tutorial)
        MissionDataManager.Instance.AddData(data2);
        if(level1)
        {
            Game_Manager.Instance.Win();
        }
        else
        {
            Game_Manager.Instance.AddDeath();
        }
        if (tutorial) return;
        Instantiate(body, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
