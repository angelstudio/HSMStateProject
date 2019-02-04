using UnityEngine;

public class Character : MonoBehaviour
{
    public enum State : byte
    {
        Base,
        Alive,
        Dead,
        Grounded,
        Jumping,
        Falling,
        Standing,
        Ducking,
        Idle,
        Walking,
        Pushing,
        Hidden,
        OnAir,
        ChoiceJumpOrFall,
        ChoiceIdleOrWalk
    }

    public enum Trigger : byte
    {
        Die,
        Ground,
        Jump,
        Fall,
        Stand,
        Duck,
        Walk,
        StopMoving,
        Push,
        StopPushing,
        Hide,
        StopHiding
    }

    public Rigidbody2D Rigidbody2D;
    public SpriteRenderer spriteRenderer;

    [SerializeField]
    private CharacterHSMStateAsset hsmAsset;

    private CharacterHSMState hsm;

    private void Awake()
    {
        hsm = (CharacterHSMState)CharacterHSMStateAsset.BuildFromAsset(hsmAsset);

        hsm.SetStateComparer(delegate (State a, State b) { return a == b; });
        hsm.SetTriggerComparer(delegate (Trigger a, Trigger b) { return a == b; });

        hsm.PropagateCharacterReference(this);

        hsm.Enter();

    }

    private void Update()
    {

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            hsm.SendEvent(Trigger.Walk);
            
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            hsm.SendEvent(Trigger.Duck);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            hsm.SendEvent(Trigger.Stand);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            hsm.SendEvent(Trigger.Jump);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            hsm.SendEvent(Trigger.Hide);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            hsm.SendEvent(Trigger.StopHiding);
        }
        

        if(Input.GetKeyDown(KeyCode.E))
        {
            hsm.SendEvent(Trigger.Push);
        }
        else if(Input.GetKeyUp(KeyCode.E))
        {
            hsm.SendEvent(Trigger.StopPushing);
        }

        hsm.Update();
    }
}
