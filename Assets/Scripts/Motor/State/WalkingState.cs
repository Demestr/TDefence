using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : BaseState
{
	public override Vector3 ProcessInput(Vector3 input)
	{
		return input;
	}

	public override void Transition()
	{
        //Переделать под 
        //if (!motor.IsGrounded())
			//motor.ChangeState("FallingState");
         if(Input.GetKeyDown(KeyCode.Space))
			motor.ChangeState("JumpingState");
	}
}
