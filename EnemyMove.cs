using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;

    [Header("Movement")]
    public float speed = 2f;

    [Header("Detection")]
    public float chaseRange = 5f;

    [Header("Patrol")]
    public Transform[] patrolPoints;

    private int currentPoint;

    [Header("Search")]
    public float searchTime = 3f;

    private float searchTimer;
    private Vector2 lastPlayerPos;

    private enum State
    {
        Patrol,
        Chase,
        Search
    }

    private State currentState;

    void Start()
    {
        currentState = State.Patrol;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        switch (currentState)
        {
            case State.Patrol:

                Patrol();

                if (distance < chaseRange)
                {
                    currentState = State.Chase;
                }

                break;

            case State.Chase:

                Chase();

                if (distance > chaseRange)
                {
                    lastPlayerPos = player.position;

                    currentState = State.Search;

                    searchTimer = searchTime;
                }

                break;

            case State.Search:

                Search();

                if (distance < chaseRange)
                {
                    currentState = State.Chase;
                }

                break;
        }
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0)
            return;

        Transform target = patrolPoints[currentPoint];

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            currentPoint++;

            if (currentPoint >= patrolPoints.Length)
            {
                currentPoint = 0;
            }
        }
    }

    void Chase()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }

    void Search()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            lastPlayerPos,
            speed * Time.deltaTime
        );

        searchTimer -= Time.deltaTime;

        if (searchTimer <= 0)
        {
            currentState = State.Patrol;
        }
    }
}