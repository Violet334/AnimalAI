using NodeCanvas.Framework;
using ParadoxNotion.Design;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine;
using TMPro;


namespace NodeCanvas.Tasks.Actions {

	public class VariableAT : ActionTask {
		public TextMeshProUGUI energyText;
        public TextMeshProUGUI qualityText;
        public TextMeshProUGUI expansionText;

		public BBParameter<bool> decrease;
        public BBParameter<float> energy;
        public BBParameter<float> quality;
        public BBParameter<float> expansion;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			decrease.SetValue(true);
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

        //Called once per frame while the action is active.
        protected override void OnUpdate() {
			//update UI values
			energyText.text = "Energy: " + Mathf.Round(energy.value);
			qualityText.text = "Nest Quality: " + Mathf.Round(quality.value);
			expansionText.text = "Nest Expand: " + Mathf.Round(expansion.value);
			//increment the energy variable
			if (decrease.value)
			{
                energy.SetValue(energy.value -= 2 * Time.deltaTime);
            }

            if (energy.value < 0)
            {
                decrease.SetValue(false);
            }
            if (energy.value >= 100)
            {
                decrease.SetValue(true);
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