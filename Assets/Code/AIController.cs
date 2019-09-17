using System.Collections.Generic;
using RPGCharacterAnims;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class AIController : SuperStateMachine
{
    public NavMeshAgent AIObject;
    public GameObject player;

    private RPGCharacterControllerFREE characterController;
    private RPGCharacterMovementControllerFREE characterMovementController;
    private List<int> attackList = new List<int>();
    private float elapsed;
    private int parseNum;
    private Vector3 distanceVector;

    void Start()
    {
        characterController = GetComponent<RPGCharacterControllerFREE>();
        characterMovementController = GetComponent<RPGCharacterMovementControllerFREE>();
        parseNum = 0;
        GenAttacks();
        distanceVector = new Vector3(0,0,2);
    }

    void GenAttacks()
    {
        attackList.Clear();
        var rnd = new Random();
        for (int i = 0; i < 4; i++)
        {
            var rndNum = rnd.Next(1, 4);
            attackList.Add(rndNum);
            Debug.Log("Random Num: " + rndNum);
        }
    }


    void FixedUpdate()
    {
        Vector3 positionVector3 = player.transform.position;
        float distance = Vector3.Distance(AIObject.transform.position, positionVector3);
        AIObject.SetDestination(positionVector3 - distanceVector);
        if (distance <= 3f)
        {
            AIObject.transform.LookAt(player.transform);
            elapsed += Time.deltaTime;
            if (elapsed >= 2)
            {
                elapsed = elapsed % 1f;
                AIFight();
            }
            
        }
    }

    void checkParseNum()
    {
        if (parseNum == 4)
        {
            parseNum = 0;
        }
    }

    void AIFight()
    {
        var intNum = attackList[parseNum];
        switch (intNum)
        {
            case 1:
                Debug.Log("attack 1");
                characterController.Attack(1);
                parseNum++;
                checkParseNum();
                intNum = attackList[parseNum];
                CombatHitController.GetHit();
                break;
            case 2:
                Debug.Log("attack 2");
                characterController.Attack(2);
                parseNum++;
                checkParseNum();
                intNum = attackList[parseNum];
                CombatHitController.GetHit();
                break;
            case 3:
                Debug.Log("Attack 3");
                characterController.AttackKick(1);
                checkParseNum();
                parseNum++;
                CombatHitController.GetHit();
                intNum = attackList[parseNum];
                break;
            case 4:
                Debug.Log("attack 4");
                characterController.AttackKick(2);
                checkParseNum();
                parseNum++;
                intNum = attackList[parseNum];
                CombatHitController.GetHit();
                break;
        }
    }

}
