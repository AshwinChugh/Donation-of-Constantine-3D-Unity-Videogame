using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCompleteTrigger : MonoBehaviour
{
    public GameObject MainPlayer;
    public Text NoScriptsGrabbedWarning;
    public GameObject ColliderObject;

    void Start()
    {
        NoScriptsGrabbedWarning.CrossFadeAlpha(0f, 0.000001f, false);
    }

    void OnTriggerEnter(Collider mPlayer)
    {
        if (mPlayer.gameObject == MainPlayer)
        {
            if (AIActivation.startTimer)
            {
                ColliderObject.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//load the end game scene 
            }
            else
            {
                NoScriptsGrabbedWarning.CrossFadeAlpha(1f, 0.0000001f, false);
            }
        }
    }

    void OnTriggerExit()
    {
        NoScriptsGrabbedWarning.CrossFadeAlpha(0f, 0.0000001f, false);
    }
}
