using UnityEngine;
using System.Collections;

// Draw simple instructions for sample scene.
// Check to see if a Myo armband is paired.
public class GUIScene : MonoBehaviour
{
    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;

    // Draw some basic instructions.
    void OnGUI ()
    {
        GUI.skin.label.fontSize = 15;
		GUI.skin.label.fontStyle = FontStyle.Bold;
		GUI.color = Color.black;

        ThalmicHub hub = ThalmicHub.instance;

        // Access the ThalmicMyo script attached to the Myo object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

        if (!hub.hubInitialized) {
            GUI.Label(new Rect (12, 8, Screen.width, Screen.height),
                "Cannot contact Myo Connect. Is Myo Connect running?\n" +
                "Press Q to try again."
            );
        } else if (!thalmicMyo.isPaired) {
            GUI.Label(new Rect (12, 8, Screen.width, Screen.height),
                "No Myo currently paired."
            );
        } else if (!thalmicMyo.armSynced) {
            GUI.Label(new Rect (12, 8, Screen.width, Screen.height),
                "Perform the Sync Gesture."
            );
        } else {
            GUI.Label (new Rect (12, 8, Screen.width, Screen.height),
			    "Fingers spread: From grip to idle\n" +
			    "Fist + Push: Cylindrical\n" +
			    "Wave in  + Push: Rotate wrist left\n" +
			    "Wave out + Push: Rotate wrist right\n" +
			    "Fist + Lift: Point\n" +
			    "WaveIn + Lift: 1-finger pinch\n" +
			    "WaveOut + Lift: 2-finger pinch\n"
            );
        }
    }

    void Update ()
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (Input.GetKeyDown ("q")) {
            hub.ResetHub();
        }
    }
}
