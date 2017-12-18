using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
	[SerializeField]
	private Transform target;

	[SerializeField]
	private bool isAutoConfigured = true;

	[SerializeField]
	private Vector3 offset;

	private void Start()
	{
		if(isAutoConfigured)
		offset = transform.position - target.position;
	}

	private void LateUpdate()
	{
		transform.position = target.position + offset;
	}
}
