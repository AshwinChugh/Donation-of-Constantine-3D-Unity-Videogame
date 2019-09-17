using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{
    public Text ChurchObjective;
    public Text CastleObjective;
    public GameObject DisplayScript;
    public GameObject ForgedScript;

    private bool nextObj;

    // Start is called before the first frame update
    void Start()
    {
        ChurchObjective.CrossFadeAlpha(1f, 2f, false);
        CastleObjective.CrossFadeAlpha(0f, 0.000001f, false);
        nextObj = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!(DisplayScript.activeSelf || ForgedScript.activeSelf))
        {
            if (!nextObj)//only change objective when needed
            {
                ChurchObjective.CrossFadeAlpha(0f, 1f, false);
                CastleObjective.CrossFadeAlpha(1f, 1f, false);
                nextObj = true;
            }
        }
    }
}
