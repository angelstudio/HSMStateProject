using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterJumpingState : CharacterHSMState
{
    public CharacterJumpingState(Character.State stateId, string debugName = null) : base(stateId, debugName)
    {

    }

    protected override void OnEnter()
    {
        base.OnEnter();

        character.Rigidbody2D.AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if(character.Rigidbody2D.velocity.y <= 0)
        {
            SendEvent(Character.Trigger.Fall);
        }
    }

    protected override void OnExit()
    {
        base.OnExit();
    }
}