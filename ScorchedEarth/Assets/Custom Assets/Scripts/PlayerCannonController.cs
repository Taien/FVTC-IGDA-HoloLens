using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannonController : MonoBehaviour {

    public GameObject ProjectileObject;
    private GameObject menuCanvas;
    private Transform canvasTrans;
    private GameObject cameraObject;
    private Transform camTrans;
    private bool isPlaced = false;

	// Use this for initialization
	void Start () {
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        menuCanvas = GameObject.FindGameObjectWithTag("MenuCanvas");
        canvasTrans = menuCanvas.GetComponent<Transform>();
        camTrans = cameraObject.GetComponent<Transform>();
        menuCanvas.SetActive(false);
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
                    menuCanvas.SetActive(true);
                }
            }
            else
            {
                //controls for using turret
            }
        }
        canvasTrans.rotation = Quaternion.LookRotation(canvasTrans.position - camTrans.position);
	}

    public void FireShot()
    {
        //fire projectile here
        print("Shot fired");
    }
}
