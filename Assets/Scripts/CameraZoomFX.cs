using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomFX : MonoBehaviour
{
	private Camera cam;

	[Header("最大放大画面size")]
	public float maximumZoomedSize = 32;
	[Header("变换速度")]
	public float zoomingSpeed = 3;

	float defaultCamSize;
	private void Awake()
	{
		cam = GetComponent<Camera>();
		defaultCamSize = cam.orthographicSize;
		print(defaultCamSize);
	}
	public void ZoomIn()
	{
		StartCoroutine(StartZoomingIn());
	}

	public void ZoomOut()
	{
		StartCoroutine(StartZoomingOut());
	}
	public IEnumerator StartZoomingIn()
	{
		while (true)
		{
			cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, maximumZoomedSize, Time.deltaTime * zoomingSpeed);
			if (cam.orthographicSize - maximumZoomedSize > -0.2f)
			{
				cam.orthographicSize = maximumZoomedSize;
				break;
			}
			yield return new WaitForFixedUpdate();
		}
	}

	public IEnumerator StartZoomingOut()
	{
		while (true)
		{
			cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, defaultCamSize, Time.deltaTime * zoomingSpeed);
			if (cam.orthographicSize - defaultCamSize < 0.2f)
			{
				cam.orthographicSize = defaultCamSize;
				break;
			}
			yield return new WaitForFixedUpdate();
		}
	}
}
