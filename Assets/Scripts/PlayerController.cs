using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	Rigidbody2D rb;
	[Header("To check if it's on ground")]
	[SerializeField] bool isOnGround = false;
	[Header("Which Key To Jump")]
	public KeyCode jumpButton;
	[Header("Jump Force")]
	public float jumpForce = 5.0f;
	[Header("How fast it should walk")]
	public float speed = 2.0f;
	Animator anim;
	[Header("Maximun of the walking speed")]
	public float maxSpeed = 10;

	public List<string> contents;
	public Text targetPlay;

	int textIndex = -1;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		StartCoroutine(OnGroundCheck());
	}

	// Update is called once per frame
	void Update()
	{
		Jump();
	}

	/// <summary>
	/// Check if it's on ground
	/// </summary>
	/// <returns></returns>
	IEnumerator OnGroundCheck()
	{
		while (true)
		{
			RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 4f, LayerMask.GetMask("Ground"));
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
		Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 4f);
	}

	private void FixedUpdate()
	{
		var vx = Input.GetAxisRaw("Horizontal");
		Move(vx);
	}

	/// <summary>
	/// Jump
	/// </summary>
	private void Jump()
	{
		if (Input.GetKeyDown(jumpButton) && isOnGround)
		{
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	/// <summary>
	/// Move with vx as horizontal axis
	/// </summary>
	/// <param name="vx"></param>
	private void Move(float vx)
	{
		if (vx < 0)
		{
			anim.SetFloat("MovingSpeed", 0);
			return;
		}
		if (Mathf.Abs(rb.velocity.x) < maxSpeed)
			rb.AddForce(new Vector2(vx * speed * Time.deltaTime * 100, 0));
		anim.SetFloat("MovingSpeed", vx);
	}

	/// <summary>
	/// Touching Ground
	/// </summary>
	/// <param name="collision"></param>
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			anim.SetBool("IsJump", false);
		}
	}

	/// <summary>
	/// Exit touching ground
	/// </summary>
	/// <param name="collision"></param>
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			anim.SetBool("IsJump", true);
		}

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("trigger1"))
		{
			FindObjectOfType<SwitchScene>().OnBeginLoadScene();
		}
		if (collision.CompareTag("CamOutTrigger"))
		{
			textIndex++;
			targetPlay.text = contents[textIndex];
			FindObjectOfType<CameraZoomFX>().ZoomIn();
			StartCoroutine(FadeIn());
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("CamOutTrigger"))
		{
			FindObjectOfType<CameraZoomFX>().ZoomOut();
			StartCoroutine(FadeOut());
		}
	}

	IEnumerator FadeIn()
	{
		while (true)
		{
			Color col = targetPlay.GetComponent<Text>().color;
			targetPlay.GetComponent<Text>().color = Color.Lerp(targetPlay.GetComponent<Text>().color, new Color(col.r, col.g, col.b, 1), Time.deltaTime * 5);
			if (targetPlay.GetComponent<Text>().color.a > 0.9)
			{
				targetPlay.GetComponent<Text>().color = new Color(col.r, col.g, col.b, 1);
				break;
			}
			yield return new WaitForEndOfFrame();
		}
	}

	IEnumerator FadeOut()
	{
		while (true)
		{
			Color col = targetPlay.GetComponent<Text>().color;
			targetPlay.GetComponent<Text>().color = Color.Lerp(targetPlay.GetComponent<Text>().color, new Color(col.r, col.g, col.b, 0), Time.deltaTime * 5);
			if (targetPlay.GetComponent<Text>().color.a < 0.1)
			{
				targetPlay.GetComponent<Text>().color = new Color(col.r, col.g, col.b, 0);
				break;
			}
			yield return new WaitForEndOfFrame();
		}
	}

}
