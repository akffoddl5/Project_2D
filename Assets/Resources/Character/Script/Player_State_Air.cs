using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State_Air : Player_State
{
	public Player_State_Air(Player _player, Player_State_Machine _state_machine, string _anim_bool_name) : base(_player, _state_machine, _anim_bool_name)
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

		if (player.isWall)
		{
			player.state_machine.ChangeState(player.state_WallSlide);
		}
		if (player.isGround)
		{
			player.state_machine.ChangeState(player.state_Idle);
		}

		if (axis_X != 0)
		{
			player.Set_Velocity(player.move_speed * 0.8f * axis_X, player.rb.velocity.y);
		}

	}
}
