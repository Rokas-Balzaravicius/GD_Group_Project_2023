using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HarvestableItem;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D[] cursorTextureArray;
    [SerializeField] private int frameCount;
    [SerializeField] private float frameRate;

    private int currentCursorIndex;
    private float frameTimer;
    public string RaycastReturn;
    private Texture2D cursorType;

    Texture2D cursorTexture
    {
        get { return cursorType; }
        set {  cursorType = value;
            Cursor.SetCursor(cursorType, new Vector2(0, 0), CursorMode.Auto);
        }
    }
    private Vector2 mousePosition;


    public enum CursorType {
        pointerCursor,
        fingerCursor,
        pickaxeCursor,
        swordCursor,
        npcCursor
    }

    private void Start() 
    {
        cursorTexture = cursorTextureArray[0];
  
    }
    private void Update()
    {
        mousePosition = Input.mousePosition;

        RaycastHit hit;
        Ray ourRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ourRay, out hit))
        {
            HarvestableItem objectHit = hit.transform.GetComponent<HarvestableItem>();

            if (objectHit != null)
            {
                cursorTexture = cursorTextureArray[objectHit.cursorHoverId];
                if (Input.GetMouseButtonDown(0))
                {
                    //switch (currentState)
                    //{
                        //case ResourceState.BeingHarvested;
                    //}
                }
                else
                {
                    
                }
            }

            else
                cursorTexture = cursorTextureArray[0];
        }
    }

    internal bool isCurrentTexture(int v)
    {
        return cursorType == cursorTextureArray[v];
    }
}

