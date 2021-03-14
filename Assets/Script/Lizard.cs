using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(collider);
        }
    }
}
