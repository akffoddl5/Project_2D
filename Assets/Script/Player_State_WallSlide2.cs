using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State_WallSlide2 : Player_State
{
	public Player_State_WallSlide2(Player _player, Player_State_Machine _state_machine, string _anim_bool_name) : base(_player, _state_machine, _anim_bool_name)
	{
	}

	public override void Enter()
	{
		base.Enter();
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void Update()
	{
		base.Update();

		if (Input.GetKeyDown(KeyCode.Space))
		{
			player.state_machine.ChangeState(player.state_WallJump);
			return;
		}

		if (axis_X != 0 && player.faceDir != axis_X)
		{
			player.state_machine.ChangeState(player.state_Idle);
		}

		if (axis_Y < 0)
		{
			//player.rb.velocity = new Vector2(0, player.rb.velocity.y);

		}
		else
		{

			player.rb.velocity = new Vector2(player.rb.velocity.x, player.rb.velocity.y * 0.1f);
		}

		if (player.isGround)
		{
			player.state_machine.ChangeState(player.state_Idle);
		}
	}
}
