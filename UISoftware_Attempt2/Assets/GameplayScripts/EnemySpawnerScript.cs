using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {

	public GameObject monster;
	public GameObject resourceMine;
	public float spawnRate;
	public float minSpawnRadius;
	public float maxSpawnRadius;

	private float spawnAngle;
	private float lastTime;

	// Use this for initialization
	void Start () {
		spawnAngle = Random.Range (-45, 45);
		lastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<DefaultTrackableEventHandler> ().Tracked) {
						if (Time.time - lastTime > spawnRate) {
								Vector3 spawnDirection = new Vector3 (1, 0, 0);
								Quaternion randomRotation=Quaternion.AngleAxis(spawnAngle, new Vector3(0,1,0));
								spawnDirection=randomRotation*spawnDirection;
								Vector3 spawnPosition = resourceMine.transform.position + (spawnDirection * Random.Range(minSpawnRadius,maxSpawnRadius));	
								GameObject instantiatedMonster = Instantiate (monster, spawnPosition, Quaternion.identity) as GameObject;
								instantiatedMonster.transform.parent = resourceMine.transform;
								lastTime = Time.time;
								spawnAngle = Random.Range (-45, 45);
						}
				}
	
	}
}
