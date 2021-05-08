using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixToVertical : MonoBehaviour
{
	[Header("强行归正的力度")]
	public float fixForce;
	Rigidbody2D rb;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	void Start()
	{
		StartCoroutine(FixingVertical());
	}

	IEnumerator FixingVertical()
	{
		while (true)
		{
			rb.MoveRotation(Mathf.Lerp(rb.rotation, 0, Time.deltaTime * fixForce));
			yield return new WaitForEndOfFrame();
		}
	}
}
