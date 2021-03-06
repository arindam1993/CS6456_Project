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

public class WebcamTextureLeft : MonoBehaviour {
	public void Awake(){
		Debug.Log ("Initialize left Camera");

		renderer.material.mainTextureScale = new Vector2 (-1, 1);
		renderer.material.mainTextureOffset = new Vector2 (1, 0);
	}

	public void Initialize(){
		// Create texture of size 0 that will be updated in the plugin (we allocate buffers in native code)
		var mTexture = new Texture2D(0, 0, TextureFormat.RGB565, false);
		
		mTexture.filterMode = FilterMode.Bilinear;
		mTexture.wrapMode = TextureWrapMode.Clamp;
		
		// Assign texture to the renderer
		renderer.material.mainTexture = mTexture;
		
		// Set the texture to render into:
		if (!QCARRenderer.Instance.SetVideoBackgroundTexture(mTexture))
		{
			Debug.Log("Failed to setVideoBackgroundTexture " + mTexture.GetNativeTextureID());
		}
		else
		{
			Debug.Log("Successfully setVideoBackgroundTexture " + +mTexture.GetNativeTextureID());
		}
	}
}

