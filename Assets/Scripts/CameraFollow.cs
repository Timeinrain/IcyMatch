using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera Follow the main character.
/// </summary>
public class CameraFollow : MonoBehaviour
{
	Camera cam;
	Vector3 defaultOffset;
	GameObject player;
	[Header("���ƽ���л�ϵ��")]
	public float smoothness = 5;
	void Start()
	{
		cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		player = GameObject.FindWithTag("Player");
		defaultOffset = cam.gameObject.transform.position - player.transform.position;
	}

	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, player.transform.position + defaultOffset, Time.deltaTime * smoothness);
	}
}
