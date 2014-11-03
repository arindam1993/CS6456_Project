using UnityEngine;
using System.Collections;

public class MonsterMoverScript : MonoBehaviour {

	public Transform target;
	public string targetName;
	public float moveStep;


	// Use this for initialization
	void Start () {
		target = GameObject.Find (targetName).transform;
		transform.LookAt (target.position);
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + transform.forward * moveStep * Time.deltaTime;
	}

	void OnTriggerEnter(Collider hit){
		if (hit.gameObject.name == "teapot") {
			Debug.Log("HIT BASE");
			hit.GetComponent<HealthManagerScript>().damage(5);
			transform.FindChild("monsterModel").particleSystem.Play();
			Destroy(gameObject, 0.2f);
		}
	}

}
