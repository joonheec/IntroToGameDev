using UnityEngine;
using System.Collections;

public class WASDMove : MonoBehaviour {
	public Vector3 fwdMove;
	public float moveSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//check if player is pressing w
		if (Input.GetKey(KeyCode.W)) {
			//move character forward
			transform.position += transform.forward * Time.deltaTime * moveSpeed; 

		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position -= transform.forward * Time.deltaTime * moveSpeed;


		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position -= transform.right * Time.deltaTime * moveSpeed;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position += transform.right * Time.deltaTime * moveSpeed;
		}
	}
}
