using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State_Ground : Player_State
{
    public Player_State_Ground(Player _player, Player_State_Machine _state_machine, string _anim_bool_name) : base(_player, _state_machine, _anim_bool_name)
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

        if (Input.GetKey(KeyCode.Z))
        {
            state_machine.ChangeState(player.state_PrimaryAttack);
        }

        if (!player.isGround)
        {
            player.state_machine.ChangeState(player.state_Air);
        }

        if (player.isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.state_machine.ChangeState(player.state_Jump);
            }
        }

		//�뽬 üũ
		DashCheck();
    }
}
