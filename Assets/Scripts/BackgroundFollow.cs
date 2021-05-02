using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
	Camera cam;
	Vector3 offset;
	void Start()
	{
		cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
		offset = transform.position - cam.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = cam.transform.position + offset;
	}
}
