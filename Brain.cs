using UnityEngine;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class Brain : MonoBehaviour
{
	
	public GameObject myo = null;
	private Animation animation;
	private int _side;
	public GameObject hand;
	private bool _fist_stop;
	private bool _point_stop;
	private bool _fist_out_stop;
	private bool _point_out_stop;
	private bool _cylindrical_stop;
	private string _key;
	private string _last_key;
	// The pose from the last update. This is used to determine if the pose has changed
	// so that actions are only performed upon making them rather than every frame during
	// which they are active.
	private Pose _lastPose = Pose.Unknown;

	void Start() 
	{
		animation = GetComponent<Animation>();
	}
	
	void Update()
	{
		// Access the ThalmicMyo component attached to the Myo game object.
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

		// Check if the pose has changed since last update.
		// The ThalmicMyo component of a Myo game object has a pose property that is set to the
		// currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
		// detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
		// is not on a user's arm, pose will be set to Pose.Unknown.

		// Next two if loops checks which key is pressed for each frame. It takes Input.inputString to see which key
		// If no key is pressed then it will contain an empty string. We check for this.
		// This is necessary since the way EPOC is implemented is by EmoKey. A key is being pressed once every 0.2sec. This is captured.
		//Writes the first input from keyboard to _key
		if (string.IsNullOrEmpty(_key)) {
			_key = Input.inputString;
			}
		// if the new input is not empty then it must be a new key
		if (!string.IsNullOrEmpty(Input.inputString)) {
			_key = Input.inputString;
			}

		Debug.Log (_key);
		if (thalmicMyo.pose != _lastPose)
		{
			_lastPose = thalmicMyo.pose;
			
			// Vibrate the Myo armband when a fist is made.
			if (thalmicMyo.pose == Pose.Fist)
			{
				if(_key == "u") {
					_side = 3;
				}
				// First test of "key active" for EEG headset. This works.
				if(_key == "t"){
					_side = 10;
				}
				if(_key == "y"){
					_side = 7;
				}
			}
			else if (thalmicMyo.pose == Pose.WaveIn)
			{
				if(_key == "u") {
					_side = 5;
				}
				// First test of "key active" for EEG headset. This works.
				if(_key == "t"){
					_side = 1;
				}
				if(_key == "y"){
					_side = 9;
				}
			}
			else if (thalmicMyo.pose == Pose.WaveOut)
			{
				if(_key == "u") {
					_side = 6;
				}
				// First test of "key active" for EEG headset. This works.
				if(_key == "t"){
					_side = 2;
				}
				if(_key == "y"){
					_side = 8;
				}
			}
			else if (thalmicMyo.pose == Pose.DoubleTap)
			{
				//_side = 4;
				//ExtendUnlockAndNotifyUserAction(thalmicMyo);
			}
			else if (thalmicMyo.pose == Pose.FingersSpread)
			{
				_side = 4;

			}
			else if (thalmicMyo.pose == Pose.Rest)
			{
				_side = 0;

			}
		}


//		The following constaints the animation until a specific time (frame)
//		This stops the animation from completing or going into a wrong playtime-frame
		// Fist
		if (animation["Fist"].time > 0.65f) {
			animation["Fist"].time = 0.65f;
			}
		else if (animation["Fist"].time < 0.1f) {
			animation["Fist"].time = 0.1f;
		}
		// Cylindrical
		else if (animation["Cylindrical"].time > 0.7f) {
			animation["Cylindrical"].time = 0.7f;
		}
		else if (animation["Cylindrical"].time < 0.1f) {
			animation["Cylindrical"].time = 0.1f;
		}
		// Rotate Left
		else if (animation["RotateLeft"].time > 0.65f) {
			animation["RotateLeft"].time = 0.65f;
		}
		else if (animation["RotateLeft"].time < 0.1f) {
			animation["RotateLeft"].time = 0.1f;
		// Rotate Right
		}
		else if (animation["RotateRight"].time > 0.65f) {
			animation["RotateRight"].time = 0.65f;
		}
		else if (animation["RotateRight"].time < 0.1f) {
			animation["RotateRight"].time = 0.1f;
		// 2-finger pinch
		}
		else if (animation["TwoPinch"].time > 0.7f) {
			animation["TwoPinch"].time = 0.7f;
		}
		else if (animation["TwoPinch"].time < 0.1f) {
			animation["TwoPinch"].time = 0.1f;
		// 1-finger pinch
		}
		else if (animation["Pinch"].time > 0.7f) {
			animation["Pinch"].time = 0.7f;
		}
		else if (animation["Pinch"].time < 0.1f) {
			animation["Pinch"].time = 0.1f;
		// Wave in
		}
		else if (animation["WaveIn"].time > 0.7f) {
			animation["WaveIn"].time = 0.7f;
		}
		else if (animation["WaveIn"].time < 0.1f) {
			animation["WaveIn"].time = 0.1f;
		// Wave out
		}
		else if (animation["WaveOut"].time > 0.7f) {
			animation["WaveOut"].time = 0.7f;
		}
		else if (animation["WaveOut"].time < 0.1f) {
			animation["WaveOut"].time = 0.1f;
		// Point with index finger
		}
		else if (animation["Point"].time < 0.1f) {
			animation["Point"].time = 0.1f;
		}
		else if (animation ["Point"].time > 0.70f) {
			animation["Point"].time = 0.70f;
				}

		// The following plays the animations based on the input.
		// CrossFade is used in order to blend between animations
		// Speed can be adjusted to play faster or slower. Higher number = faster
		// _side == 4 is the one going from any grip to idle

		if (_side == 3)
		{
//			_fist_out_stop = false;
			animation["Fist"].speed = 0.6f;
			animation.CrossFade ("Fist");
			Debug.Log (animation["Fist"].time + " - FIST IN TIME");

			//box.transform.Translate(Vector3.left * Time.deltaTime);
		}
		else if (_side == 4)
		{
			_fist_stop = false;
			animation["Fist"].speed = -0.6f;
			animation.CrossFade("Fist");
			Debug.Log (animation["Fist"].time + " - POSE OUT TIME");
		}
		else if (_side == 1)
		{
			_point_out_stop = false;

			animation["RotateLeft"].speed = 0.6f;
			animation.CrossFade("RotateLeft");
			Debug.Log (animation["RotateLeft"].time + " - ROTATE LEFT TIME");
		}
		else if (_side == 2)
		{

			animation["RotateRight"].speed = 0.6f;
			animation.CrossFade("RotateRight");
			Debug.Log (animation["RotateRight"].time + " - ROTATE RIGHT TIME");
		}
		else if (_side == 5)
		{

			animation["WaveIn"].speed = 0.6f;
			animation.CrossFade("WaveIn");
			Debug.Log (animation["WaveIn"].time + " - WaveIn TIME");
		}
		else if (_side == 6)
		{

			animation["WaveOut"].speed = 0.6f;
			animation.CrossFade("WaveOut");
			Debug.Log (animation["WaveOut"].time + " - WAVE OUT TIME");
		}
		else if (_side == 7)
		{

			animation["Point"].speed = 0.6f;
			animation.CrossFade("Point");
			Debug.Log (animation["Point"].time + " - POINT TIME");
		}
		else if (_side == 8)
		{

			animation["TwoPinch"].speed = 0.6f;
			animation.CrossFade("TwoPinch");
			Debug.Log (animation["TwoPinch"].time + " - TWO PINCH TIME");
		}
		else if (_side == 9)
		{

			animation["Pinch"].speed = 0.6f;
			animation.CrossFade("Pinch");
			Debug.Log (animation["Pinch"].time + " - PINCH TIME");
		}
		else if (_side == 10)
		{

			animation["Cylindrical"].speed = 0.6f;
			animation.CrossFade("Cylindrical");
			Debug.Log (animation["Cylindrical"].time + " - CYLINDRICAL TIME");
		}
		else {
			animation["Fist"].speed = 0.0f;
			animation["Point"].speed = 0.0f;
			animation["WaveIn"].speed = 0.0f;
			animation["WaveOut"].speed = 0.0f;
			animation["RotateLeft"].speed = 0.0f;
			animation["RotateRight"].speed = 0.0f;
			animation["TwoPinch"].speed = 0.0f;
			animation["Pinch"].speed = 0.0f;
			animation["Cylindrical"].speed = 0.0f;
		}
	}

	void OnGUI () {
		GUI.skin.label.fontSize = 30;
		GUI.skin.label.fontStyle = FontStyle.Bold;
		GUI.color = Color.red;
		if (_key == "t") {
			GUI.Label(new Rect (12, 250, Screen.width, Screen.height),
			          "PUSH"
			          );
				}
		else if (_key == "y") {
			GUI.Label(new Rect (12, 250, Screen.width, Screen.height),
			          "LIFT"
			          );
		}
		else if (_key == "u") {
			GUI.Label(new Rect (12, 250, Screen.width, Screen.height),
			          "ROTATE"
			          );
		}
		else {
			GUI.Label(new Rect (12, 250, Screen.width, Screen.height),
			          "NO INPUT YET"
			          );
		}
	}
	
	// Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
	// recognized.
	void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
	{
		ThalmicHub hub = ThalmicHub.instance;
		
		if (hub.lockingPolicy == LockingPolicy.Standard) {
			myo.Unlock (UnlockType.Timed);
		}
		
		myo.NotifyUserAction ();
	}
}
