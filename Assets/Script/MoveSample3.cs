using UnityEngine;
using System.Collections;

public class MoveSample3 : MonoBehaviour
{
    public Vector3 V = new Vector3(20, 0, 0);
    public float Time = 100;
    public GameObject flowChart1;
    public int triigerflag = 0;
    public GameObject playertf;
    void Start()
    {
        //iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", 3));
        //flowChart1 = GameObject.FindWithTag("flowChart2");
        //flowChart1.SetActive(false);
        playertf = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        checkPlayer();
        if (triigerflag == 1)
        {
            iTween.MoveBy(gameObject, V, Time);
            triigerflag = 2;

        }
    }

    void checkPlayer()
    {
        if (playertf.transform.position.x > 21.2f)
        {
            if (triigerflag == 0)
            {
                triigerflag = 1;
            }
        }
    }

}

