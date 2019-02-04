using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDuckingState : CharacterHSMState
{
    public CharacterDuckingState(Character.State stateId, string debugName = null) : base(stateId, debugName)
    {

    }

    protected override void OnEnter()
    {
        base.OnEnter();

        character.spriteRenderer.color = Color.red;
    }

    protected override void OnExit()
    {
        base.OnExit();
    }

    protected override TriggerResponse HandleEvent(Character.Trigger trigger)
    {
        switch(trigger)
        {
            case Character.Trigger.Push:
                return TriggerResponse.Reject;

            default:
                return TriggerResponse.Accept;
        }
    }
}