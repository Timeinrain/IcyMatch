using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next_btn_2 : MonoBehaviour
{
    [SerializeField]
    private int callCnt = 0;
    public List<GameObject> callPanels;

    public void CntAdd()
    {
        callCnt++;
    }

    public void CallNextPanel()
    {
        if (callPanels.Count > callCnt)
        {
            if (callCnt != 0)
                callPanels[callCnt - 1].SetActive(false);
            callPanels[callCnt].SetActive(true);
        }
    }




}
