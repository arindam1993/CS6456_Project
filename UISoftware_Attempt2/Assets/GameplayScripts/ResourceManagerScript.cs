using UnityEngine;
using System.Collections.Generic;

public class ResourceManagerScript : MonoBehaviour {

	public float initialResource;
	public float finalResource;
	public float resourceGainPerSecond;
	public float resourceDrainPerSecond;
	public float healRate;
	public Transform resourceLevel;
	public Transform baseMarker;
	public float angleThreshold;
	public float distanceThreshold;
	public List<GameObject> trackers;
	
	
	public float currentResource;
	private float lastTime;
	private bool isPouring=false;
	private Transform thisMarker;
	private ParticleSystem pourEffect;
	
	// Use this for initialization
	void Start () {
		currentResource=initialResource;
		resourceLevel.localScale=new Vector3(1, initialResource/finalResource, 1);
		lastTime=Time.time;
		thisMarker=transform.parent;
		pourEffect=transform.FindChild("pourEffect").particleSystem;
		pourEffect.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		float tiltAngle=Vector3.Angle(baseMarker.transform.up, thisMarker.transform.up);
		if(tiltAngle > angleThreshold && currentResource>0 && transform.parent.GetComponent<DefaultTrackableEventHandler>().Tracked){
			currentResource-=resourceDrainPerSecond;
			if(!pourEffect.isPlaying){
				pourEffect.Play();
			}
			foreach(GameObject tracker in trackers){
				float dist=Vector3.Distance(tracker.transform.position, thisMarker.transform.position);
				Debug.Log(dist);
				if(dist< distanceThreshold && tracker.GetComponent<DefaultTrackableEventHandler>().Tracked){
					Debug.Log("Pouring on "+tracker.name);
					//tracker.transform.FindChild("teapot").GetComponent<HealthManagerScript>().heal(healRate*Time.deltaTime);
					tracker.transform.FindChild("wall").GetComponent<HealthManagerScript>().heal(healRate*Time.deltaTime);
				}
			}
		}else{
			if(pourEffect.isPlaying){
				pourEffect.Stop();
			}
		}
		if(Time.time-lastTime > 1.0){
			currentResource+=resourceGainPerSecond;
			currentResource=Mathf.Clamp(currentResource,0,finalResource);
			resourceLevel.localScale=new Vector3(1, Mathf.Clamp (currentResource/finalResource, 0, 1),1);
			lastTime=Time.time;
		}
	}
}
