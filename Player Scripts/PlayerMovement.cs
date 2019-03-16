using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {

    public Joystick mobileJoystick;
    public PlayerCamera playerCamera;

    [Range(1,20)]
    public float moveSpeed = 6.0f;
    public float jumpForce;
    public float gravity = 10.0f;
    [Range(1, 2)]
    public float sprintMultiplier = 1.0f;
    
    private CharacterController characterController;
    private Vector3 moveDirection;
    private Vector3 desiredRotation;
    private float verticalVelocity;

    private bool isDirectionLocked;

    // Start is called before the first frame update
    void Awake() {
        characterController = GetComponent<CharacterController>();
        moveDirection = Vector3.zero;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.maxAngularVelocity = .02f;
    }

    void Update() {
        //Read Inputs
        moveDirection.x = InputManager.Horizontal();
        moveDirection.z = InputManager.Vertical();

        moveDirection = AlignToAxis(moveDirection, playerCamera.GetLookDirection());

        //Handle Sprinting & Speed
        float sprintBonus = 1;

        if (InputManager.Sprint()) {
            sprintBonus = sprintMultiplier;
        }

        moveDirection = moveDirection * moveSpeed * sprintBonus;

        //Handle Gravity
        if (characterController.isGrounded) {
            verticalVelocity = -gravity * Time.deltaTime;
            if (InputManager.Jump()) {
                verticalVelocity = jumpForce;
            }
        } else {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        moveDirection.y = verticalVelocity;

        

        

        //Move character
        characterController.Move(moveDirection * Time.deltaTime);

        //if (InputManager.FireButton1()) {
        //    isDirectionLocked = true;
        //}

        //if ()



        //Point character
        if (!InputManager.IsFiring()) {
            Vector3 moveDirectionOnPlane = new Vector3(moveDirection.x, 0.0f, moveDirection.z);
            if (moveDirectionOnPlane != Vector3.zero) {
                transform.rotation = Quaternion.LookRotation(moveDirectionOnPlane);
            }
        }

        
    }

    /**
     * Needs optimization possibly //TODO
     **/
    public Vector3 AlignToAxis(Vector3 input, Vector3 axis)
    {
        Vector3 returnVector;
        Vector2 input2d = new Vector2(input.x, input.z);
        Vector2 axis2d = new Vector2(axis.x, axis.z);

        float magnitude = input2d.magnitude;
            
        float differenceAngle = Vector2.SignedAngle(axis2d, input2d);
        returnVector = VectorPlus.DegreeToVector(differenceAngle) * magnitude;

        return returnVector;
        
    }


    
}