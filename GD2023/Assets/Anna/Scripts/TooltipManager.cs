using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class TooltipManager : MonoBehaviour
{
   
    public static  TooltipManager instance;
    public TextMeshProUGUI textComponent;

    public RectTransform rectTransform;
    private Transform ownerTransform;

    public GameObject interactiveObject;

    public Transform characterTransform; // Reference to the character's Transform.

    //public Vector3 offset = new Vector3(0f, 2f, 0f);
    //public Vector3 characterWorldPosition; // Reference to the character's position.
    //public Vector3 tooltipScreenPosition;

    public float interactDistanceThreshold = 1.0f; // The distance at which the tooltip appears.
    private bool isNearObject = false;

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
        
        
        
        position = Input.mousePosition;
        Ray ourRay = Camera.main.ScreenPointToRay(position);
        RaycastHit info;

        if (Physics.Raycast(ourRay, out info))
        {
            print("Hit Object Name: " + info.collider.gameObject.name);
            if (characterTransform == interactiveObject.transform)
            {
    
                float distance = Vector3.Distance(characterTransform.position, interactiveObject.transform.position); // Calculate the distance between the character and the interactive object.

                if (distance < interactDistanceThreshold)
                {
                    isNearObject = true;
                    print("You are near the object.");
                }
                else
                {
                    isNearObject = false;
                    print("You are not near the object.");
                }
            }
        }

        //try to display tooltip above the character
        //if (characterTransform)
        //{
           // characterWorldPosition = characterTransform.position; // Update the character's world position.

           // Vector3 targetWorldPosition = characterWorldPosition + offset; // Calculate the fixed world position of the tooltip relative to the character.

           // tooltipScreenPosition = Camera.main.WorldToScreenPoint(targetWorldPosition); // Convert the world position to screen coordinates.

           // transform.position = tooltipScreenPosition; // Set the tooltip's position in screen space.
       // }


        







        //transform.position = position;

        //check pivotx and pivoty of window and change position if it is close to the end of the screen.
        // float pivotX = position.x / Screen.width;
        //float pivotY = position.y / Screen.height;

        // rectTransform.pivot = new Vector3(pivotX, pivotY);

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
