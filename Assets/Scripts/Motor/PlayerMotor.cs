using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : BaseMotor
{

	protected override void Start()
	{
		base.Start();

		ChangeState("WalkingState");
	}

	protected override void Update()
	{
		//Get input
		moveVector = GetInput();

		state.Transition();
		//Process input
		moveVector = state.ProcessInput(moveVector);


		//Move
		Move();
		Animate();
	}

	private Vector3 GetInput()
	{
		Vector3 input = Vector3.zero;

		input.x = Input.GetAxis("Horizontal");
		input.z = Input.GetAxis("Vertical");
		input = input.magnitude > 1 ? input.normalized : input;

		return input;
	}
}
