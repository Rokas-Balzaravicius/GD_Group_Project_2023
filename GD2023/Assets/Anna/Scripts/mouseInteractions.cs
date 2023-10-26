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

        Ray ourMouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit info;



        if (Physics.Raycast(ourMouseRay, out info))
        {
            print(info.collider.name);
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            newMessageGO = Instantiate(MessageCloneTemplate, ourCanvas.transform);
            StartCoroutine( waiter(newMessageGO));

            TextMeshProUGUI textComponent = newMessageGO.GetComponentInChildren<TextMeshProUGUI>();

            if (textComponent != null)
            {
                textComponent.text = tooltipText;
                textComponent.color = Color.black;
            }
            // print("salfjhsaofh");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            newMessageGO.SetActive(true);

        }
    }

    IEnumerator waiter(GameObject newMessageGO)
    {
        yield return new WaitForSeconds(1);
        newMessageGO.SetActive(true);


    }
}
