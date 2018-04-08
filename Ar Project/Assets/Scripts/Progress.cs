using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Progress : MonoBehaviour {

    private int Action = 1;

    public GameObject Cover;
    public GameObject NextButton;

    private bool change = false;

    public GameObject Scene;
    public GameObject Background;

    public GameObject Scene2;
    public GameObject Background2;

    public GameObject Scene3;
    public GameObject Background3;

    public GameObject Scene4;
    public GameObject Background4;

    public GameObject Scene5;
    public GameObject Background5;

    public GameObject galagaPlayer;
    public GameObject GalagaUp;
    public GameObject GalagaDown;
    private bool galaga = false;
    private bool galagaUp = false;
    private bool galagaDown = false;
    private bool galagaHit = false;

    public Animator RocketBeaver;
    public Animator Mario;
    public Animator Deer;
    public Animator Frogger;
    public Animator Talk;
    public Animator DeerTalk;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                var Name = hit.transform.name;
                if (Name == "NextButton")
                {
                    Next();
                }
                else if (Name == "Cover Art")
                {
                    change = true;
                    NextButton.SetActive(true);
                    Scene2.SetActive(true);
                    Background2.SetActive(true);
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
            }
            else
            {
                Cover.SetActive(false);
                change = false;
            }
        }
        if (galaga)
        {
            GalagaDown.SetActive(true);
            GalagaUp.SetActive(true);
            //spawn enemies
            galagaDown = false;
            galagaUp = false;
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    var Name = hit.transform.name;
                    if (Name == "galagaUp")
                    {
                        galagaUp = true;
                    }
                    if (Name == "galagaDown")
                    {
                        galagaDown = true;
                    }
                }
            }
            if (galagaUp)
            {
                galagaPlayer.transform.Translate(new Vector3(0, 0, 0.005f));
            }
            else if (galagaDown)
            {
                galagaPlayer.transform.Translate(new Vector3(0, 0, -0.005f));
            }
            if (galagaHit)
            {
                galaga = false;
                NextButton.SetActive(true);
                GalagaDown.SetActive(false);
                GalagaUp.SetActive(false);
            }
        }
    }

    void Next()
    {
        switch (Action)
        {
            /*case 0:
                Scene2.SetActive(true);
                Background2.SetActive(true);
                break;
            case 1://change to galaga
                Scene.SetActive(false);
                Background.SetActive(false);
                Scene2.SetActive(true);
                Background2.SetActive(true);
                //galaga = true;
                Debug.Log("1");
                break;*/
            case 1:
                Talk.SetTrigger("Next");
                break;
            case 2:
                Talk.SetTrigger("Next");
                break;
            case 3:
                Talk.SetTrigger("Next");
                break;
            case 4:
                Talk.SetTrigger("Next");
                RocketBeaver.SetTrigger("Next");
                break;
            case 5:
                Talk.SetTrigger("Next");
                break;
            case 6:
                Talk.SetTrigger("Next");
                break;
            case 7:
                Talk.SetTrigger("Next");
                break;
            case 8:
                Talk.SetTrigger("Next");
                RocketBeaver.SetTrigger("Next");
                break;
            case 9:
                RocketBeaver.SetTrigger("Next");
                break;
            case 10:
                Talk.SetTrigger("Next");
                break;
            case 11:
                Talk.SetTrigger("Next");
                RocketBeaver.SetTrigger("Next");
                break;
            case 12://change to mario
                Scene2.SetActive(false);
                Background2.SetActive(false);
                Scene3.SetActive(true);
                Background3.SetActive(true);
                Debug.Log("2");
                break;
            case 13:
                Mario.SetTrigger("Next");
                Deer.SetTrigger("Next");
                break;
            case 14:
                DeerTalk.SetTrigger("Next");
                break;
            case 15:
                DeerTalk.SetTrigger("Next");
                break;
            case 16:
                DeerTalk.SetTrigger("Next");
                break;
            case 17:
                DeerTalk.SetTrigger("Next");
                break;
            case 18:
                Mario.SetTrigger("Next");
                break;
            case 19://change to frogger
                Scene3.SetActive(false);
                Background3.SetActive(false);
                Scene4.SetActive(true);
                Background4.SetActive(true);
                Debug.Log("3");
                break;
            case 20:
                Frogger.SetTrigger("Next");
                break;
                /*case 3://legend of zelda
                    Scene4.SetActive(false);
                    Background4.SetActive(false);
                    Scene5.SetActive(true);
                    Background5.SetActive(true);
                    Debug.Log("4");
                    break;
                case 4://go to end?
                    Scene5.SetActive(false);
                    Background5.SetActive(false);
                    //end?
                    Debug.Log("5");
                    break;*/
        }
        Action += 1;
    }

}
