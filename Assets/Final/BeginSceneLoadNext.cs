using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginSceneLoadNext : MonoBehaviour
{
	// Start is called before the first frame update
	SwitchScene switchScene;

	void Start()
	{
		Invoke("LoadNext", 6f);
	}

	void LoadNext()
	{
		FindObjectOfType<SwitchScene>().OnBeginLoadScene();
	}
}
