using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbScript : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject vButton;
    public Animator Model;

    public bool rotate = false;

	// Use this for initialization
	void Start () {
        //vButton = GameObject.Find("actionButton");
        vButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if(hit.transform.name == "Plane")
                {
                    Rotate();
                }
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
        }
    }

    void Rotate()
    {
        rotate = !rotate;
        Model.enabled = rotate;
    }
	
	public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        //Model.enabled = true;
        Debug.Log("Button Down");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
       // Model.enabled = false;
        Debug.Log("Button Up");
    }
}
