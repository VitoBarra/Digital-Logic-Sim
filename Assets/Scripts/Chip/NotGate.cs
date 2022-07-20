public class NotGate : BuiltinChip {

	protected override void Awake () {
		base.Awake ();
		category = ChipCategory.Gate;
	}

	protected override void ProcessOutput () {
		int outputSignal = 1 - inputPins[0].State;
		outputPins[0].ReceiveSignal (outputSignal);
	}
}