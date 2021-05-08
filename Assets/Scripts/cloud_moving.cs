using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud_moving : MonoBehaviour
{

	public bool left_or_not;
	public float speed = 100;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{


	}

	public void StartMoving()
	{
		StartCoroutine(Moving());
	}

	public void Recover()
	{
		StartCoroutine(MovingBack());
	}

	IEnumerator Moving()
	{
		while (true)
		{

			if (left_or_not)
			{
				this.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed, Space.World);
			}
			else
			{
				this.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed, Space.World);
			}

			yield return new WaitForEndOfFrame();
		}
	}

	IEnumerator MovingBack()
	{
		while (true)
		{
			if (left_or_not)
			{
				this.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed, Space.World);
			}
			else
			{
				this.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed, Space.World);
			}
			yield return new WaitForEndOfFrame();
		}
	}
}
