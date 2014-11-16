/*============================================================================== 
 * Copyright (c) 2012-2014 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/

using UnityEngine;
using System.Collections;

public class BackgroundTextureAppManager : AppManager 
{
    public NegativeGrayscaleEffect m_Effect;
    public VideoTextureBehaviour m_VideoTexBhvr;
    private bool mCameraView;
	public Quaternion initBoardRotation;
    
    public override void InitManager ()
    {
        base.InitManager ();
        m_VideoTexBhvr.InitBehaviour();
        m_Effect.InitEffect();

		initBoardRotation = GameObject.Find("ARCamera").camera.transform.rotation;
    }
    
    public override void Draw()
    {
        base.Draw();
        switch(mActiveViewType)
        {
            case ViewType.SPLASHVIEW:
                mCameraView = false;
                break;
            case ViewType.ABOUTVIEW:
                mCameraView = false;
                break;
            case ViewType.UIVIEW:
                mCameraView = false;
                break;
            case ViewType.ARCAMERAVIEW:
                mCameraView = true; 
                break;
        }
    }

    public override void UpdateManager ()
    {
        base.UpdateManager();
        if(mCameraView) {
            m_Effect.UpdateEffect();
            m_VideoTexBhvr.UpdateBehaviour();
        }
    }

	public Quaternion getInitAngle(){
		return initBoardRotation;
	}
}