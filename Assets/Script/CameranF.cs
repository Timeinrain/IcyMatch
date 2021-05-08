using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameranF : MonoBehaviour
{
    [Header("¼àÌý")]
    public Transform Player;//±»¸úËæÎïÌå
    public Vector3 offset;
    public Vector3 PlayerPos;
    public float SwitchingZ = -30f;
    public float speed = 5;
    public GameObject trigger1;
    public Vector3 triggerPos;
    public float offsetx = -10f;
    public float offsety = 8f;
    int onlyInOnce = 1;
    public enum CameraState
    {
        following,
        switchingDynasty
    }
    public CameraState thisState=CameraState.following;
    void Start()
    {
        trigger1 = GameObject.FindWithTag("trigger1");
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        offset = gameObject.transform.position - Player.position;

    }

    private void FixedUpdate()
    {
        triggerPos = trigger1.transform.position;
        zCheck();
        switch(thisState)
        {
            case (CameraState.following):
                {
                    StartCoroutine("FollowPlayer");
                    break;
                }
            case (CameraState.switchingDynasty):
                {
                    //if(onlyInOnce==1)
                    //{
                        SwitchFollowPlayer();
                    //    onlyInOnce = 0;
                    //}
                    //StartCoroutine("SwitchFollowPlayer");
                  
                    break;
                }
        }
    }
    void SwitchFollowPlayer()
    {
        PlayerPos = Player.position + Player.TransformDirection(offset);
        PlayerPos.z = SwitchingZ;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(PlayerPos.x + offsetx, PlayerPos.y + offsety, PlayerPos.z), Time.deltaTime * speed);
    }
    IEnumerator FollowPlayer()
    {
        //local to global
        PlayerPos = Player.position + Player.TransformDirection(offset);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, PlayerPos, Time.deltaTime * speed);
        //¿ªÆôÑÓ³ÙÒ¡»Î
        //gameObject.transform.LookAt(Player);
        yield return 0.5f;
    }
    //IEnumerator SwitchFollowPlayer()
    //{
    //    PlayerPos = Player.position + Player.TransformDirection(offset);
    //    PlayerPos.z = SwitchingZ;
    //    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(PlayerPos.x+offsetx,PlayerPos.y+offsety,PlayerPos.z) , Time.deltaTime * speed);
    //    yield return 0.5f;
    //}

    void zCheck()
    {
        if(Mathf.Abs(Player.position.x - 11.63f)<5f)
        {
            thisState = CameraState.switchingDynasty;
        }
        else
        {
            thisState = CameraState.following;
        }
       
    }

    }

