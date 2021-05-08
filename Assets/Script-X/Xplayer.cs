using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Xplayer : MonoBehaviour
{
    private Transform tf;
    private Rigidbody rb;
    private Animator anim;
    string lastTrigger;
    [Header("“∆∂Ø Ù–‘")]
    public float projMove = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        tf = transform;
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundMovement();
    }

    void SetTrigger(string trigger)
    {
        if (!string.IsNullOrEmpty(lastTrigger))
            anim.ResetTrigger(lastTrigger);

        anim.SetTrigger(trigger);
        lastTrigger = trigger;
    }


    void GroundMovement()
    {

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        if (moveHorizontal!=0)
        {
            SetTrigger("go");
         }
        else
            SetTrigger("stop");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(new Vector3(movement.x, 0, movement.z) * projMove, ForceMode.Impulse);
        if (Mathf.Abs(rb.velocity.x) >= 3)
        {
            if (rb.velocity.x > 0)
            {
                rb.velocity = new Vector3(3, rb.velocity.y, rb.velocity.z);
            }
            else if (rb.velocity.x < 0)
            {
                rb.velocity = new Vector3(-3, rb.velocity.y, rb.velocity.z);
            }

        }
        if (Mathf.Abs(rb.velocity.z) >= 3)
        {
            if (rb.velocity.z > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 3);
            }
            else if (rb.velocity.z < 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -3);
            }
        }
        if (Mathf.Abs(rb.velocity.y) >= 6)
        {
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, 6, rb.velocity.z);
            }
            else if (rb.velocity.y < 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, -6, rb.velocity.z);
            }

        }
    }
}
