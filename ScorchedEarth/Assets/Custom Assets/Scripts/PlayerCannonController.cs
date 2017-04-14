using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCannonController : MonoBehaviour {

    public GameObject ProjectileObject;
    public GameObject CannonBarrelObject;
    //relevant objects
    private GameObject menuCanvas;
    private Transform canvasTrans;
    private GameObject cameraObject;
    private Transform camTrans;
    private Transform cannonBarrelTrans;
    private Transform cannonAxisTrans;
    //track inputs for updating
    private InputField xInput;
    private InputField zInput;
    //bools
    private bool isPlaced = false;
    private bool increasingX = false;
    private bool decreasingX = false;
    private bool increasingZ = false;
    private bool decreasingZ = false;

	// Use this for initialization
	void Start () {
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        menuCanvas = GameObject.FindGameObjectWithTag("MenuCanvas");
        canvasTrans = menuCanvas.GetComponent<Transform>();
        camTrans = cameraObject.GetComponent<Transform>();
        xInput = GameObject.FindGameObjectWithTag("X Field").GetComponent<InputField>();
        zInput = GameObject.FindGameObjectWithTag("Z Field").GetComponent<InputField>();
        
        menuCanvas.SetActive(false);

        //spawn cannon barrel
        if (CannonBarrelObject != null)
        {
            Vector3 axisPosition = new Vector3();
            foreach (Transform t in GetComponentsInChildren<Transform>()) if (t.tag.Equals("CannonAxisPosition")) axisPosition = t.position; 
            GameObject barrel = Instantiate(CannonBarrelObject, axisPosition, Quaternion.identity);
            foreach (Transform t in barrel.GetComponentInChildren<Transform>())
            {
                //find transform for cannon barrel, as this will determine shot direction
                if (t.tag.Equals("CannonBarrel"))
                {
                    cannonBarrelTrans = t;
                    print("CannonBarrelTrans set");
                }
            }
            cannonAxisTrans = barrel.GetComponent<Transform>();
        }
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
        if (increasingX)
            cannonAxisTrans.rotation = cannonAxisTrans.rotation * Quaternion.AngleAxis(0.25f, Vector3.right);
        if (decreasingX)
            cannonAxisTrans.rotation = cannonAxisTrans.rotation * Quaternion.AngleAxis(-0.25f, Vector3.right);
        if (increasingZ)
            cannonAxisTrans.rotation = cannonAxisTrans.rotation * Quaternion.AngleAxis(0.25f,Vector3.forward);
        if (decreasingZ)
            cannonAxisTrans.rotation = cannonAxisTrans.rotation * Quaternion.AngleAxis(-0.25f, Vector3.forward);

        //update UI
        xInput.text = cannonBarrelTrans.rotation.eulerAngles.x.ToString("0.00");
        zInput.text = cannonBarrelTrans.rotation.eulerAngles.z.ToString("0.00");
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
