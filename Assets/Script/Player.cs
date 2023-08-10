using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Player_State_Machine state_machine;
	public Animator anim;
	public Rigidbody2D rb;

	[Header("이동 관련 변수")]
	public float move_speed = 2f;
	public float axis_X;
	public float faceDir;
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
	


	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		state_machine = new Player_State_Machine();
		state_Idle = new Player_State_Idle(this, state_machine, "Idle");
		state_Move = new Player_State_Move(this, state_machine, "Move");
		state_Jump = new Player_State_Jump(this, state_machine, "Jump");
		state_Dash = new Player_State_Dash(this, state_machine, "Dash");
	}

	private void Start()
	{
		state_machine.Initialize(state_Idle);
	}

	private void Update()
	{

		isGround = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheck_dist, groundMask);
		Debug.Log(isGround + "초기화...");
		isWall = Physics2D.Raycast(wallCheck.position, Vector2.right * faceDir, wallCheck_dist, groundMask);

		state_machine.current_state.Update();

	}

	public void Set_Velocity(float _x, float _y)
	{
		rb.velocity = new Vector3(_x, _y);
	}

    private void OnDrawGizmos()
    {
		Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheck_dist * faceDir, wallCheck.position.y));
		Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y- groundCheck_dist));
    }



}
