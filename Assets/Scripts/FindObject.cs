using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindObject : MonoBehaviour
{
    public GameObject next_btn_2;
    public GameObject dialogue2;
    public GameObject hutui_shade;
    public GameObject kaorou_shade;
    public GameObject tuzhi_shade;
    public GameObject final_dialogue;
    public GameObject next_btn_3;
    private int findObject_count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangehutuiColor()
    {
        if (hutui_shade.GetComponent<Image>().color != Color.white)
        {
            hutui_shade.GetComponent<Image>().color = Color.white;
            findObject_count++;
        }

    }
    public void ChangekaorouColor()
    {
        if (kaorou_shade.GetComponent<Image>().color != Color.white)
        {
            kaorou_shade.GetComponent<Image>().color = Color.white;
            findObject_count++;
        }

    }
    public void ChangetuzhiColor()
    {
        if (tuzhi_shade.GetComponent<Image>().color != Color.white)
        {
            tuzhi_shade.GetComponent<Image>().color = Color.white;
            findObject_count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            next_btn_2.SetActive(false);
            dialogue2.SetActive(false);
        }
        if (findObject_count == 3)
        {
            gameObject.SetActive(false);
            final_dialogue.SetActive(true);
            next_btn_3.SetActive(true);
        }

    }
}
