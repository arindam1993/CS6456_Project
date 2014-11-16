using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	public float speed;
	public float tiltMoveRate;
	public bool beenHit;
	public Quaternion initARCamera;
	public float initTime;
	public int liveTime;
	public int warningTime;
	public int flashRate;
	public bool isVisible;
	public int flashCounter;

	void Start () {
		beenHit = false;
		initTime = Time.time;
		isVisible = true;
		flashCounter = 0;
		/*
		GameObject manager = GameObject.Find ("AppManager");
		BackgroundTextureAppManager temp = manager.GetComponent<BackgroundTextureAppManager> ();

		initARCamera = temp.getInitAngle();	*/
	}

	void Update() {
		Quaternion currentAngle = GameObject.Find("ARCamera").camera.transform.rotation;
		Vector3 currentPosition = transform.position;
		if (!beenHit) {
			transform.Rotate (0, 0, speed * Time.deltaTime);
		}

		if (currentPosition.y < -10 || (Time.time - initTime) > liveTime) {
			Destroy (gameObject, 0.2f);
		}
		else if((Time.time - initTime) < warningTime){
			if(flashCounter >= flashRate){
				isVisible = false;
			}
			
			flashCounter+=1;
		}
		
		gameObject.SetActive(isVisible);
		//Debug.Log ("Diff x: " + (initARCamera.x - currentAngle.x) + "   Diff y: " + (initARCamera.y - currentAngle.y));
	}

	void OnTriggerEnter(Collider hit){
		beenHit = true;
	}
}
