using RPGCharacterAnims;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;
using UnityEngine.UI;

public class CombatHitController : MonoBehaviour
{
    public GameObject GameOverPanel;
    public Text HealthText;
    public GameObject MainPlayer;
    public GameObject AIPlayer;

    [HideInInspector]public static RPGCharacterControllerFREE characterController;
    private RPGCharacterMovementControllerFREE characterMovementController;
    private static int Health;
    private Random rnd = new Random();
    private float distance;
    private float elapsed;
//    private bool AIDead;
//    private int AIhealth;

    void Start()
    {
        characterController = GetComponent<RPGCharacterControllerFREE>();
        characterMovementController = GetComponent<RPGCharacterMovementControllerFREE>();
        GameOverPanel.SetActive(false);
        Health = 100;
    }

    void FixedUpdate()
    {
        Vector3 MPPosition = MainPlayer.transform.position;
        Vector3 AIPosition = AIPlayer.transform.position;
        distance = Vector3.Distance(MPPosition, AIPosition);

        HealthText.text = Health.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            MainPlayer.transform.LookAt(AIPlayer.transform);
            var rndNum = rnd.Next(1, 2);
            characterController.Attack(rndNum);
            if (distance <= 3f)
            {
                AIHealthManager.AIHit();
                if (AIHealthManager.AIDead)
                {
                    AIPlayer.GetComponent<NavMeshAgent>().enabled = false;
                    AIPlayer.GetComponent<AIController>().enabled = false;
                }
            }

            Debug.Log("Fist Punch!");
        }

        if (Input.GetMouseButtonDown(1))
        {
            MainPlayer.transform.LookAt(AIPlayer.transform);
            var rndNum = rnd.Next(1, 2);
            characterController.AttackKick(rndNum);
            if (distance <= 3f)
            {
                elapsed += Time.deltaTime;

                AIHealthManager.AIHit();
                if (AIHealthManager.AIDead)
                {
                    AIPlayer.GetComponent<AIController>().enabled = false;
                    AIPlayer.GetComponent<NavMeshAgent>().enabled = false;
                }
            }

            Debug.Log("Kick attack!");
        }
        if (Health <= 0)
            GameOverPanel.SetActive(true);
    }

    public static void GetHit()
    {
        characterController.GetHit();
        Health -= 10;
        if (Health <= 0)
            characterController.Death();
    }

    void loadGameOver()
    {
        GameOverPanel.SetActive(true);
    }

}
