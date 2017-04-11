using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannonController : MonoBehaviour {

    public GameObject ProjectileObject;
    private GameObject cameraObject;
    private bool isPlaced = false;

	// Use this for initialization
	void Start () {
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            if (!isPlaced)
            {
                RaycastHit hit;
                if (Physics.Raycast(cameraObject.GetComponent<Transform>().position, cameraObject.GetComponent<Transform>().forward, out hit))
                {
                    //place turret
                    isPlaced = true;
                }
            }
            else
            {
                //controls for using turret
            }
        }
	}
}
