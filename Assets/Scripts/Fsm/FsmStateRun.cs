using UnityEngine;

public class FsmStateRun : FsmState
{
    private AnimationController animationController;
    private MovementController movementController;
    private InputControl inputControl;
    private float jumpSpeed;
    private float moveSpeed;
    public FsmStateRun(Fsm fsm, AnimationController animationController, InputControl inputControl, MovementController movementController, float moveSpeed, float jumpSpeed) : base(fsm)
    {
        this.movementController = movementController;
        this.inputControl = inputControl;
        this.jumpSpeed = jumpSpeed;
        this.moveSpeed = moveSpeed;
        this.animationController = animationController;
    }

    public override void Enter()
    {
        animationController.SetGround(true);
        animationController.SetMove(true);
        movementController.DirectionUpdate(inputControl.InputDirection, moveSpeed);
        if (inputControl.IsJump)
        {
            movementController.Jump(jumpSpeed);
        }
        movementController.ApplyGravity();
        movementController.Move();
    }

    public override void Update()
    {
        movementController.GroundCheck();
        movementController.DirectionUpdate(inputControl.InputDirection, moveSpeed);
        if (movementController.IsGround == false)
        {            
            fsm.SetState<FsmStateFlight>();
            return;
        }
        if (inputControl.InputDirection == Vector2.zero)
        {            
            fsm.SetState<FsmStateIdle>();
            return;
        }
        
        if (inputControl.IsJump)
        {
            movementController.Jump(jumpSpeed);
        }
        movementController.ApplyGravity();
        movementController.Move();        

        
        
    }
}
