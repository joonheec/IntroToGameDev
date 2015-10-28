using UnityEngine;
using System.Collections;

public class TextAdventureScript : MonoBehaviour {
	
	public string currentRoom = "Office Entrance";
	public string room_north = "";
	public string room_south = "";
	public string room_west = "";
	public string room_east = "";


		
		
		


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		string textBuffer = "";
		room_east = "";
		room_north = "";
		room_south = "";
		room_west = "";
		switch (currentRoom) {
		case "Office Entrance":
			textBuffer = "You have entered the office building.\n"+ "Find and kill your annoying boss!\n"+
				"Find the key to the Storage Room\n"+"The Main Room is to the north";
			room_north = "Storage Room";


			break;
		default:
			break;


		}
		GetComponent<TextMesh> ().text = textBuffer;
	}
}