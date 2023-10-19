using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class TooltipManager : MonoBehaviour
{
   
    public static TooltipManager instance;
    public TextMeshProUGUI textComponent;

    public RectTransform rectTransform;
    private Transform ownerTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
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
            print("World Position " +  ownerTransform.position.ToString());
            position = Camera.main.WorldToScreenPoint(ownerTransform.position);
            print("Screen Position " + position.ToString());

        }
        else
            position = Input.mousePosition;
            transform.position = position;

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        rectTransform.pivot = new Vector3(pivotX, pivotY);
        
    }

    public void SetAndShowToolTip(string message)
    {
        gameObject.SetActive(true);
        textComponent.text = message;
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
        textComponent.text = string.Empty;
    }

    internal void SetAndShowToolTip(string message, Transform transformOfOwner)
    {
        ownerTransform = transformOfOwner;
    }
}
