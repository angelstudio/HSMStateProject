using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHiddenState : CharacterHSMState
{
    public CharacterHiddenState(Character.State stateId, string debugName = null) : base(stateId, debugName)
    {

    }

    protected override void OnEnter()
    {
        base.OnEnter();
    }

    protected override void OnExit()
    {
        base.OnExit();
    }

    protected override TriggerResponse HandleEvent(Character.Trigger trigger)
    {
        switch(trigger)
        {
            case Character.Trigger.Jump:
                return TriggerResponse.Reject;

            default:
                return TriggerResponse.Accept;
        }
    }
}