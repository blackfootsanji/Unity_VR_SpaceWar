using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour {
	private float count;
	// Use this for initialization
	public float shake_range = 0 ;
	public float limit_time = 0;
	private Vector3 originpos;
	void Start () {
		originpos = transform.position;
		if (shake_range == 0) {
			shake_range = 0.3f;
		}
		if (limit_time == 0) {
			limit_time = 0.6f;
		}

	}
	void startshake(){

		StartCoroutine (yao());
	}
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator yao(){
		count = 0;
		Vector3 vec = Vector3.zero;
		while(count<limit_time){
			count += Time.smoothDeltaTime;
			vec.x = originpos.x + Random.Range (-shake_range, shake_range);
			vec.y = originpos.y +  Random.Range (-shake_range, shake_range);
			vec.z = originpos.z;
			transform.position = vec;
			yield return 0;
		}
		transform.position = originpos;
		StopCoroutine (yao());
	}

}
