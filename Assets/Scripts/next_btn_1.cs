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
        text.text = "当然，人不可能长着马蹄。住在温暖地区的中原人并不知道，" +
            "这些是钉灵人用来御寒的毛皮长裤和在雪中快速行走的圆形滑板。\n\n" +
            "你能分辨出来，下面哪一个是《山海经》中描述的钉灵人吗？";
    }
}
