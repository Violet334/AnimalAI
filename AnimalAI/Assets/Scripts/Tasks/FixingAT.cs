using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using TMPro;

namespace NodeCanvas.Tasks.Actions {

	public class FixingAT : ActionTask {
		public BBParameter<float> quality;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//increment nest quality until nest is completely fixed
			quality.SetValue(quality.value += 3*Time.deltaTime);
			if (quality.value >= 100)
			{
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