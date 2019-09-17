using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grabscripts : MonoBehaviour
{
    public Text ConfirmedGrabbedText;
    public Text GrabText;
    public GameObject MainPlayer;
    public GameObject Scripts;

    private bool canGrab;
    private bool scriptsTaken;
    // Start is called before the first frame update
    void Start()
    {
        ConfirmedGrabbedText.CrossFadeAlpha(0f, 0.00001f, false);
        GrabText.CrossFadeAlpha(0f, 0.00001f, false);
    }

    void OnTriggerStay(Collider mPlayer)
    {
        if (mPlayer.gameObject == MainPlayer)
        {
            if (!scriptsTaken)
                GrabText.CrossFadeAlpha(1f, 0.01f, false);

            if(scriptsTaken)
                ConfirmedGrabbedText.CrossFadeAlpha(1f, 0.01f, false);

            canGrab = true;
        }
    }

    void OnTriggerExit(Collider mPlayer)
    {
        if (mPlayer.gameObject == MainPlayer)
        {
            GrabText.CrossFadeAlpha(0f, 0.00001f, false);
            ConfirmedGrabbedText.CrossFadeAlpha(0f, 0.0001f, false);
            canGrab = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (canGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Scripts.GetComponent<Renderer>().enabled = false;
                Scripts.SetActive(false);
                scriptsTaken = true;
            }
        }
    }
}
