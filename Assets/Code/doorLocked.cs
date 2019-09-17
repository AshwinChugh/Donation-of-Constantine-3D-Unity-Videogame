
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doorLocked : MonoBehaviour
{
    public GameObject mainPlayer;

    public Text text;

    void Start()
    {
        text.CrossFadeAlpha(0, 0.1f, false);
    }
        

    void OnTriggerEnter(Collider mPlayer)//show text when collision is detected
    {
        if(mPlayer.gameObject ==  mainPlayer)
        {
            text.CrossFadeAlpha(255, 1f, false);
            //Debug.Log("Cllision with mainplayer detected!");
        }
    }

    void OnTriggerExit(Collider mPlayer)//hide alert when collision is no longer there and the player has moved onto the ladder
    {
        if (mPlayer.gameObject == mainPlayer)
        {
            text.CrossFadeAlpha(0, 1f, false);
        }
    }
}
