using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public double GoalSize;
    public double TimeToFullSize;
    private double timeElapsed;
    private Color fullColor;
    private Transform tObject;
    private Renderer rObject;

	// Use this for initialization
	void Start () {
        timeElapsed = 0;
        tObject = GetComponent<Transform>();
        rObject = GetComponent<Renderer>();
        fullColor = rObject.material.color;

    }
	
	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime;
        float currentScale = (float)(GoalSize * (timeElapsed / TimeToFullSize));
        tObject.localScale = new Vector3(currentScale, currentScale, currentScale);
        fullColor.a = 1 - (float)(timeElapsed / TimeToFullSize);
        if (timeElapsed > TimeToFullSize)
        {
            Destroy(this);
        }
	}
}
