using UnityEngine;
using System.Collections;

public class SuperWallTrigger : MonoBehaviour {

	public GameObject leftWall;
	
	public GameObject rightWall;
	public GameObject superWall;
	
	void Update(){
		DefaultTrackableEventHandler leftTracker=leftWall.GetComponent<DefaultTrackableEventHandler>();
		DefaultTrackableEventHandler rightTracker=leftWall.GetComponent<DefaultTrackableEventHandler>();
		if(!leftTracker.Tracked || !rightTracker.Tracked)
		{
			if(superWall.activeSelf)
			{
				leftWall.SetActive(true);
				rightWall.SetActive(true);
				superWall.SetActive(false);
			}
		}
		
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.name == "superSlammerTrigger")
		{
			if(leftWall.activeSelf && rightWall.activeSelf)
			{
				leftWall.SetActive(false);
				rightWall.SetActive(false);
				superWall.SetActive(true);
			}
		}
	}
	void OnTriggerExit(Collider c)
	{
		if(c.gameObject.name == "superSlammerTrigger")
		{
			if(superWall.activeSelf)
			{
				leftWall.SetActive(true);
				rightWall.SetActive(true);
				superWall.SetActive(false);
			}
		}
	
	}
	
}
