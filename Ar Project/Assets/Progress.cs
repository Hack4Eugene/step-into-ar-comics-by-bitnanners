using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Progress : MonoBehaviour {

    private int Action = 0;

    public GameObject Cover;

    private bool change = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.name == "NextButton")
                {
                    Next();
                }
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
        }
        if (change)
        {
            if (Cover.GetComponent<Renderer>().material.color.a > 0)
            {
                var renderer = Cover.GetComponent<Renderer>();
                Color tempColor = renderer.material.color;
                tempColor.a -= 0.01f;
                renderer.material.color = tempColor;
            } else
            {
                change = false;
            }
        }
    }

    void Next()
    {
        switch (Action)
        {
            case 0:
                Debug.Log("Good");
                Change();
                break;
            case 1:
                Debug.Log("Good1");
                break;
        }
        Action += 1;
    }

    void Change()
    {
        change = true;
    }

}
