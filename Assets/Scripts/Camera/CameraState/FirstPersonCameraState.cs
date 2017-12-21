using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraState : BaseCameraState
{

    public override void Construct()
    {
        base.Construct();
    }

    public override void Transition()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            smoothCamera.ChangeState("ThirdPersonCameraState");
        }
    }

}
