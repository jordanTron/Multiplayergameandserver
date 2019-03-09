using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {
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
	void Update () {
        if (Input.GetAxisRaw("Fire2") == 1 && attacking == false ) {
           // Instantiate(projectilePrefab, transform.position, transform.rotation);

            var projectile = ObjectPool.Instance.GetFromPool();
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            attacking = true;
            attackTimer = attackCD;
            Network.Attack();
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
