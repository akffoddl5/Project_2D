using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Player_State_Move : Player_State
{
	public Player_State_Move(Player _player, Player_State_Machine _state_machine, string _anim_bool_name) : base(_player, _state_machine, _anim_bool_name)
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
		player.Set_Velocity(axis_X * player.move_speed, player.rb.velocity.y);
		if (axis_X == 0)
		{
			player.state_machine.ChangeState(player.state_Idle);
		}
	}
}
