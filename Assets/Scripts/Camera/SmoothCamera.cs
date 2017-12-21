using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
	[SerializeField]
	private Transform target;

    protected BaseCameraState state;
    protected Camera mainCamera;

    private void Start()
	{
        mainCamera = GetComponent<Camera>();

        ChangeState("FirstPersonCameraState");
	}

    private void Update()
    {
        state.CameraMove();
        state.Transition();
    }

    public void ChangeState(string stateName)
    {
        if (state != null)
            state.Destuct();


        System.Type type = System.Type.GetType(stateName);
        state = gameObject.AddComponent(type) as BaseCameraState;

        state.Construct();
    }
}
