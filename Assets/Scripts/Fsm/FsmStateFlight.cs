using UnityEngine;

public class FsmStateFlight : FsmState
{
    private AnimationController animationController;
    private MovementController movementController;
    private InputControl inputControl;
    private float moveSpeed;
    public FsmStateFlight(Fsm fsm, AnimationController animationController, InputControl inputControl, MovementController movementController, float moveSpeed) : base(fsm)
    {
        this.movementController = movementController;
        this.inputControl = inputControl;
        this.moveSpeed = moveSpeed;
        this.animationController = animationController;
    }
    public override void Enter()
    {
        animationController.SetGround(false);
        movementController.DirectionUpdate(inputControl.InputDirection, moveSpeed);
        movementController.ApplyGravity();
        movementController.Move();
    }

    public override void Update()
    {
        movementController.GroundCheck();
        movementController.DirectionUpdate(inputControl.InputDirection, moveSpeed);
        if (movementController.IsGround == true)
        {
            if (inputControl.InputDirection != Vector2.zero)
            {
                fsm.SetState<FsmStateRun>();
                return;
            }
            
            fsm.SetState<FsmStateIdle>();
            return;
        }
        
        movementController.ApplyGravity();
        movementController.Move();

                
        
    }
}
