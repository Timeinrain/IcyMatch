using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class next_btn_1 : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeText()
    {
        //text = GameObject.Find("dialogue1/text").GetComponent<Text>();
        text.text = "��Ȼ���˲����ܳ������㡣ס����ů��������ԭ�˲���֪����" +
            "��Щ�Ƕ���������������ëƤ�������ѩ�п������ߵ�Բ�λ��塣\n\n" +
            "���ֱܷ������������һ���ǡ�ɽ�������������Ķ�������";
    }
}
