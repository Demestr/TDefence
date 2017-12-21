using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCameraState : MonoBehaviour
{
    //protected SmoothCamera smoothCamera;
    protected Camera mainCamera;
    protected CharacterController charController;
    protected SmoothCamera smoothCamera;

    [SerializeField]
    protected float m_sensitivityHor = 9.0f;
    [SerializeField]
    protected float m_sensitivityVert = 9.0f;
    [SerializeField]
    protected float m_minimumVert = -45.0f;
    [SerializeField]
    protected float m_maximumVert = 45.0f;

    protected float m_rotationX = 0;

    public virtual void Construct()
    {
        mainCamera = GetComponentInChildren<Camera>();
        smoothCamera = GetComponent<SmoothCamera>();
        charController = GetComponentInParent<CharacterController>();
    }

    public abstract void Transition();

    public virtual void CameraMove()
    {
        m_rotationX -= Input.GetAxis("Mouse Y") * m_sensitivityHor;
        m_rotationX = Mathf.Clamp(m_rotationX, m_minimumVert, m_maximumVert);
        float delta = Input.GetAxis("Mouse X") * m_sensitivityVert;
        float rotationY = transform.localEulerAngles.y + delta;
        transform.localEulerAngles = new Vector3(m_rotationX, 0, 0);
        charController.transform.Rotate(new Vector3(0, rotationY, 0));
    }
    public virtual void Destuct()
    {
        Destroy(this);
    }

}
