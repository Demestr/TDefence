using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{

	protected BaseMotor motor;

	public virtual void Construct()
	{
		motor = GetComponent<BaseMotor>();
	}

	public abstract void Transition();

	public virtual void Destuct()
	{
		Destroy(this);
	}

	public abstract Vector3 ProcessInput(Vector3 input);
}
