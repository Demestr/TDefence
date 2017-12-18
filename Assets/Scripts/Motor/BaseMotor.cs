using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public abstract class BaseMotor : MonoBehaviour
{

	[SerializeField]
	private float baseSpeed = 5.0f;
	private float baseGravity = 10f;
	private float baseJumpingStrengh = 250f;
	protected CharacterController characterController;
	protected Transform thisTransform;
	protected Animator characterAC;
	protected Vector3 moveVector;
	protected BaseState state;


	public float Gravity { get { return baseGravity; } }
	public float VerticalSpeed { get; set; }
	public float JumpingStrengh { get { return baseJumpingStrengh; } }
	protected virtual void Start()
	{
		characterController = GetComponent<CharacterController>();
		characterAC = GetComponent<Animator>();
		thisTransform = transform;
	}

	protected abstract void Update();
	protected void Move()
	{
		characterController.Move(moveVector * baseSpeed * Time.deltaTime);
		characterController.Move(Vector3.up * VerticalSpeed * Time.deltaTime);
	}

	protected void Animate()
	{
		float currentSpeed = moveVector.magnitude;
		characterAC.SetFloat("Speed", currentSpeed);
	}

	public bool IsGrounded()
	{
		return Physics.Raycast(thisTransform.position, Vector3.down, 0.1f);
	}

	public void ChangeState(string stateName)
	{
		if (state != null)
			state.Destuct();


		System.Type type = System.Type.GetType(stateName);
		state = gameObject.AddComponent(type) as BaseState;

		state.Construct();
	}
}
