using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State
{
    public Player_State_Machine state_machine;
    public Player player;
    public string anim_bool_name;

    public float axis_X;

    public Player_State(Player _player, Player_State_Machine _state_machine, string _anim_bool_name)
    {
        player = _player;
        state_machine = _state_machine;
        anim_bool_name = _anim_bool_name;
	}

	public virtual void Enter()
	{
        player.anim.SetBool(anim_bool_name, true);
        Debug.Log(anim_bool_name + " 킴");
	}

    public virtual void Update()
    {
        
        axis_X = Input.GetAxisRaw("Horizontal");
        //Debug.Log("axis_X ..." + axis_X);

	}

	public virtual void Exit()
	{
        player.anim.SetBool(anim_bool_name, false);
	}


}
