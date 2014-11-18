using UnityEngine;
using System.Collections;

public class CherioMover : MonoBehaviour {

	public Transform target;
	public string targetName;
	public float moveStep;
	public GameObject coins;

	private float damage;

	// Use this for initialization
	void Start () {
		damage = 2.5f;
		target = GameObject.Find (targetName).transform;
		transform.LookAt (target.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("resourceMine").GetComponent<DefaultTrackableEventHandler> ().Tracked) {
			transform.position = transform.position + transform.forward * moveStep * Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider hit){
		
		if (hit.gameObject.name == targetName) {
			Debug.Log("HIT BASE");
			hit.GetComponent<HealthManagerScript>().damage(damage);
			transform.FindChild("cherioMonster").particleSystem.Play();
			Destroy(gameObject, 0.2f);
		}
		if (hit.gameObject.name == "wall") {
			Debug.Log("HIT WALL");
			hit.GetComponent<HealthManagerScript>().damage(damage);
			transform.FindChild("cherioMonster").particleSystem.Play();
			Destroy(gameObject, 0.2f);
			Vector3 coinPos = new Vector3(transform.position.x-1, transform.position.y, transform.position.z-1);
			Instantiate (coins, coinPos, Quaternion.AngleAxis(90, Vector3.left));
		}
		if (hit.gameObject.name == "slammerTrigger") {
			Debug.Log("HIT Slammer");
			hit.transform.parent.FindChild("slammerHammer").GetComponent<Animator>().SetBool("monsterEnter",true);
			transform.FindChild("cherioMonster").particleSystem.Play();
			Destroy(gameObject, 0.2f);
			Vector3 coinPos = new Vector3(transform.position.x-1, transform.position.y, transform.position.z-1);
			Instantiate (coins, coinPos, Quaternion.AngleAxis(90, Vector3.left));
		}
		if (hit.gameObject.name == "slammerWall") {
			Debug.Log("HIT Slammer Wall");
			hit.GetComponent<HealthManagerScript>().damage(damage);
			transform.FindChild("cherioMonster").particleSystem.Play();
			Destroy(gameObject, 0.2f);
			Vector3 coinPos = new Vector3(transform.position.x-1, transform.position.y, transform.position.z-1);
			Instantiate (coins, coinPos, Quaternion.AngleAxis(90, Vector3.left));
		}
		
		
	}
}
