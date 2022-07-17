using UnityEngine;

public class AndGate : BuiltinChip {

	protected override void Awake () {
		base.Awake ();
		category = ChipCategory.Gate;
	}

	protected override void ProcessOutput () {
		int outputSignal = inputPins[0].State & inputPins[1].State;
		outputPins[0].ReceiveSignal (outputSignal);
	}

}