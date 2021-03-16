using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider collision)
    {
        FindObjectOfType<PlayerHealth>().TakeLives();
        Destroy(collision.gameObject);
    }
}
