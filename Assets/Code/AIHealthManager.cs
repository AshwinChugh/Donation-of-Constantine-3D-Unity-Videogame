using RPGCharacterAnims;
using UnityEngine;
using UnityEngine.AI;

public class AIHealthManager : MonoBehaviour
{
    public GameObject AIPlayer;
    [HideInInspector] public static bool AIDead;

    private static RPGCharacterControllerFREE characterController;
    private RPGCharacterMovementControllerFREE characterMovementController;
    private static float health;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<RPGCharacterControllerFREE>();
        characterMovementController = GetComponent<RPGCharacterMovementControllerFREE>();
        health = 50;
        AIDead = false;
    }

    public static void AIHit()
    {
        characterController.GetHit();
        health -= 10;
        if (health <= 0)
        {
            characterController.Death();
            AIDead = true;
        }
    }
}
