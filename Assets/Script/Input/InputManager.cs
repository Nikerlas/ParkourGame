using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    PlayerLocomotion playerLocomotion;
    AnimatorManager animManager;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool shiftInput;
    public bool altInput;
    public bool spaceInput;

    private void Awake()
    {
        animManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            playerControls.PlayerActions.Sprint.performed += i => shiftInput = true;
            playerControls.PlayerActions.Sprint.canceled += i => shiftInput = false;
            
            playerControls.PlayerActions.Walk.performed += i => altInput = true;
            playerControls.PlayerActions.Walk.canceled += i => altInput = false;

            playerControls.PlayerActions.Jump.performed += i => spaceInput = true;
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInput()
    {
        HandleMovementInput();
        HandleSprintingInput();
        HandleWalkingInput();
        HandleJumpInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animManager.UpdateAnimatorValues(0, moveAmount, playerLocomotion.isSprinting, playerLocomotion.isWalking);
    }

    private void HandleSprintingInput()
    {
        if(shiftInput) playerLocomotion.isSprinting = true;
        else playerLocomotion.isSprinting = false;
    }

    private void HandleWalkingInput()
    {
        if(altInput) playerLocomotion.isWalking = true;
        else playerLocomotion.isWalking = false;
    }

    private void HandleJumpInput()
    {
        if(spaceInput) 
        {
            spaceInput = false;
            playerLocomotion.HandleJumping();
        }
    }
}
