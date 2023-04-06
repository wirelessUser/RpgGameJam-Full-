using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :  SingletonScriptMonoBehaviour<Player>
{
    // Player Animation Parameters
    public  float  xInput;
    public  float yInput;
    public bool isWalking;
    public bool isRunning;
    public bool isIdle;
  //  public static int toolEffect;
    public  bool isUsingToolRight;
    public bool isUsingToolLeft;
    public bool isUsingToolUp;
    public bool isUsingToolDown;
    public bool isLiftingToolRight;
    public bool isLiftingToolLeft;
    public bool isLiftingToolUp;
    public bool isLiftingToolDown;
    public bool isSwingingToolRight;
    public bool isSwingingToolLeft;
    public bool isSwingingToolUp;
    public bool isSwingingToolDown;
    public bool isPickingRight;
    public bool isPickingLeft;
    public bool isPickingUp;
    public bool isPickingDown;
    public bool isCarrying;

    private ToolEffect toolEffect = ToolEffect.none;

    private Rigidbody2D rigidBody;


    private Direction playerDirection;

    private float movementSpeed;


    private bool playerInputisDisabled = false;

    public bool PlayerInputisDisabled { get => playerInputisDisabled; set => playerInputisDisabled = value; }

    public Camera maincam;
  protected  override void Awake()
    {
        base.Awake();

        rigidBody = GetComponent<Rigidbody2D>();
        maincam = Camera.main;

    }


    private void Update()
    {

        if (!playerInputisDisabled)
        {
            ResetAnimationTriggers();
            PlayerMovementInput();

            PlayerWalkInput();


            EventHandler.CallMovementEvent(xInput, yInput, isWalking, isRunning, isIdle, isCarrying, toolEffect,
    isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown,
    isLiftingToolRight, isLiftingToolLeft, isLiftingToolUp, isLiftingToolDown,
    isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
    isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
    false, false, false, false);
        }
       
    }


    private void FixedUpdate()
    {
        PlayerMoveMent();
    }

    private void PlayerMoveMent()
    {
        Vector2 move = new Vector2(xInput * movementSpeed * Time.deltaTime, yInput * movementSpeed * Time.deltaTime);

        rigidBody.MovePosition(rigidBody.position + move);
    }
    private void ResetAnimationTriggers()
    {
        isPickingRight = false;
        isPickingLeft = false;
        isPickingUp = false;
        isPickingDown = false;
        isUsingToolRight = false;
        isUsingToolLeft = false;
        isUsingToolUp = false;
        isUsingToolDown = false;
        isLiftingToolRight = false;
        isLiftingToolLeft = false;
        isLiftingToolUp = false;
        isLiftingToolDown = false;
        isSwingingToolRight = false;
        isSwingingToolLeft = false;
        isSwingingToolUp = false;
        isSwingingToolDown = false;
        toolEffect = ToolEffect.none;
    }


    private void PlayerMovementInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (yInput!=0 && xInput!=0)
        {
            xInput *= 0.71f;
            yInput *= 0.71f; ;
        }


        if (xInput!=0 || yInput!=0)
        {
            isRunning = true;
            isWalking = false;

            movementSpeed = Setting.runningSpeed;
            //...................

            if (xInput > 0)
            {
                playerDirection = Direction.right;
            }
            else if (xInput < 0)
            {
                playerDirection = Direction.left;
            }

            else if (yInput > 0)
            {
                playerDirection = Direction.up;
            }
            else if (yInput < 0)
            {
                playerDirection = Direction.down;
            }

        }
        else if (xInput == 0 || yInput == 0)
        {
            isWalking = false;
            isRunning = true;
        }


    }// End  PlayerMovementInput




   private void  PlayerWalkInput()
    {
        if (Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = false;
            isWalking = true;
           isIdle = false;
            movementSpeed = Setting.walkingSpeed;

        }
        else
        {
            isRunning = true;
            isWalking = false;
            isIdle =  false;
            movementSpeed = Setting.runningSpeed;
        }
    }




    public Vector3 GetPlayerViewPortPosition()
    {
        return maincam.WorldToViewportPoint(this.transform.position);
    }

    public void ResetMovement()
    {
        xInput = 0;
        yInput = 0;
        isRunning = false;
        isWalking = false;
        isIdle = true;
    }
    public void DisbalePlayerInputAndResetMovement()
    {
        DisbalePlayerInput();
        ResetMovement();
        EventHandler.CallMovementEvent(xInput, yInput, isWalking, isRunning, isIdle, isCarrying, toolEffect,
 isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown,
 isLiftingToolRight, isLiftingToolLeft, isLiftingToolUp, isLiftingToolDown,
 isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
 isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
 false, false, false, false);
    }

    public void DisbalePlayerInput()
    {
        playerInputisDisabled = true;
    }
    public void EnablePlayerInput()
    {
        playerInputisDisabled = false;
    }

}// class Ends 
