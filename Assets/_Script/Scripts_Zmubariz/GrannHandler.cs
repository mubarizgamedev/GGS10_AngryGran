using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using System.Collections;

public class GrannHandler : MonoBehaviour
{
    NavMeshAgent agent;


    [Space(5f)]
    [Header("Wandering")]
    List<Vector3> wayPoints;
    bool canWander;
    bool isWaiting;
    int currentWayPointIndex;
    public float distBeforeWaypoint;
    public float waitAtWayPoint;
    public Vector3 currentDestination;
    [SerializeField] private Transform currentWaypointTransform;
    [SerializeField] Transform[] firstFloorWayPoints;
    [SerializeField] Transform[] secondFloorWayPoints;



    [Space(5f)]
    [Header("Wandering")]
    public float stopDistanceBeforeCat;


    [Space(5f)]
    [Header("Animations")]
    public Animator grannyAnimator;
    public RuntimeAnimatorController grannyWanderingAnimator;


    [Space(5f)]
    [Header("State")]
    public GrannState grannState;


    [Space(5f)]
    [Header("Chase and Attack")]
    bool isChasingCat;
    bool canAttackCat;
    float chaseTimer;
    public float maxTimeGrannyChaseCat = 15f;
    public float detectionRadius;

    [Space(5f)]
    [Header("CatTransform")]
    public Transform catTransform;
    public enum GrannState
    {
        Wandering,
        StartChasing,
        Chasing,
        Attack,
        ReturnWander
    }


    #region EVENTS



    #endregion


    #region UNITY EVENTS
    private void Awake()
    {

    }
    private void Start()
    {
        //Initializing and Getting Components
        wayPoints = new List<Vector3>();
        agent = GetComponent<NavMeshAgent>();
        AddFirstFloorWayPoints();

        canWander = true;
        ChangeState(GrannState.Wandering);

        //Events Subscribing
        PickableObject.OnObjHitGranny += TriggerAngerGranny;
    }

    private void TriggerAngerGranny()
    {
        Debug.Log("Object hitted granny");
        ChangeState(GrannState.StartChasing);
    }

    private void OnDestroy()
    {

    }
    private void OnEnable()
    {

    }
    private void Update()
    {
        States();
    }

    #endregion
    public void ChangeState(GrannState granState)
    {
        grannState = granState;
    }

    public void States()
    {
        switch (grannState)
        {
            case GrannState.Wandering:
                //Wandering
                Wandering();
                break;
            case GrannState.StartChasing:
                //StartChasing
                StartCoroutine(StartChasingCat());
                break;
            case GrannState.Chasing:
                //Chasing
                ChaseCat();
                break;
            case GrannState.Attack:
                //Attack
                break;
            case GrannState.ReturnWander:
                //Return
                break;
            default:
                break;
        }
    }
    IEnumerator StartChasingCat()
    {
        SFX_Manager.PlaySound(SFX_Manager.Instance.angryTalkGranny);
        Debug.Log("sound times");
        SFX_Manager.PlaySound(SFX_Manager.Instance.OnDangerSounds, 0.5f);
        chaseTimer = 0f;
        isChasingCat = true;
        yield return new WaitForSeconds(3f);
        ChangeState(GrannState.Chasing);
    }

    void ChaseCat()
    {
        if (!isChasingCat) return;

        agent.SetDestination(catTransform.position);


        chaseTimer += Time.deltaTime;

        float distanceToCat = Vector3.Distance(transform.position, catTransform.position);

        if (distanceToCat <= stopDistanceBeforeCat)
        {
            canAttackCat = true;
            AttackCat();
        }
        else if (chaseTimer >= maxTimeGrannyChaseCat)
        {
            ResetState();
            ChangeState(GrannState.Wandering);
        }
    }

    void AttackCat()
    {

        isChasingCat = false;
        agent.isStopped = true;
        //OnAttackStart?.Invoke();
        //bodyRotationConstraint.constraintActive = true;
        //bodyRotationConstraint.weight = maxBodyConstraintToCat;


        if (canAttackCat)
        {
            if (IsCatInDetectionRadius())
            {
                if (AdmobAdsManager.Instance)
                {
                    if (AdmobAdsManager.Instance.Check_Firebase && Application.internetReachability != NetworkReachability.NotReachable)
                    {
                        //Mission fail event
                    }
                }

            }
        }
    }

    private bool IsCatInDetectionRadius()
    {
        return Vector3.Distance(transform.position, catTransform.position) <= detectionRadius;
    }

    public void ChangeWanderingPoints()
    {

    }

    public void AddFirstFloorWayPoints()
    {
        foreach (var item in firstFloorWayPoints)
        {
            wayPoints.Add(item.position);
        }
    }

    void Wandering()
    {
        if (canWander && !isWaiting)
        {
            if (!agent.pathPending && agent.remainingDistance <= distBeforeWaypoint)
            {
                //MoveToNextWaypoint();

                StartCoroutine(MoveToNextWaypointWithDelay());
            }
        }
    }

    IEnumerator MoveToNextWaypointWithDelay()
    {
        isWaiting = true; // Block further movement until done
        yield return new WaitForSeconds(waitAtWayPoint);
        MoveToNextWaypoint();
        isWaiting = false;
    }
    void MoveToNextWaypoint()
    {
        if (wayPoints.Count == 0)
        {
            Debug.LogError("No waypoints assigned to the granny");
            return;
        }

        currentWayPointIndex = Random.Range(0, wayPoints.Count);

        // Find the original Transform (for inspector)
        currentDestination = wayPoints[currentWayPointIndex];
        currentWaypointTransform = FindOriginalTransform(currentDestination); // <-- helper method

        agent.SetDestination(currentDestination);
    }

    Transform FindOriginalTransform(Vector3 pos)
    {
        foreach (var t in firstFloorWayPoints)
            if (t.position == pos)
                return t;

        foreach (var t in secondFloorWayPoints)
            if (t.position == pos)
                return t;

        return null;
    }
    void ResetState()
    {

    }

}
