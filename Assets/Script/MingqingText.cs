using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MingqingText : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.x>8f)
        {
            Destroy(gameObject, 0);
        }
    }
}
