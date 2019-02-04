using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterFallingState : CharacterHSMState
{
    public CharacterFallingState(Character.State stateId, string debugName = null) : base(stateId, debugName)
    {

    }

    protected override void OnEnter()
    {
        base.OnEnter();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if(character.Rigidbody2D.velocity.y == 0)
        {
            SendEvent(Character.Trigger.Ground);
        }
    }

    protected override void OnExit()
    {
        base.OnExit();
    }
}