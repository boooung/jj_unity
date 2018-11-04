using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
	IDLE = 0,
	RUN,
	CHASE,
	ATTACK
}

public class FSMManager : MonoBehaviour {

	public PlayerState currentState;
	public PlayerState startState;
	public Transform marker;
    public Transform target;
    public Animation anim;
    public CharacterStat stat;
    public CharacterController cc;
    public int layerMask;

  

	Dictionary<PlayerState, PlayerFSMState> states = new Dictionary<PlayerState, PlayerFSMState>();


	private void Awake()
	{
        layerMask = (1 << 9) + (1 << 10);

        //layerMask = 1 << LayerMask.NameToLayer("Level");
        //layerMask += 1 << LayerMask.NameToLayer("Monster");
        //두 레이어의 값을 합하여 한 식으로 표현 << 은 자리를 점프하여 각 수를 나타낸 것

		marker = GameObject.FindGameObjectWithTag("Marker").transform;
        anim = GetComponentInChildren<Animation>();
        stat = GetComponent<CharacterStat>();
        cc = GetComponent<CharacterController>();

		states.Add(PlayerState.IDLE, GetComponent<PlayerIDLE>());
		states.Add(PlayerState.RUN, GetComponent<PlayerRUN>());
		states.Add(PlayerState.CHASE, GetComponent<PlayerCHASE>());
		states.Add(PlayerState.ATTACK, GetComponent<PlayerATTACK>());

		
	}

	public void SetState(PlayerState newState)
	{
		foreach (PlayerFSMState fsm in states.Values)
		{
			fsm.enabled = false;
		}

		states[newState].enabled = true;
        states[newState].BeginState();
	}
		// Use this for initialization
		void Start ()
	{
		SetState(startState);	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(r, out hit, 1000f, layerMask))
			{
                if(hit.transform.gameObject.layer == 9)
                {
                    marker.position = hit.point;
                    target = null;
                    SetState(PlayerState.RUN);
                }
                else if(hit.transform.gameObject.layer == 10)
                {
                    target = hit.transform;
                    SetState(PlayerState.CHASE);
                }
				
			}
		}

	}
}
