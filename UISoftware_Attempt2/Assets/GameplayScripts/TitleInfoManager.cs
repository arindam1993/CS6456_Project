using UnityEngine;
using System.Collections;

public class TitleInfoManager : MonoBehaviour {
	
	public Quaternion initARCamera;
	
	// Use this for initialization
	void Start () {
		GameObject manager = GameObject.Find ("AppManager");
		BackgroundTextureAppManager temp = manager.GetComponent<BackgroundTextureAppManager> ();
		
		initARCamera = temp.getInitAngle();
	}
	
	// Update is called once per frame
	void Update () {
		float currentYAngle = GameObject.Find ("ARCamera").camera.transform.eulerAngles.y;
		
		transform.eulerAngles = new Vector3 (0, currentYAngle, 0);
		//Debug.Log ("Y rotation: " + currentYAngle);
	}
}
