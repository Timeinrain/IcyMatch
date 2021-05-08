using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsFlowing : MonoBehaviour
{

	bool movingDown = true;
	void Start()
	{
		Invoke("StartMakingFlowing", Random.Range(0, 2));
	}

	private void StartMakingFlowing()
	{
		StartCoroutine(FlowingCloud());
	}

	IEnumerator FlowingCloud()
	{
		float time = 0;
		while (true)
		{
			time += Time.deltaTime;
			transform.position += new Vector3(0, time % 2 >= 1 ? 2 * Time.deltaTime : -2 * Time.deltaTime, 0);
			yield return new WaitForEndOfFrame();
		}
	}
}
