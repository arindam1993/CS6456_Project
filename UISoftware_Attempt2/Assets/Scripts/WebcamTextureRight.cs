//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;

public class WebcamTextureRight : MonoBehaviour {
	public void Awake(){
		Debug.Log ("Initialize left Camera");

		WebCamDevice[] devices = WebCamTexture.devices;
		string backCamName="";
		for( int i = 0 ; i < devices.Length ; i++ ) {
			Debug.Log("Device:"+devices[i].name+ "IS FRONT FACING:"+devices[i].isFrontFacing);
			
			if (!devices[i].isFrontFacing) {
				backCamName = devices[i].name;
			}
		}
		
		backCamName = devices[1].name;
		WebCamTexture webcamTexture = new WebCamTexture(backCamName,1280,720,30);
		renderer.material.mainTexture = webcamTexture;
		webcamTexture.Play ();
		renderer.material.mainTextureScale = new Vector2 (-1, -1);
		renderer.material.mainTextureOffset = new Vector2 (1, 1);
	}
	/*public void Initialize(int z){
		Debug.Log ("Initialize");

		//set up camera
		WebCamDevice[] devices = WebCamTexture.devices;
		string backCamName="";
		for( int i = 0 ; i < devices.Length ; i++ ) {
			Debug.Log("Device:"+devices[i].name+ "IS FRONT FACING:"+devices[i].isFrontFacing);
			
			if (!devices[i].isFrontFacing) {
				backCamName = devices[i].name;
			}
		}

		backCamName = devices[z].name;
		WebCamTexture webcamTexture = new WebCamTexture(backCamName,10000,10000,30);
		renderer.material.mainTexture = webcamTexture;
		webcamTexture.Play ();

	}*/
}

