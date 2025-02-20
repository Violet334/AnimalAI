using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using TMPro;


namespace NodeCanvas.Tasks.Actions {

	public class RestAT : ActionTask {
        public TextMeshProUGUI energyText;
        public BBParameter<float> energy;
		public BBParameter<bool> decreaseEnergy;

		Renderer rend;
		public Material initMaterial;
		public Material material;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			rend = agent.GetComponent<Renderer>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			decreaseEnergy.SetValue(false);
			rend.material = material;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            //update energy
            energy.SetValue(energy.value += 2.5f * Time.deltaTime);
            //update ui
            energyText.text = "Energy: " + Mathf.Round(energy.value);
			if(energy.value >= 100)
			{
				rend.material = initMaterial;
				decreaseEnergy.SetValue(true);
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