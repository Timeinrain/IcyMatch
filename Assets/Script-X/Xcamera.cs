using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Xcamera : MonoBehaviour
{
    [Header("���Լ���")]
    public Transform Player;//����������
    public Vector3 offset;//����
    public Vector3 PlayerPos;
    public float speed = 5;
    void Start()
    {
        offset = gameObject.transform.position - Player.position;
    }

    private void FixedUpdate()
    {
        StartCoroutine("fllowPlayer");
    }

    IEnumerator fllowPlayer()
    {
        //local 2 global
        PlayerPos = Player.position + Player.TransformDirection(offset);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, PlayerPos, Time.deltaTime * speed);
        //gameObject.transform.LookAt(Player);
        yield return 0.5f;
    }
}
