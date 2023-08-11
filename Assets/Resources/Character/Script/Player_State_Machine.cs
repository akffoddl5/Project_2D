using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State_Machine
{

    public Player_State current_state;
    


    public void Initialize(Player_State state)
    {
        current_state = state;
        current_state.Enter();

    }

    public void ChangeState(Player_State state)
    {
        current_state.Exit();
        current_state = state;
        current_state.Enter();
    }
    


}
