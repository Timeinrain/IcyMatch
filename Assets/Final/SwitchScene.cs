using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

	public GameObject left;
	public GameObject right;
	public GameObject loadingCanvas;

	public string nextScene;

	public float leftMax = -1600f;
	public float rightMax = 1600f;

	public float translateSpeed = 5.0f;


	private void Awake()
	{
		EnterScene();
	}

	private void EnterScene()
	{
		StartCoroutine(MoveLeft(left));
		StartCoroutine(MoveRight(right));
	}

	public void QuitScene()
	{
		StartCoroutine(MoveLeft(right));
		StartCoroutine(MoveRight(left));
	}

	IEnumerator MoveLeft(GameObject target)
	{
		while (true)
		{
			target.transform.Translate(Vector3.left * Time.deltaTime * translateSpeed);

			//如果是左边，到达最左端停止
			if (target == left)
			{
				if (target.transform.position.x <= leftMax)
				{
					target.transform.position = new Vector3(leftMax, target.transform.position.y, target.transform.position.z);
					break;
				}
			}
			else
			{
				if (target.transform.position.x <= 0)
				{
					target.transform.position = new Vector3(0, target.transform.position.y, target.transform.position.z);
					break;
				}
			}

			yield return new WaitForEndOfFrame();
		}

	}

	IEnumerator MoveRight(GameObject target)
	{
		while (true)
		{

			target.transform.Translate(Vector3.right * Time.deltaTime * translateSpeed);

			if (target == right)
			{
				if (target.transform.position.x >= rightMax)
				{
					target.transform.position = new Vector3(rightMax, target.transform.position.y, target.transform.position.z);
					break;
				}
			}
			else
			{
				if (target.transform.position.x >= 0)
				{
					target.transform.position = new Vector3(0, target.transform.position.y, target.transform.position.z);
					break;
				}
			}
			yield return new WaitForEndOfFrame();
		}
	}

	public void OnBeginLoadScene()
	{
		QuitScene();
		Invoke("LoadNextScene", 2f);
	}

	private void LoadNextScene()
	{
		SceneManager.LoadScene(nextScene);
	}

}
