using UnityEngine;
using System.Collections;

using Pose = Thalmic.Myo.Pose;

public class ActiveInput : MonoBehaviour {


	public GameObject myo = null;
	private string _key;

	void OnGUI () {
		GUI.skin.label.fontSize = 20;
		GUI.skin.label.fontStyle = FontStyle.Bold;
		GUI.color = Color.red;

		ThalmicHub hub = ThalmicHub.instance;
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		if (_key == "t") {
			if (thalmicMyo.pose == Pose.Fist) {
				GUI.Label(new Rect (625, 0, Screen.width, Screen.height),
			          "EEG input: Push\n" +
				      "EMG input: Fist"
			          );
				}
			else if (thalmicMyo.pose == Pose.WaveIn) {
				GUI.Label(new Rect (625, 0, Screen.width, Screen.height),
				          "EEG input: Push\n" +
			        	  "EMG input: Wave In"
			        	  );
			}
			else if (thalmicMyo.pose == Pose.WaveOut) {
				GUI.Label(new Rect (625, 0, Screen.width, Screen.height),
				          "EEG input: Push\n" +
			        	  "EMG input: Wave Out"
				          );
			}
		}
		else if (_key == "y") {
			if (thalmicMyo.pose == Pose.Fist) {
				GUI.Label(new Rect (625, 0, Screen.width, Screen.height),
				          "EEG input: Lift\n" +
				          "EMG input: Fist"
				          );
			}
			else if (thalmicMyo.pose == Pose.WaveIn) {
				GUI.Label(new Rect (625, 0, Screen.width, Screen.height),
				          "EEG input: Lift\n" +
				          "EMG input: Wave In"
				          );
			}
			else if (thalmicMyo.pose == Pose.WaveOut) {
				GUI.Label(new Rect (625, 0, Screen.width, Screen.height),
				          "EEG input: Lift\n" +
				          "EMG input: Wave Out"
				          );
			}
		}
		else if (_key == "u") {
			if (thalmicMyo.pose == Pose.Fist) {
				GUI.Label(new Rect (625, 0, Screen.width, Screen.height),
				          "EEG input: U (rotate)\n" +
				          "EMG input: Fist"
				          );
			}
			else if (thalmicMyo.pose == Pose.WaveIn) {
				GUI.Label(new Rect (625, 0, Screen.width, Screen.height),
				          "EEG input: U (rotate)\n" +
				          "EMG input: Wave In"
				          );
			}
			else if (thalmicMyo.pose == Pose.WaveOut) {
				GUI.Label(new Rect (625, 0, Screen.width, Screen.height),
				          "EEG input: U (rotate)\n" +
				          "EMG input: Wave Out"
				          );
			}
		}
		}
	void Update () {

		ThalmicHub hub = ThalmicHub.instance;

		if (string.IsNullOrEmpty(_key)) {
			_key = Input.inputString;
		}
		// if the new input is not empty then it must be a new key
		if (!string.IsNullOrEmpty(Input.inputString)) {
			_key = Input.inputString;
		}
	}
}
