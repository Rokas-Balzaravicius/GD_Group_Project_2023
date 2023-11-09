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

    
        //if (instance != null && instance != this)
        //{
        //    Destroy(this.gameObject);
        //}
        //else
        //{
        //    instance = this;
        //}
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
        Vector2 position;
        if (ownerTransform)
        {
            print("World Position " + ownerTransform.position.ToString());
            position = Camera.main.WorldToScreenPoint(ownerTransform.position);
            print("Screen Position " + position.ToString());
            rectTransform.position = position;

        }
    }


    internal void SetAndShowToolTip(string message, Transform transformOfOwner)
    {
        ownerTransform = transformOfOwner;
        textComponent.text = message;
    }
}
