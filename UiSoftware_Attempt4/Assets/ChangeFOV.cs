using UnityEngine;
using System.Collections;

public class ChangeFOV : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.camera.fieldOfView = 90;
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.camera.fieldOfView = 90;
	}
}
