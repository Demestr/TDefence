using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : BaseState
{

	public override void Construct()
	{
        base.Construct();
        motor.VerticalSpeed += motor.JumpingStrengh * Time.deltaTime;
	}
	public override Vector3 ProcessInput(Vector3 input)
	{
		motor.VerticalSpeed -= motor.Gravity * Time.deltaTime;
		return input;
	}

	public override void Transition()
	{
        //if (!motor.IsGrounded())
        //{
        //	motor.ChangeState("FallingState");
        //}
        //else
        //	motor.ChangeState("WalkingState");
        if (motor.VerticalSpeed < 0)
            motor.ChangeState("FallingState");
	}

}
