using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D[] cursorTextureArray;
    [SerializeField] private int frameCount;
    [SerializeField] private float frameRate;

    //[SerializeField] private List<CursorAnimation> cursorAnimationList;
    //private CursorAnimation cursorAnimation;
    private int currentCursorIndex;
    private float frameTimer;
    private Texture2D cursorTexture;

    public enum CursorType {
        pointerCursor,
        fingerCursor,
        pickaxeCursor,
        swordCursor,
        npcCursor
    }

    private void Start() {
        //cursorTexture = cursorTextureArray[0];
        //Cursor.SetCursor(cursorTexture, new Vector2(0, 0), CursorMode.Auto); 
        //SetActiveCursorType(CursorType.pointerCursor);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) {
            print(currentCursorIndex);
            currentCursorIndex++;
            currentCursorIndex = currentCursorIndex % cursorTextureArray.Length;
            cursorTexture = cursorTextureArray[currentCursorIndex];
            Cursor.SetCursor(cursorTexture, new Vector2(0, 0), CursorMode.Auto);
        }
    }

    //private void SetActiveCursorType(CursorType cursorType) {
        //SetActiveCursorTexture(GetCursorTexture(cursorType));
    }

    //private Texture2D GetCursorTexture(CursorType cursorType) {
        //foreach (Texture2D cursorTexture in cursorTextureArray) { 
                //if (cursorTexture.cursorTexture == cursorType) { 
                    //return cursorTexture; 
                //}
        //}
        //return null;
    //}

    //private void SetActiveCursorTexture(Texture2D cursorTexture) {
        //this.cursorTexture = cursorTexture;
        //currentCursorIndex = 0;
        //frameTimer = cursorTexture.frameRate;
        //frameCount = cursorTexture.textureArray.Length;
    //}

    //[System.Serializable]
    //public class CursorAnimation {

        //public CursorType cursorType;
        //public Texture2D[] textureArray;
        //public float frameRate;
        //public Vector2 offset;

    //}
//}