using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public bool isBusy { get; private set; }
	public Vector2[] attackMoveMent =  new Vector2[3];

	public Player_State_Machine state_machine;
	public Animator anim;
	public Rigidbody2D rb;

	[Header("이동 관련 변수")]
	public float move_speed = 2f;
	
	public float faceDir = 1;
	public float dash_cool_time;
	public float dash_cool_time_max;
	public float dash_time;
	public float dash_time_max;
	public float dash_speed;
	public float jump_force;

	[Header("충돌 관련 변수")]
	public bool isGround;
	public bool isWall;
	public Transform wallCheck;
	public Transform groundCheck;
	public float wallCheck_dist;
	public float groundCheck_dist;
	public LayerMask groundMask;
	
	


	public Player_State state_Idle;
	public Player_State state_Move;
	public Player_State state_Jump;
	public Player_State state_Dash;
	public Player_State state_Air;
	public Player_State state_WallSlide;
	public Player_State state_WallJump;
	public Player_State state_PrimaryAttack;
	


	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		state_machine = new Player_State_Machine();
		state_Idle = new Player_State_Idle(this, state_machine, "Idle");
		state_Move = new Player_State_Move(this, state_machine, "Move");
		state_Jump = new Player_State_Jump(this, state_machine, "Jump");
		state_Air = new Player_State_Air(this, state_machine, "Jump");
		state_Dash = new Player_State_Dash(this, state_machine, "Dash");
		state_WallSlide = new Player_State_WallSlide2(this, state_machine, "WallSlide");	//벽타기 애니메이션 없어서 점프 내려올떄고 대체
		state_WallJump = new Player_State_WallJump(this, state_machine, "Jump");	//벽타기 애니메이션 없어서 점프 내려올떄고 대체
		state_PrimaryAttack = new Player_State_PrimaryAttack(this, state_machine, "Attack");	//벽타기 애니메이션 없어서 점프 내려올떄고 대체
		
	}

	private void Start()
	{
		state_machine.Initialize(state_Idle);
	}

	private void Update()
	{

		isGround = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheck_dist, groundMask);
		isWall = Physics2D.Raycast(wallCheck.position, Vector2.right * faceDir, wallCheck_dist, groundMask);

		dash_cool_time -= Time.deltaTime;
		dash_time -= Time.deltaTime;
		anim.SetFloat("yVelocity", rb.velocity.y);

		state_machine.current_state.Update();

	}

	public void ZeroVelocity() => rb.velocity = Vector2.zero;

	public IEnumerator BusyFor(float seconds)
	{
		isBusy = true;
		yield return new WaitForSeconds(seconds);
		isBusy = false;
	}

	public void AnimationTrigger() => state_machine.current_state.AnimationFinishTrigger();

	public void Set_Velocity(float _x, float _y)
	{
		rb.velocity = new Vector3(_x, _y);
		FlipCheck(_x);
	}

    private void OnDrawGizmos()
    {
		Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheck_dist * faceDir, wallCheck.position.y));
		Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y- groundCheck_dist));
    }

	public void FlipCheck(float _x)
	{
		//Debug.Log("flipcheck");
		if (_x > 0)
		{
			//Debug.Log("flag1");
			if (faceDir < 0)
			{
				Flip();
			}
			//faceDir = 1;
		}
		else if (_x < 0)
		{
			//Debug.Log("flag2");
			if (faceDir > 0)
			{
				Flip();
			}
			//faceDir = -1;
		}

	}



	public void Flip()
	{
		faceDir *= -1;
		transform.Rotate(0, 180, 0);
	}



	//private void Flip()
	//{
	//	faceDir = faceDir * -1;
	//	//facingRight = !facingRight;

	//	transform.Rotate(0, 180, 0);
	//}

	//private void FlipController(float xVelocity)
	//{
	//	if (xVelocity > 0 && !(faceDir >0))
	//		Flip();
	//	else if (xVelocity < 0 && faceDir > 0)
	//		Flip();
	//}



}
