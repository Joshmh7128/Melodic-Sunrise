using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : DapperReceiver
{

    float fovKick, fovReturn; // how much our fov is kicked

    public override void OnBeat()
    {
        Camera.main.fieldOfView += fovKick;    
    }

    void FixedUpdate()
    {
        // return the camera to its original fov
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 90, fovReturn * Time.fixedDeltaTime);
    }

    public override void HighMood()
    {
        fovKick = -5;
        fovReturn = 2;
    }
    
    public override void MidMood()
    {
        fovKick = -1;
        fovReturn = 1;
    }
    
    public override void LowMood()
    {
        fovKick = 0.2f;
        fovReturn = 0.05f;
    }

}
