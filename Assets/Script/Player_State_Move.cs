using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State_Move : Player_State_Ground
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

        //이동
        player.Set_Velocity(player.axis_X * player.move_speed, player.rb.velocity.y);

        //플립체크
        FlipCheck();

        //대쉬 체크
        DashCheck();
    }

    private void DashCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && player.dash_cool_time < 0)
        {
            player.dash_cool_time = player.dash_cool_time_max;
            player.dash_time = player.dash_time_max;
            player.state_machine.ChangeState(player.state_Dash);

        }
    }

    private void FlipCheck()
    {
        if (player.axis_X > 0)
        {
            if (player.faceDir < 0)
            {
                Flip();
            }
            player.faceDir = 1;
        }
        else if (player.axis_X < 0)
        {
            if (player.faceDir > 0)
            {
                Flip();
            }
            player.faceDir = -1;
        }
        if (player.axis_X == 0)
        {
            player.state_machine.ChangeState(player.state_Idle);
        }
    }

    public void Flip()
	{
		player.transform.Rotate(0, 180, 0);
	}
}
