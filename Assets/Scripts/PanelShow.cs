using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelShow : MonoBehaviour
{

	public List<GameObject> panels;
	public float showSpeed = 5;
	[SerializeField] int showId = 0;
	[SerializeField] int currentInShow;
	public void ShowPanel()
	{
		showId = showId % panels.Count;
		currentInShow = showId;
		StartCoroutine(FadeIn(currentInShow));
		showId++;
	}

	public void HidePanel()
	{
		StartCoroutine(FadeOut(currentInShow));
	}

	IEnumerator FadeIn(int currentInShowID)
	{
		while (true)
		{
			Color col = panels[currentInShowID].GetComponent<Text>().color;
			panels[currentInShowID].GetComponent<Text>().color = Color.Lerp(panels[currentInShowID].GetComponent<Text>().color, new Color(col.r, col.g, col.b, 1), Time.deltaTime * showSpeed);
			if (panels[currentInShowID].GetComponent<Text>().color.a > 0.9)
			{
				panels[currentInShowID].GetComponent<Text>().color = new Color(col.r, col.g, col.b, 1);
				break;
			}
			yield return new WaitForEndOfFrame();
		}
	}

	IEnumerator FadeOut(int currentInShowID)
	{
		while (true)
		{
			Color col = panels[currentInShowID].GetComponent<Text>().color;
			panels[currentInShowID].GetComponent<Text>().color = Color.Lerp(panels[currentInShowID].GetComponent<Text>().color, new Color(col.r, col.g, col.b, 0), Time.deltaTime * showSpeed);
			if (panels[currentInShowID].GetComponent<Text>().color.a < 0.1)
			{
				panels[currentInShowID].GetComponent<Text>().color = new Color(col.r, col.g, col.b, 0);
				break;
			}
			yield return new WaitForEndOfFrame();
		}
	}


}
