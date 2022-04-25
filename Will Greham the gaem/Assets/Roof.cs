using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof : MonoBehaviour
{
    [SerializeField]SpriteRenderer sprite;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            {
            sprite.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            {
            sprite.enabled = true;
        }
    }
}
