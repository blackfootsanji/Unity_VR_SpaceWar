/* MobileHeadTracker.cs
 * (c) 2014 Quantum Leap Computing (QLC)
 * Author: Dave Arendash
 */
 using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
// Very simple mobile tracker based on accelerometer/compass (which should work with older phones which have no gyros)
public class MobileHeadTracker : MonoBehaviour {

	public GameObject gText;
	private bool gotInitHeading;
	private float initHeading;
	private AsyncOperation async;

	// Use this for initialization
	void Start () {
		Input.compass.enabled = true;
		initHeading = 0f;
			//Input.com
		//Input.location.Start();
		gotInitHeading = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (!gotInitHeading) {
			initHeading = Input.compass.magneticHeading;
			if (initHeading != 0f) {
				gotInitHeading = true;
			}
		} else {
			transform.eulerAngles = new Vector3 (Input.acceleration.z * 70f,2f*(initHeading - Input.compass.magneticHeading), -Input.acceleration.x * 70f);
		}

		if (Input.GetButtonDown ("Fire1")) {
			StartCoroutine (loading());
			Input.compass.enabled = false;
		}
	}
		

	IEnumerator loading(){
		async = SceneManager.LoadSceneAsync (0);
		yield return async;
	}

}
