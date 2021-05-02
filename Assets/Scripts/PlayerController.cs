using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Rigidbody2D rb;
	[SerializeField] bool isOnGround = false;
	[Header("Which Key To Jump")]
	public KeyCode jumpButton;
	public float jumpForce = 5.0f;
	public float speed = 2.0f;
	Animator anim;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		Jump();
		StartCoroutine(OnGroundCheck());
	}

	IEnumerator OnGroundCheck()
	{
		while (true)
		{
			RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 10f * transform.localScale.y, LayerMask.GetMask("Ground"));
			if (ray.collider)
			{
				isOnGround = true;
			}
			else
			{
				isOnGround = false;
			}
			yield return new WaitForEndOfFrame();
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 10f);

	}

	private void FixedUpdate()
	{
		var vx =
		Input.GetAxisRaw("Horizontal");
		Move(vx);
	}

	private void Jump()
	{
		if (Input.GetKeyDown(jumpButton) && isOnGround)
		{
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	private void Move(float vx)
	{
		if (vx < 0)
		{
			anim.SetFloat("MovingSpeed", 0);
			return;
		}
		rb.velocity = new Vector2(vx * speed, rb.velocity.y);
		anim.SetFloat("MovingSpeed", vx);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			anim.SetBool("IsJump", false);
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			anim.SetBool("IsJump", true);
		}

	}
}
