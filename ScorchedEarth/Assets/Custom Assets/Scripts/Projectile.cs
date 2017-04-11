using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour {

    public float DamageMinimum;
    public float DamageMaximum;
    public float Speed;
    public float MaxDistance;
    public double MaxFlightTime;
    public float ExplosionRadius;
    public GameObject ExplosionObject;
    public ParticleSystem ExplosionParticles;
    public bool SplitsProjectileOnCollision;
    public GameObject SplitProjectile;
    public AudioClip FireSoundEffect;
    public AudioClip ExplosionSoundEffect;
    public AudioClip FlightSoundEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public abstract void Detonate(); //this may be replaced later with a virtual which just creates the explosion object and calls the sound effects, etc...
                                     //sincei t probably doesn't need to be different for most projectiles
    public abstract void OnCollisionEnter(Collider c);
}
