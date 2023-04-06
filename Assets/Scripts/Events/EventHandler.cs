using System;
using System.Collections.Generic;



public delegate void MovementDelgate(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying, ToolEffect toolEffect,
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
     bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
      bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown,
      bool idleUp, bool idleDown, bool idleLeft, bool idleRight);

public static class EventHandler

{

    public static event MovementDelgate MovementEvent;

    public static event Action<InventoryLocation, List<InventoryItem>> inventoryUpdatedEvent;


    public static void CallInventoryUpdatedEvent(InventoryLocation inventoryLocation, List<InventoryItem> inventoryList)
    {
        if (inventoryUpdatedEvent!=null)
        {
            inventoryUpdatedEvent(inventoryLocation, inventoryList);
        }
    }
    public static void CallMovementEvent(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying, ToolEffect toolEffect,
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
     bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
      bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown,
      bool idleUp, bool idleDown, bool idleLeft, bool idleRight)
    {
        if (MovementEvent!=null)
        {
            MovementEvent(inputX, inputY, isWalking, isRunning, isIdle, isCarrying, toolEffect,
     isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown,
     isLiftingToolRight, isLiftingToolLeft, isLiftingToolUp, isLiftingToolDown,
      isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
       isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
       idleUp, idleDown, idleLeft, idleRight);
        }
    }

}

