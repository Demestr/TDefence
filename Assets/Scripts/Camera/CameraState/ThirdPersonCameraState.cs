using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraState : BaseCameraState
{
    public override void Construct()
    {
        base.Construct();
        mainCamera.transform.localPosition += new Vector3(-0.3f, 0, -0.9f);
    }

    public override void CameraMove()
    {
        if (Input.GetMouseButton(1))
        {
            m_rotationX -= Input.GetAxis("Mouse Y") * m_sensitivityHor;
            m_rotationX = Mathf.Clamp(m_rotationX, m_minimumVert, m_maximumVert);
            float delta = Input.GetAxis("Mouse X") * m_sensitivityVert;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(m_rotationX, rotationY, 0);
        }
        else
            base.CameraMove();
    }

    public override void Transition()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            smoothCamera.ChangeState("FirstPersonCameraState");
        }
    }
}
