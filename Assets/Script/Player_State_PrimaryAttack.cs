using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State_PrimaryAttack : Player_State
{
	private int comboCounter;
	private float lastTimeAttacked;
	private float comboWindow = 2;
	
	public Player_State_PrimaryAttack(Player _player, Player_State_Machine _state_machine, string _anim_bool_name) : base(_player, _state_machine, _anim_bool_name)
	{
	}

	public override void Enter()
	{
		base.Enter();
		state_timer = 0.2f;

		if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow)
		{
			comboCounter = 0;
		}

		
		player.anim.SetInteger("ComboCounter", comboCounter);

		float attackDir = player.faceDir;
		if (axis_X != 0)
			attackDir = axis_X;

		player.FlipCheck(attackDir);
		player.rb.velocity = new Vector2(player.attackMoveMent[comboCounter].x * player.faceDir, player.attackMoveMent[comboCounter].y + player.rb.velocity.y);

		player.anim.speed = 1.2f;
	}

	public override void Exit()
	{
		base.Exit();

		player.StartCoroutine("BusyFor", 0.2f);
		player.anim.speed = 1;

		comboCounter++;
		lastTimeAttacked = Time.time;
		//Debug.Log(lastTimeAttacked);
		
	}

	public override void Update()
	{
		base.Update();

		if (state_timer < 0)
		{
			player.rb.velocity = new Vector2(0, 0);
		}

		if (triggerCalled)
		{
			state_machine.ChangeState(player.state_Idle);
		}
	}
}
