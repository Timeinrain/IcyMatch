using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	Camera cam;
	Vector3 defaultOffset;
	GameObject player;
	[Header("���ƽ���л�ϵ��")]
	public float smoothness = 5;
	void Start()
	{
		cam = GetComponent<Camera>();
		player = GameObject.FindWithTag("Player");
		defaultOffset = cam.gameObject.transform.position - player.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, player.transform.position + defaultOffset, Time.deltaTime * smoothness);

	}
}
