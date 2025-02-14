using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using TMPro;

namespace NodeCanvas.Tasks.Actions {

	public class SearchingAT : ActionTask {
		public TextMeshProUGUI text;
		public BBParameter<Transform> target;
		public Transform destination;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			text.text = "Awaiting Commands...";
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (Input.GetKeyDown(KeyCode.Space))
            {
				target.SetValue(destination);
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