using UnityEngine;
using System.Collections;

public class CherioRotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, 5, Space.Self);
	}
	
}
