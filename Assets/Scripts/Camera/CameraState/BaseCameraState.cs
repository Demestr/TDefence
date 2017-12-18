using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCameraState : MonoBehaviour
{
    protected Camera mainCamera;

    public virtual void Constract()
    {
        mainCamera = GetComponent<Camera>();
    }

    public abstract void Transition();

    public virtual void Destuct()
    {
        Destroy(this);
    }

    public abstract Vector3 OffsetVector {get; set;}
}
