using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : BaseState
{
	public override Vector3 ProcessInput(Vector3 input)
	{
		motor.VerticalSpeed -= motor.Gravity * Time.deltaTime;
		return input;
	}

	public override void Transition()
	{
        if (motor.IsGrounded())
			motor.ChangeState("WalkingState");
	}
	public override void Destuct()
	{
		base.Destuct();
		motor.VerticalSpeed = 0.0f;
	}
}
