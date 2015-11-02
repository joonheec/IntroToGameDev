using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	public float moveSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	// check if player clicks
	if (Input.GetMouseButton (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// get location of click
			//transform.position = Input.mousePosition;
			// create a tag for the plane, so that the ray is restricted to being hit on the PLANE
			if(Physics.Raycast(ray, out hit) && hit.collider.tag == "Ground") {
				Vector3 move;
				//get directions to destination
				//vector between destination and current location
				move = hit.point - transform.position;
				// set that vector's magnitude to 1
				move.Normalize();
				transform.position += move * Time.deltaTime * moveSpeed;
				// get location of click
				// LERP IS OK, but i want more control!
				//transform.position = Vector3.Lerp(transform.position, hit.point, 0.2f);
			}
		}

	// move player toward click location
	}
 }
