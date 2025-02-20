using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using TMPro;

namespace NodeCanvas.Tasks.Actions {

	public class BuildingAT : ActionTask {
        public BBParameter<float> quality;
        public BBParameter<float> expansion;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			expansion.SetValue(0f);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//decrease nest quality over time
			quality.SetValue(quality.value -= Time.deltaTime);
            //increment nest expansion until nest is doubled
            expansion.SetValue(expansion.value += 3 * Time.deltaTime);
            if (expansion.value >= 100)
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