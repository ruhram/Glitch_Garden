using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    Spawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT = "Projectiles";

    private void Start()
    {
        setLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT);
        }
    }

    public void Update()
    {
        if (isAttackerInLine())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
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
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;

    }
}
