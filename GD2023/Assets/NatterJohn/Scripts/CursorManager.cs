using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D[] cursorTextureArray;
    [SerializeField] private int frameCount;
    [SerializeField] private float frameRate;

    private int currentCursorIndex;
    private float frameTimer;
    public string RaycastReturn;
    private Texture2D cursorTexture;
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
        Cursor.SetCursor(cursorTexture, new Vector2(0, 0), CursorMode.Auto);
    }
    private void Update()
    {
        mousePosition = Input.mousePosition;

        RaycastHit hit;
        Ray ourRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ourRay, out hit))
        {
            if (hit.collider != null)
            {
                RaycastReturn = hit.collider.gameObject.name;
                if (RaycastReturn == "Rock_04" || RaycastReturn == "Rock_04(Clone)")
                {
                    print(RaycastReturn);
                    cursorTexture = cursorTextureArray[2];
                    Cursor.SetCursor(cursorTexture, new Vector2(0, 0), CursorMode.Auto);
                }
                else if (RaycastReturn == "free_male_1")
                {
                    print(RaycastReturn);
                    cursorTexture = cursorTextureArray[4];
                    Cursor.SetCursor(cursorTexture, new Vector2(0, 0), CursorMode.Auto);
                }
                else
                {
                    cursorTexture = cursorTextureArray[0];
                    Cursor.SetCursor(cursorTexture, new Vector2(0, 0), CursorMode.Auto);
                }
            }
        }
    

        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            print(currentCursorIndex);
              currentCursorIndex++;
            currentCursorIndex = currentCursorIndex % cursorTextureArray.Length;
            cursorTexture = cursorTextureArray[currentCursorIndex];
            Cursor.SetCursor(cursorTexture, new Vector2(0, 0), CursorMode.Auto);
        }
    }

    }

