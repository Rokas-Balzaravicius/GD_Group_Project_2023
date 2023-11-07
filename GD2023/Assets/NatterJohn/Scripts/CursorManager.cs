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

    Texture2D CursorTexture
    {
        get { return cursorTexture; }
        set {  cursorTexture = value;
            Cursor.SetCursor(cursorTexture, new Vector2(0, 0), CursorMode.Auto);
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
        CursorTexture = cursorTextureArray[0];
  
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
                RaycastReturn = hit.collider.name;
                if (RaycastReturn == "Rock_04" || RaycastReturn == "Rock_04(Clone)")
                {
                    print(RaycastReturn);
                    CursorTexture = cursorTextureArray[2];

                }
                else if (RaycastReturn == "free_male_1")
                {
                    print(RaycastReturn);
                    CursorTexture = cursorTextureArray[4];
  
                }
                else if (RaycastReturn == "Taipan")
                {
                    print(RaycastReturn);
                    CursorTexture = cursorTextureArray[3];

                }
                else if (RaycastReturn == "pear")
                {
                    print(RaycastReturn);
                    CursorTexture = cursorTextureArray[1];

                }
                else
                {
                    CursorTexture = cursorTextureArray[0];
                }
    
            }
        }
        else {
            CursorTexture = cursorTextureArray[0];
       
        }
    }

    }

