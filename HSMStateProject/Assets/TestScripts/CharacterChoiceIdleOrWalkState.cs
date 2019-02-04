using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChoiceIdleOrWalkState : CharacterHSMState
{
    public CharacterChoiceIdleOrWalkState(Character.State stateId, string debugName = null) : base(stateId, debugName)
    {

    }

    protected override void OnEnter()
    {
        base.OnEnter();

        if (character.Rigidbody2D.velocity.x != 0)
        {
            SendEvent(Character.Trigger.Walk);
        }
        else
        {
            SendEvent(Character.Trigger.StopMoving);
        }
    }

    protected override void OnExit()
    {
        base.OnExit();
    }
}