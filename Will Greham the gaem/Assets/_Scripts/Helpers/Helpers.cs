using System.Collections;
using UnityEngine;
public class Helpers : MonoBehaviour
{
    public static Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    public static Vector3 ScreenToWorldPoint(Vector3 pos)
    {
        Vector3 worldPos = camera.ScreenToWorldPoint(pos);
        return new Vector3(worldPos.x, worldPos.y, pos.z);
    }

    public static Vector3 WorldToScreenpoint(Vector3 pos)
    {
        Vector3 worldPos = camera.WorldToScreenPoint(pos);
        return new Vector3(worldPos.x, worldPos.y, 0);
    }
}
