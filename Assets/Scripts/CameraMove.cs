using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject PLayer;

    private Vector3 Offest;



	// Use this for initialization
	void Start () {

        Offest = transform.position - PLayer.transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = PLayer.transform.position + Offest; 

	}
}
