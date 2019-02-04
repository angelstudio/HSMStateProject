using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterWalkingState : CharacterHSMState
{


    public CharacterWalkingState(Character.State stateId, string debugName = null) : base(stateId, debugName)
    {

    }

    protected override void OnEnter()
    {
        base.OnEnter();

        character.Rigidbody2D.AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if(character.Rigidbody2D.velocity.x == 0)
        {
            SendEvent(Character.Trigger.StopMoving);
        }
    }

    protected override void OnExit()
    {
        base.OnExit();
    }

    protected override TriggerResponse HandleEvent(Character.Trigger trigger)
    {
        switch(trigger)
        {
            case Character.Trigger.Walk:

                if(Input.GetKey(KeyCode.D))
                {
                    character.Rigidbody2D.AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
                }
                else if(Input.GetKey(KeyCode.A))
                {
                    character.Rigidbody2D.AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
                }

                if(character.Rigidbody2D.velocity.x > 3)
                {
                    character.Rigidbody2D.AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
                }
                else if(character.Rigidbody2D.velocity.x < -3)
                {
                    character.Rigidbody2D.AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
                }

                return TriggerResponse.Reject;

            default:
                return TriggerResponse.Accept;
        }
    }
}