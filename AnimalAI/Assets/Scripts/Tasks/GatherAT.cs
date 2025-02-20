using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

namespace NodeCanvas.Tasks.Actions {

	public class GatherAT : ActionTask {
        public GameObject food;
		public Transform destination;
		public BBParameter<Transform> target;
		NavMeshAgent navAgent;

		public GameObject icon;
		public Transform spawn;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//create a food icon over the ant
			GameObject.Instantiate(icon, spawn);

            //destroy stationary food item
            GameObject.Destroy(food);

			//set pathing to colony
            target.SetValue(destination);
			navAgent.SetDestination(target.value.position);
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (!navAgent.pathPending && navAgent.remainingDistance <= navAgent.stoppingDistance)
			{
				//destroy the icon after food has been brought to nest
				GameObject.Destroy(icon);
				EndAction(true);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}