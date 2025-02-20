using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

namespace NodeCanvas.Tasks.Actions {

	public class TravelAT : ActionTask {
        public string sFxName;

        public BBParameter<Transform> target;
		NavMeshAgent navAgent;
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
            AudioManager.Instance.PlaySound(sFxName);
            navAgent.SetDestination(target.value.position);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if(!navAgent.pathPending && navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                AudioManager.Instance.StopSound(sFxName);
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