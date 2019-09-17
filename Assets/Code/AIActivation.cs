using UnityEngine;
using UnityEngine.UI;

public class AIActivation : MonoBehaviour
{
    public GameObject MainPlayer;
    public GameObject AIPlayer;
    public Text Timer;
    public Text EndGameTimerText;
    public Camera MainCamera;
    public GameObject GameOverPanel;
    public GameObject displayScript;
    public GameObject forgedScript;
    public Text WarningScriptsNotGrabbed;


    [HideInInspector]public static bool startTimer;


    private float timerInitial;

    // Start is called before the first frame update
    void Start()
    {
        Timer.CrossFadeAlpha(0f, 0.0001f, false);
        startTimer = false;
        timerInitial = 60f;
        AIPlayer.SetActive(false);
        WarningScriptsNotGrabbed.CrossFadeAlpha(0f, 0.00001f, false);
        EndGameTimerText.text = "You Died";
    }

    void OnTriggerEnter(Collider mPlayer)
    {
        if (mPlayer.gameObject == MainPlayer)
        {
            if (!(displayScript.activeSelf || forgedScript.activeSelf))//make sure the player has grabbed both scripts
            {
                startTimer = true;
                Timer.CrossFadeAlpha(1f, 0.5f, false);
                AIPlayer.SetActive(true);
                //add camera shake effect
            }
            else
            {
                WarningScriptsNotGrabbed.CrossFadeAlpha(1f, 0.01f, false);
                Invoke("warningTextOff", 5f);
            }
        }
    }

    void warningTextOff()
    {
        WarningScriptsNotGrabbed.CrossFadeAlpha(0f, 1f, false);
    }


    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            Timer.text = timerInitial.ToString("0");
            timerInitial -= Time.deltaTime;
        }
        if (timerInitial <= 0)
        {
            startTimer = false;
            EndGameTimerText.text = "Time Up! The Church got to the castle first";
            GameOverPanel.SetActive(true);
        }
    }
}
