using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {

	public GameObject monster;
	public GameObject monster2;
	public GameObject resourceMine;
	public float spawnRate;
	public float minSpawnRadius;
	public float maxSpawnRadius;
	public int probability;
	public Material red;
	public Material yellow;
	public Material green;
	public Material orange;
	public Material purple;

	private float spawnAngle;
	private float lastTime;

	// Use this for initialization
	void Start () {
		spawnAngle = Random.Range (-20, 70);
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<DefaultTrackableEventHandler> ().Tracked) {
						if (Time.time - lastTime > spawnRate) {
								GameObject spawnMonster;
								if(Random.Range(0, 100) < probability){
									spawnMonster = monster;
								}
								else{
									spawnMonster = monster2;
									
					Material currTexture = monster2.transform.FindChild("cherioMonster").renderer.material;


					int rand = Random.Range(1,5);
					switch(rand){
					case 1:
						monster2.transform.FindChild("cherioMonster").renderer.material = red;
						break;
					case 2:
						monster2.transform.FindChild("cherioMonster").renderer.material = yellow;
						break;
					case 3:
						monster2.transform.FindChild("cherioMonster").renderer.material = green;
						break;
					case 4:
						monster2.transform.FindChild("cherioMonster").renderer.material = orange;
						break;
					default:
						monster2.transform.FindChild("cherioMonster").renderer.material = purple;
						break;
					}

								}

								Vector3 spawnDirection = new Vector3 (1, 0, 0);
								Quaternion randomRotation=Quaternion.AngleAxis(spawnAngle, new Vector3(0,1,0));
								spawnDirection=randomRotation*spawnDirection;
								Vector3 spawnPosition = resourceMine.transform.position + (spawnDirection * Random.Range(minSpawnRadius,maxSpawnRadius));	
								GameObject instantiatedMonster = Instantiate (spawnMonster, spawnPosition, Quaternion.identity) as GameObject;
								instantiatedMonster.transform.parent = resourceMine.transform;
								lastTime = Time.time;
								spawnAngle = Random.Range (-20, 70);
						}
				}
	
	}
}
