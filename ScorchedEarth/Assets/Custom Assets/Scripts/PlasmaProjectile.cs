using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaProjectile : Projectile {

    private Transform tObject;
    private Rigidbody rbObject;
    private System.Random rng;

    public override void Detonate()
    {
    }

    public override void OnCollisionEnter(Collision c)
    {
        if (ExplosionObject != null)
        {
            //do damage here

            //then spawn explosion
            Instantiate(ExplosionObject, tObject.position, Quaternion.Euler((float)rng.NextDouble() * 360f, (float)rng.NextDouble() * 360f, (float)rng.NextDouble() * 360f));
            Destroy(this);
        }
    }

    // Use this for initialization
    void Start () {
        tObject = GetComponent<Transform>();
        rng = new System.Random();
   
	}
	
	// Update is called once per frame
	void Update () {
        tObject.Rotate(new Vector3(2, 6, 0));
	}
}
