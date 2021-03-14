using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    Spawner myLaneSpawner;

    private void Start()
    {
        setLaneSpawner();
    }
    public void Update()
    {
        if (isAttackerInLine())
        {
            Debug.Log("shoot");
        }
        else
        {
            Debug.Log("Sit and wait");
        }
    }

    private void setLaneSpawner()
    {
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool isAttackerInLine()
    {
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire(float damage)
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
