using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEditor.VersionControl;

public class TooltipManager : MonoBehaviour
{
   
    public static  TooltipManager instance;
    TextMeshProUGUI textComponent;

    public RectTransform rectTransform;
    private Transform ownerTransform;

    public GameObject interactiveObject;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        textComponent = GetComponentInChildren<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     
        if (ownerTransform)
        {
            Vector2 position, canvasPos;
           // print("World Position " + ownerTransform.position.ToString());
            position = Camera.main.WorldToScreenPoint(ownerTransform.position + Vector3.up);
           // print("Screen Position " + position.ToString());
            Canvas can  = transform.parent.GetComponent<Canvas>();
            RectTransform rect = can.GetComponent<RectTransform>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, position, null, out canvasPos);

            rectTransform.position = position;

        }
    }


    internal void SetAndShowToolTip(string message, Transform transformOfOwner)
    {
        ownerTransform = transformOfOwner;
        textComponent.text = message;
    }
}
