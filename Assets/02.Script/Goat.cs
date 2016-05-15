using UnityEngine;
using System.Collections;
using GoatStates;

public class Goat : MonoBehaviour
{

    public Vector3 firstLocation;
    public Vector3 secondLocation;
    public CPlant target;
    public Animator anim;
    public float speed;
    public bool EatComplete = false;
    private StateMachine<Goat> stateMachine;
    
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        stateMachine = new StateMachine<Goat>();
        Patrol patrol = new Patrol();
        stateMachine.Init(this, patrol);
    }
    void Update()
    {
        Action();
    }
    void Action()
    {
        stateMachine.Action();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Obstacle"))
        {
            Debug.Log("장애물");
            Patrol pat = new Patrol();
            Vector3 tempVector = secondLocation;
            secondLocation = firstLocation;
            firstLocation = tempVector;
            stateMachine.ChangeState(pat);
        }

        if (!stateMachine.Get_CurrentState().GetStateName().Equals("Patrol")) return;
        
        if (other.transform.tag.Equals("Level1"))
        {
            FindPlant find = new FindPlant();
            target = other.gameObject.GetComponent<CPlant>();
            stateMachine.ChangeState(find);
        }
        if (other.transform.tag.Equals("Level2"))
        {
            FindPlant find = new FindPlant();
            target = other.gameObject.GetComponent<CPlant>();
            stateMachine.ChangeState(find);
        }
        if (other.transform.tag.Equals("Level3"))
        {
            FindPlant find = new FindPlant();
            target = other.gameObject.GetComponent<CPlant>();
            stateMachine.ChangeState(find);
        }
        if (other.transform.tag.Equals("Level4"))
        {
            FindPlant find = new FindPlant();
            target = other.gameObject.GetComponent<CPlant>();
            stateMachine.ChangeState(find);
        }
    }



    public void ChangeState(State<Goat> state) { stateMachine.ChangeState(state); }
}