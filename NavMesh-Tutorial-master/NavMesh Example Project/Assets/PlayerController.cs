using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour {

	public Camera cam;

	public NavMeshAgent agent;

	public ThirdPersonCharacter character;

	void Start () {
		agent.updateRotation = false;
	}

	// Update is called once per frame
	void Update () 
	{
		//if user left clicks
		if (Input.GetMouseButtonDown(0))
		{
			//get the point they clicked on from the camera and save as a ray
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				//set the agent's destination to the clicked point
				agent.SetDestination(hit.point);
			}

			if(agent.remainingDistance > agent.stoppingDistance) {
				character.Move (agent.desiredVelocity, false, false);
			} else {
				character.Move(Vector3.zero, false, false);
			}

		}
	}
}