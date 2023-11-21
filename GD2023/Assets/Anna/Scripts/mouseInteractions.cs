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
    GameObject newMessageGO;

    // Start is called before the first frame update
    void Start()
    {
        Canvas[] allCanvas = FindObjectsOfType<Canvas>();
        TextMeshProUGUI[] allTextComponents = FindObjectsOfType<TextMeshProUGUI>();


        foreach (Canvas c in allCanvas)
        {
            if (c.name == "Canvas")
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

    
    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ourRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit info;

            if (Physics.Raycast(ourRay, out info))
                {

                    HarvestableItem item = info.transform.GetComponent<HarvestableItem>();

                if (item != null)
                {
                    newMessageGO = Instantiate(MessageCloneTemplate, ourCanvas.transform);
                    StartCoroutine(waiter(newMessageGO, info.transform, item.toolTipDescription));
                }

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
