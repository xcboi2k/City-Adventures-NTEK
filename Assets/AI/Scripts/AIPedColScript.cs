using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPedColScript : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent m_Agent;
    public UnityEngine.AI.NavMeshAgent agent
	{
		get
		{
			if(!m_Agent)
				m_Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
			return m_Agent;
		}
	}

    CharacterController controller;
    Animator animator;

    public GameObject body;

	private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = body.GetComponent<Animator>();
    }

	public Vector3 characterVelocity;
    void CharacterAnimation()
    {
        characterVelocity = body.transform.InverseTransformDirection(agent.velocity);
        animator.SetFloat("x", characterVelocity.x, 0.05f, Time.deltaTime);
        animator.SetFloat("z", characterVelocity.z, 0.05f, Time.deltaTime);
        animator.SetFloat("y", characterVelocity.y, 0.05f, Time.deltaTime);
    }

    private void Update() {
        CharacterAnimation();
    }
    
    private void OnTriggerEnter(Collider Col) {
        if(Col.gameObject.tag == "Road"){
            Destroy(gameObject);
            Debug.Log("No Jaywalking.");
        }
    }
}
