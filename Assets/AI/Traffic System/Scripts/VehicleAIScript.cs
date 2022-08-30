using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class VehicleAIScript : AgentScript
{
    private NavSectionScript m_CurrentNavSectionScript;
	private NavConnectionScript m_CurrentOutConnection;

    [Header("Vehicle")]
	public Transform front;

    public virtual void Initialize(NavSectionScript navSection, NavConnectionScript destination)
	{
		m_CurrentNavSectionScript = navSection;
        RegisterVehicle(m_CurrentNavSectionScript, true);
		m_CurrentOutConnection = destination;
		agent.enabled = true;
		speed = TrafficSystemScript.Instance.GetAgentSpeedFromKPH(Mathf.Min(navSection.speedLimit, maxSpeed));
		agent.speed = speed;
		agent.destination = destination.transform.position;
	}

    public virtual void RegisterVehicle(NavSectionScript section, bool isAdd)
    {
        section.RegisterVehicle(this, isAdd);
    }

    public override void Update()
	{
		if(agent.isOnNavMesh)
		{
			m_Blocked = CheckBlocked();
		}
		base.Update();
	}

	public override bool CheckStop()
	{
		if(m_Blocked || isWaiting)
			return true;
		return false;
	}

    public override void OnTriggerEnter(Collider col)
	{
		if(col.tag == "RoadConnection")
		{
			NavConnectionScript connection = col.GetComponent<NavConnectionScript>();
			if(connection.navSection != m_CurrentNavSectionScript)
				SwitchRoad(connection);
		}
		base.OnTriggerEnter(col);
	}

    private bool m_Blocked;

	private float m_BlockedDistance = .25f;
	public float blockedDistance
	{
		get { return m_BlockedDistance; }
		set { m_BlockedDistance = value; }
	}

	private bool CheckBlocked()
	{
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		if (Physics.Raycast(front.position, forward, out hit))
		{
			if(Vector3.Distance(front.position, hit.point) < m_BlockedDistance)
			{
				if(hit.transform.tag == "Gib" || hit.transform.tag == "Unit")
					return true;
			}
			return false;
		}
		return false;
	}

    private void SwitchRoad(NavConnectionScript newConnection)
	{
		RegisterVehicle(m_CurrentNavSectionScript, false);
		speed = TrafficSystemScript.Instance.GetAgentSpeedFromKPH(Mathf.Min(newConnection.navSection.speedLimit, maxSpeed));
		agent.speed = speed;
		m_CurrentNavSectionScript = newConnection.navSection;
		RegisterVehicle(m_CurrentNavSectionScript, true);
		m_CurrentOutConnection = newConnection.GetOutConnection();
		if(m_CurrentOutConnection != null)
			agent.destination = m_CurrentOutConnection.transform.position;
	}

    // public override void OnDrawGizmos()
	// {
	// 	if(TrafficSystem.Instance.drawGizmos)
	// 	{
	// 		Gizmos.color = CheckStop() ? Color.gray : Color.white;
	// 		if(agent.hasPath)
	// 		{	
	// 			Gizmos.DrawWireSphere(agent.destination, 0.1f);
	// 			for (int i = 0; i < agent.path.corners.Length - 1; i++)
	// 				Gizmos.DrawLine(agent.path.corners[i], agent.path.corners[i + 1]);
	// 		}

	// 		Gizmos.color = m_Blocked ? Color.red : Color.green;
	// 		Vector3 blockedRayEnd = front.TransformPoint(new Vector3(0, 0, m_BlockedDistance));
	// 		Gizmos.DrawLine(front.position, blockedRayEnd);
	// 	}
	// }
}
