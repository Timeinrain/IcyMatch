using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud_move : MonoBehaviour
{
    public GameObject cloudleft;
    public GameObject cloudright;
    public GameObject cloudleft1;
    public GameObject cloudright1;
    public GameObject cloudleft2;
    public GameObject cloudright2;
    public GameObject cloudleft3;
    public GameObject cloudright3;
    public GameObject cloudleft4;
    public GameObject cloudright4;
    public GameObject cloudleft5;
    public GameObject cloudright5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        cloudleft.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 100, Space.World);
        cloudright.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime*100, Space.World);
        cloudleft1.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 100, Space.World);
        cloudright1.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 100, Space.World);
        cloudleft2.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 100, Space.World);
        cloudright2.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 100, Space.World);
        cloudleft3.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 100, Space.World);
        cloudright3.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 100, Space.World);
        cloudleft4.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 100, Space.World);
        cloudright4.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 100, Space.World);
        cloudleft5.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 100, Space.World);
        cloudright5.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 100, Space.World);
    }
}
