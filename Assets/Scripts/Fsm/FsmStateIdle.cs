using UnityEngine;

public class FsmStateIdle : FsmState
{
    private AnimationController animationController;
    private MovementController movementController;
    private InputControl inputControl;
    private float jumpSpeed;

    public FsmStateIdle(Fsm fsm, AnimationController animationController, InputControl inputControl, MovementController movementController,float jumpSpeed) : base(fsm)
    {
        this.movementController = movementController;
        this.inputControl = inputControl;
        this.jumpSpeed = jumpSpeed;
        this.animationController = animationController;
    }

    public override void Enter()
    {
        animationController.SetGround(true);
        animationController.SetMove(false);
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
        if (movementController.IsGround == false)
        {
            fsm.SetState<FsmStateFlight>();
            return;
        }
        if (inputControl.InputDirection != Vector2.zero)
        {
            fsm.SetState<FsmStateRun>();
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
