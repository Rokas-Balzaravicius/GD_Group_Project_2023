using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NPCAI : MonoBehaviour
{
    CharacterMovementScript lockOnTo;
    float maxMeleeDistance = 2f;
    enum NPCStates { Patrol, Chase, Attack}
    enum NPCTransitions { None, See_Target, Within_Melee_Range }

    NPCTransitions NPCWorldChange = NPCTransitions.None;

    NPCStates isCurrently = NPCStates.Patrol;
    private float breakAwayDistance = 7;
    private float chaseSpeed = 2f;
    private float timer;
    private float patrolChangeDiectionTime = 5;
    private float patrolSpeed = 1;
    private float ATTACKCOOLDOWN = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   // Sensing Phase
        NPCWorldChange = senseNPCWorldChange();

        #region Thinking Phase

        // Thinking Phase;
        switch (isCurrently)
        {
            case NPCStates.Patrol:
                switch (NPCWorldChange)
                {
                    case NPCTransitions.See_Target:

                        isCurrently = NPCStates.Chase;
                        break;

                    case NPCTransitions.Within_Melee_Range:
                        isCurrently = NPCStates.Attack;
                        break;

                }

                break;


            case NPCStates.Chase:
                {
                    switch (NPCWorldChange)
                    {
                        case NPCTransitions.See_Target:

                            isCurrently = NPCStates.Chase;
                            break;

                        case NPCTransitions.Within_Melee_Range:
                            isCurrently = NPCStates.Attack;
                            break;

                        case NPCTransitions.None:
                            isCurrently = NPCStates.Patrol;
                            break;

                    }
                }

                break;

            case NPCStates.Attack:

                switch (NPCWorldChange)
                {
                    case NPCTransitions.See_Target:

                        isCurrently = NPCStates.Chase;
                        break;

                    case NPCTransitions.Within_Melee_Range:
                        isCurrently = NPCStates.Attack;
                        break;

                    case NPCTransitions.None:
                        isCurrently = NPCStates.Patrol;
                        break;

                }


                break;

        } 
        #endregion

// Action Phase

        switch(isCurrently)
        {
            case NPCStates.Chase:
                transform.LookAt(lockOnTo.transform.position);
                transform.position += chaseSpeed * transform.forward * Time.deltaTime;
                // Animation for chase!!!!
                break;

            case NPCStates.Attack:
                // damage ed periodically
                timer -= Time.deltaTime;

                if (timer < 0)
                {
                    print("snake Attack");
                    lockOnTo.takeDamage(10);
                    timer = ATTACKCOOLDOWN;
                }

                    // Animation for Attack
                    break;

            case NPCStates.Patrol:

                timer -= Time.deltaTime;

                if (timer <0)
                {
                   transform.Rotate(Vector3.up,
                       UnityEngine.Random.Range(0f, 360f));
                    timer = patrolChangeDiectionTime;
                }

                transform.position += 
                    patrolSpeed * transform.forward * Time.deltaTime;


                break;
        }


    }

    private NPCTransitions senseNPCWorldChange()
    {
        if (lockOnTo)
        {
            if (Vector3.Distance(transform.position, lockOnTo.transform.position) < maxMeleeDistance)
            {
                return NPCTransitions.Within_Melee_Range;
            }

            if (Vector3.Distance(transform.position, lockOnTo.transform.position) > breakAwayDistance)
            {
                lockOnTo = null;
                return NPCTransitions.None;


            }

            return NPCTransitions.See_Target;

        }
        Collider[] allThingsInFront =

            Physics.OverlapSphere(
                transform.position + 4.5f * transform.forward,
                            5);

        foreach (Collider c in allThingsInFront)
        {
         
            if (c.TryGetComponent<CharacterMovementScript>(out lockOnTo))
            {
                if (Vector3.Distance(transform.position,
                    c.transform.forward) < maxMeleeDistance)

                    return NPCTransitions.Within_Melee_Range;
                else
                    return NPCTransitions.See_Target;
            }



        }

        return NPCTransitions.None;
    }


}

