using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

public class EnemyPatrolState : StateMachineBehaviour
{
    EnemyBehaviour enemybehavior;
    NavMeshAgent agent;
    Transform pointA, pointB, player, currentTarget;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemybehavior = animator.GetComponent<EnemyBehaviour>();
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 3.5f;
        pointA = enemybehavior.PointA;
        pointB = enemybehavior.PointB;
        player = enemybehavior.playerPosition;

        agent.SetDestination(pointA.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public async void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemybehavior.distanceToPlayer <= enemybehavior.chaseRadius)
        {
            animator.SetBool("isChasing", true);
            animator.SetBool("isPatrol", false);
        }

        else
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                // switching targets

                currentTarget = (currentTarget == enemybehavior.PointA) ? enemybehavior.PointB : enemybehavior.PointA;
                enemybehavior.currentTarget = currentTarget;
                animator.speed = 0;
                await Task.Delay(1000);
                goToDestination();
               
            }
        }

        if (currentTarget == null)
            return;
        Vector3 direction = currentTarget.transform.position;

        if (agent.velocity.magnitude > 0.01f) // check if AI is static
        {
            Quaternion lookRotate = Quaternion.LookRotation(direction);
            enemybehavior.transform.rotation = lookRotate;
        }
        void goToDestination()
        {
            animator.speed = 1;
            agent.SetDestination(currentTarget.position);
        }
    }
 }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
//}

