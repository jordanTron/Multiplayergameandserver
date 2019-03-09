using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {
    Rigidbody2D rb2d;
    Vector2 parenTransRot;
    public Transform spawner;
    Vector2 startPOS;
    bool fired;

	// Use this for initialization
	void Start () {
        fired = false;
        //startPOS = transform.position;
        //rb2d = GetComponent<Rigidbody2D>();
        //parenTransRot = transform.rotation * Vector2.up;
        //rb2d.AddForce(parenTransRot * 10, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
        if (isActiveAndEnabled && !fired)
        {
            fired = true;
            startPOS = transform.position;
            rb2d = GetComponent<Rigidbody2D>();
            parenTransRot = transform.rotation * Vector2.up;
            rb2d.AddForce(parenTransRot * 10, ForceMode2D.Impulse);
        }
        float dist = Vector2.Distance(startPOS, transform.position);

        if (dist > 10)
        {
            //Destroy(gameObject);
            fired = false;
            ObjectPool.Instance.AddToPool(gameObject);
        }

		
	}
}
