using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaProjectile : Projectile {

    private Transform tObject;
    private Rigidbody rbObject;

    public override void Detonate()
    {
    }

    public void OnCollisionEnter(Collision c)
    {
    }

    // Use this for initialization
    void Start () {
        tObject = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        tObject.Rotate(new Vector3(2, 6, 0));
	}
}
