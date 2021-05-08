using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    public Transform tf;
    public Rigidbody rb;
    public Animator anim;
    public GameObject shadow;

    [Header("移动属性")]
    public float projMove = 1.5f;

    [Header("跳跃属性")]
    public float CoefSpeedAndForce = 0.5f;
    float jumpTime;
    bool jumpPressed;
    bool jumpHeld;
    public bool isJump = false;
    public float jumpForce = 3.0f;
    public float jumpHoldForce = 3.0f;
    public float jumpHoldDuration = 0.15f;
    public float projJumpForce = 8f;

    public Vector3 targetPos;
    GameObject Groundobj;
    public float yCheck;
    bool canBeTraced = true;
    float tempY;
    public enum playerState
    {
        loft,
        onGround,
        onCar,
    };
    public playerState thisState = playerState.onGround;


    // Start is called before the first frame update
    void Start()
    {
        //shadow = GameObject.FindGameObjectWithTag("SongShadow");
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        Groundobj = GameObject.FindGameObjectWithTag("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerIsGroundOrNot();
        PlayerMoveMent();
    }
    private void FixedUpdate()
    {

    }
    void PlayerMoveMent()
    {
        //调用影子的shader
        //var shadowMat = shadow.GetComponent<SpriteRenderer>().material;
        //var playerTex = GetComponent<SpriteRenderer>().sprite.texture;
        //shadowMat.SetTexture("_PlayerTex", playerTex);
        //shadow.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, -6.05f, GetComponent<Transform>().position.z);

        //角色位移
        targetPos = Groundobj.GetComponent<Transform>().position;
        print(thisState);
        switch (thisState)
        {
            case (playerState.onGround):
                {
                    GroundMovement();
                    AirMovement();
                    break;
                }
            case (playerState.loft):
                {
                    break;
                }
            case (playerState.onCar):
                {
                    CarMovement();
                    break;
                }
        }
    }
    void CarMovement()
    {

    }
    void AirMovement()
    {
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;
        if (jumpPressed && !isJump)
        {
            thisState = playerState.loft;
            isJump = true;
            jumpPressed = false;
            jumpTime = Time.time + jumpHoldDuration;
            rb.AddForce(new Vector2(0f, projJumpForce), ForceMode.Impulse);
        }
    }

    void GroundMovement()
    {
        //控制位移
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(new Vector3(movement.x, 0, movement.z) * projMove, ForceMode.Impulse);
        //计算影子的offset，左右移动时角色的flip
        if (canBeTraced && thisState == playerState.onGround)
        {
            //tempY = shadow.GetComponent<Transform>().position.y;
            canBeTraced = false;
        }
        if (rb.velocity.x < -0.1f)
        {
            //shadow.GetComponent<Transform>().localScale = new Vector3(0.87f, shadow.GetComponent<Transform>().localScale.y, shadow.GetComponent<Transform>().localScale.z);
            tf.localScale = new Vector3(-1f, tf.localScale.y, tf.localScale.z);
        }
        else
        {
            tf.localScale = new Vector3(1f, tf.localScale.y, tf.localScale.z);
        }
        if (Mathf.Abs(movement.x + movement.y + movement.z) > 0.1f)
        {
            anim.SetFloat("Walk", 1.0f);
        }
        else
        {
            anim.SetFloat("Walk", 0.1f);
        }

        //最大限速x,y,z方向
        if (Mathf.Abs(rb.velocity.x) >= 3)
        {
            if (rb.velocity.x > 0)
            {
                rb.AddForce(new Vector3(-1 * CoefSpeedAndForce * rb.velocity.x, 0, 0), ForceMode.Impulse);
            }
            else if (rb.velocity.x < 0)
            {
                rb.AddForce(new Vector3(-1 * CoefSpeedAndForce * rb.velocity.x, 0, 0), ForceMode.Impulse);
            }

        }
        if (Mathf.Abs(rb.velocity.z) >= 3)
        {
            if (rb.velocity.z > 0)
            {
                rb.AddForce(new Vector3(0, 0, -1 * CoefSpeedAndForce * rb.velocity.z), ForceMode.Impulse);
            }
            else if (rb.velocity.z < 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -3);
                rb.AddForce(new Vector3(0, 0, -1 * CoefSpeedAndForce * rb.velocity.z), ForceMode.Impulse);
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


    void CheckPlayerIsGroundOrNot()
    {
        yCheck = tf.position.y - targetPos.y;
        //容差error1
        float error1 = 0.05f;
        if (Mathf.Abs(Mathf.Abs(tf.position.y - targetPos.y) - 0.56f) > error1)
        {
            thisState = playerState.loft;
        }
        else
        {
            thisState = playerState.onGround;
            isJump = false;
        }
    }
}
