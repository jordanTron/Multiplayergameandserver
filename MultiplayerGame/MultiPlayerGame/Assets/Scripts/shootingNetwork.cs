using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingNetwork : MonoBehaviour {
    public GameObject projectilePrefab;
    bool attacking;
    float attackTimer;
    float attackCD;

    // Use this for initialization
    void Start () {
        attacking = false;
        attackTimer = 0;
        attackCD = 2;

    }
	
	// Update is called once per frame
	public void Shoot () {
        if (attacking == false ) {
           

            var projectile = ObjectPool.Instance.GetFromPool();
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            attacking = true;
            attackTimer = attackCD;
        }

        //attacking
        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
            }
        }

    }
}
