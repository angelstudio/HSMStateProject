using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChoiceJumpOrFallState : CharacterHSMState
{
    public CharacterChoiceJumpOrFallState(Character.State stateId, string debugName = null) : base(stateId, debugName)
    {

    }

    protected override void OnEnter()
    {
        base.OnEnter();

        if(lastTrigger == Character.Trigger.Jump)
        {
            SendEvent(Character.Trigger.Jump);
        }
        else
        {
            SendEvent(Character.Trigger.Fall);
        }
    }

    protected override void OnExit()
    {
        base.OnExit();
    }
}