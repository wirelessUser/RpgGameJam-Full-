using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimationParameterControl : MonoBehaviour
{

    public Animator animator;
    public void AnimationEventPlayFootstepSound()
    {


       
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EventHandler.MovementEvent += SetAnimationParameters;
    }
     private void OnDisable()
     {
       EventHandler.MovementEvent -= SetAnimationParameters;
    }

        public void SetAnimationParameters(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying, ToolEffect toolEffect,
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
    bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
    bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown,
    bool idleUp, bool idleDown, bool idleLeft, bool idleRight)
    {
        animator.SetFloat(Setting.xInput, inputX);
        animator.SetFloat(Setting.yInput, inputY);
        animator.SetBool(Setting.isWalking, isWalking);
        animator.SetBool(Setting.isRunning, isRunning);

        animator.SetInteger(Setting.toolEffect, (int)toolEffect);

        if (isUsingToolRight)
            animator.SetTrigger(Setting.isUsingToolRight);
        if (isUsingToolLeft)
            animator.SetTrigger(Setting.isUsingToolLeft);
        if (isUsingToolUp)
            animator.SetTrigger(Setting.isUsingToolUp);
        if (isUsingToolDown)
            animator.SetTrigger(Setting.isUsingToolDown);

        if (isLiftingToolRight)
            animator.SetTrigger(Setting.isLiftingToolRight);
        if (isLiftingToolLeft)
            animator.SetTrigger(Setting.isLiftingToolLeft);
        if (isLiftingToolUp)
            animator.SetTrigger(Setting.isLiftingToolUp);
        if (isLiftingToolDown)
            animator.SetTrigger(Setting.isLiftingToolDown);

        if (isSwingingToolRight)
            animator.SetTrigger(Setting.isSwingingToolRight);
        if (isSwingingToolLeft)
            animator.SetTrigger(Setting.isSwingingToolLeft);
        if (isSwingingToolUp)
            animator.SetTrigger(Setting.isSwingingToolUp);
        if (isSwingingToolDown)
            animator.SetTrigger(Setting.isSwingingToolDown);

        if (isPickingRight)
            animator.SetTrigger(Setting.isPickingRight);
        if (isPickingLeft)
            animator.SetTrigger(Setting.isPickingLeft);
        if (isPickingUp)
            animator.SetTrigger(Setting.isPickingUp);
        if (isPickingDown)
            animator.SetTrigger(Setting.isPickingDown);

        if (idleUp)
            animator.SetTrigger(Setting.idleUp);
        if (idleDown)
            animator.SetTrigger(Setting.idleDown);
        if (idleLeft)
            animator.SetTrigger(Setting.idleLeft);
        if (idleRight)
            animator.SetTrigger(Setting.idleRight);
    }

    public void AnimationEventsPlayFootStepSound()
    {

    }
}
