using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    private string message;
    Transform ownerTransform;

    internal void assignMessage(string newMessage)
    {
       message = newMessage;
    }

    internal void assignMessage(string mesasge, Transform transformOfOwner)
    {
       ownerTransform = transformOfOwner;
       TooltipManager.instance.SetAndShowToolTip(message,ownerTransform);
    }

    private void OnMouseEnter()
    { 
        TooltipManager.instance.SetAndShowToolTip(message);
    }

    private void OnMouseExit()
    {
      //  TooltipManager.instance.HideTooltip();
    }
}
