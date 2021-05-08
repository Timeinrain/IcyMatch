using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dynamically move the background image.
/// </summary>
public class BackgroundFollow : MonoBehaviour
{
	Camera cam;
	Vector3 offset;
	void Start()
	{
		cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
		offset = transform.position - cam.transform.position;
	}

	void Update()
	{
		transform.position = cam.transform.position + offset;
	}
}
