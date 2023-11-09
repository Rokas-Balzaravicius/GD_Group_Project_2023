using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class mouseInteractions : MonoBehaviour
{

    public GameObject MessageCloneTemplate;

    TextMeshProUGUI textComponent;
    Canvas ourCanvas;

    String tooltipText = "Hello World!";


    // Start is called before the first frame update
    void Start()
    {
        Canvas[] allCanvas = FindObjectsOfType<Canvas>();
        TextMeshProUGUI[] allTextComponents = FindObjectsOfType<TextMeshProUGUI>();


        foreach (Canvas c in allCanvas)
        {
            if (c.name == "Canvas1")
            {
                ourCanvas = c;
            }
        }
        foreach (TextMeshProUGUI t in allTextComponents)
        {
             if (t.name == "TooltipText1")
            {
                textComponent = t;
            }
        }
    }

    GameObject newMessageGO;
    // Update is called once per frame
    void Update()
    {

      
            if (Input.GetMouseButtonDown(0))
            {
                Ray ourRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit info;

            if (Physics.Raycast(ourRay, out info))
                {
                    newMessageGO = Instantiate(MessageCloneTemplate, ourCanvas.transform);
                    StartCoroutine(waiter(newMessageGO, info.transform, info.transform.name));


 

                }
            }



        }


    IEnumerator waiter(GameObject newMessageGO,  Transform parent, string message)
    {
        yield return new WaitForSeconds(1);
        newMessageGO.SetActive(true);
        TooltipManager newMessage = newMessageGO.GetComponent<TooltipManager>();
        newMessage.SetAndShowToolTip(message, parent);



    }
}
