using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCannonController : MonoBehaviour {

    public GameObject ProjectileObject;
    //relevant objects
    private GameObject menuCanvas;
    private Transform canvasTrans;
    private GameObject cameraObject;
    private Transform camTrans;
    private Transform cannonBarrelTrans;
    private Transform cannonAxisTrans;
    //track inputs for updating
    private InputField xInput;
    private InputField yInput;
    private InputField zInput;
    //bools
    private bool isPlaced = false;
    private bool increasingX = false;
    private bool decreasingX = false;
    private bool increasingY = false;
    private bool decreasingY = false;
    private bool increasingZ = false;
    private bool decreasingZ = false;

	// Use this for initialization
	void Start () {
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        menuCanvas = GameObject.FindGameObjectWithTag("MenuCanvas");
        canvasTrans = menuCanvas.GetComponent<Transform>();
        camTrans = cameraObject.GetComponent<Transform>();
        xInput = GameObject.FindGameObjectWithTag("X Field").GetComponent<InputField>();
        yInput = GameObject.FindGameObjectWithTag("Y Field").GetComponent<InputField>();
        zInput = GameObject.FindGameObjectWithTag("Z Field").GetComponent<InputField>();
        //find transform for cannon barrel, as this will determine shot direction
        Transform[] result = GetComponentsInChildren<Transform>();
        for (int i = 0; i < result.Length; i++)
        {
            if (result[i].tag.Equals("CannonBarrel"))
            {
                cannonBarrelTrans = result[i];
            }
            else if (result[i].tag.Equals("CannonAxis"))
            {
                cannonAxisTrans = result[i];
            }
        }
        
        menuCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) //mouse1
        {
            if (!isPlaced) //turret not yet placed
            {
                RaycastHit hit;
                if (Physics.Raycast(cameraObject.GetComponent<Transform>().position, cameraObject.GetComponent<Transform>().forward, out hit))
                {
                    //place turret (still need to set up the actual placement)
                    isPlaced = true;
                    menuCanvas.SetActive(true);
                }
            }
        }

        //adjust canvas to look in the correct direction (needs adjustment still)
        canvasTrans.rotation = Quaternion.LookRotation(canvasTrans.position - camTrans.position);
        //update rotation based on user input
        if (increasingX && (cannonAxisTrans.localRotation.eulerAngles.x < 90 || cannonAxisTrans.localRotation.eulerAngles.x >= 270))
            cannonAxisTrans.localRotation = cannonAxisTrans.localRotation * Quaternion.Euler(0.25f, 0, 0);
        if (decreasingX && (cannonAxisTrans.localRotation.eulerAngles.x > 270 || cannonAxisTrans.localRotation.eulerAngles.x <= 90))
            cannonAxisTrans.localRotation = cannonAxisTrans.localRotation * Quaternion.Euler(-0.25f, 0, 0);
        if (increasingY && (cannonAxisTrans.localRotation.eulerAngles.y < 90 || cannonAxisTrans.localRotation.eulerAngles.y >= 270))
            cannonAxisTrans.localRotation = cannonAxisTrans.localRotation * Quaternion.Euler(0, 0.25f, 0);
        if (decreasingY && (cannonAxisTrans.localRotation.eulerAngles.y > 270 || cannonAxisTrans.localRotation.eulerAngles.y <= 90))
            cannonAxisTrans.localRotation = cannonAxisTrans.localRotation * Quaternion.Euler(0, -0.25f, 0);
        if (increasingZ && (cannonAxisTrans.localRotation.eulerAngles.z < 90 || cannonAxisTrans.localRotation.eulerAngles.z >= 270))
            cannonAxisTrans.localRotation = cannonAxisTrans.localRotation * Quaternion.Euler(0, 0, 0.25f);
        if (decreasingZ && (cannonAxisTrans.localRotation.eulerAngles.z > 270 || cannonAxisTrans.localRotation.eulerAngles.z <= 90))
            cannonAxisTrans.localRotation = cannonAxisTrans.localRotation * Quaternion.Euler(0, 0, -0.25f);

        //update UI
        xInput.text = cannonBarrelTrans.localRotation.eulerAngles.x.ToString("0.00");
        yInput.text = cannonBarrelTrans.localRotation.eulerAngles.y.ToString("0.00");
        zInput.text = cannonBarrelTrans.localRotation.eulerAngles.z.ToString("0.00");
    }

    public void FireShot()
    {
        //fire projectile here
        if (ProjectileObject != null)
        {
            GameObject spawnedProjectile = Instantiate(ProjectileObject, GetComponent<Transform>().position + cannonBarrelTrans.up * 2f, Quaternion.identity);
            Rigidbody projBody = spawnedProjectile.GetComponent<Rigidbody>();
            projBody.AddForce(cannonBarrelTrans.up * ProjectileObject.GetComponent<Projectile>().Speed);
        }
    }

    public void StartIncreaseX() //comes from cannon UI
    {
        increasingX = true;
    }

    public void EndIncreaseX() //comes from cannon UI
    {
        increasingX = false;
    }

    public void StartDecreaseX() //comes from cannon UI
    {
        decreasingX = true;
    }

    public void EndDecreaseX() //comes from cannon UI
    {
        decreasingX = false;
    }

    public void StartIncreaseY() //comes from cannon UI
    {
        increasingY = true;
    }

    public void EndIncreaseY() //comes from cannon UI
    {
        increasingY = false;
    }

    public void StartDecreaseY() //comes from cannon UI
    {
        decreasingY = true;
    }

    public void EndDecreaseY() //comes from cannon UI
    {
        decreasingY = false;
    }

    public void StartIncreaseZ() //comes from cannon UI
    {
        increasingZ = true;
    }

    public void EndIncreaseZ() //comes from cannon UI
    {
        increasingZ = false;
    }

    public void StartDecreaseZ() //comes from cannon UI
    {
        decreasingZ = true;
    }

    public void EndDecreaseZ() //comes from cannon UI
    {
        decreasingZ = false;
    }
}
