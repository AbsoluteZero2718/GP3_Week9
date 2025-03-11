using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;


public class EnemyBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform PointA;
    public Transform PointB;
    public Transform playerPosition;
    public Transform currentTarget;
    public float chaseRadius;
    public bool isChasing = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent.speed = 0;
        StartPatrol();

    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition.position);
        if (distanceToPlayer <= chaseRadius)
        {
            isChasing = true;
            agent.speed = 5;
            currentTarget = playerPosition;
        }
        else
        {
            if (isChasing)
            {
                isChasing = false;
                agent.SetDestination(currentTarget.position);
            }
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                // switching targets

                currentTarget = (currentTarget == PointA) ? PointB : PointA;
                agent.SetDestination(currentTarget.position);
            }
        }
        
    }
    
    public async void StartPatrol()
    {
        await Task.Delay(5000);
        agent.speed = 3.5f;
        // making agent move to point a
        currentTarget = PointA;
        agent.SetDestination(currentTarget.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
