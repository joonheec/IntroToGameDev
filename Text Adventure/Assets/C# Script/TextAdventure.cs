using UnityEngine;
using System.Collections;

public class TextAdventure : MonoBehaviour {

	public string currentRoom = "entryway";
	public string room_north;
	public string room_south;
	public string room_west;
	public string room_east;
	private bool hasKey = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		string textBuffer = "";
		room_east = "";
		room_north = "";
		room_west = "";
		room_south = "";
		switch (currentRoom) {
			case "entryway":
				textBuffer = "You are in the entryway.\n" +
					"There is a magic room to the north.";
				room_north = "magicRoom";
				break;
			case "magicRoom":
				textBuffer = "You are in the magic room. \n";
				room_south = "entryway";
				room_east = "partyRoom";
				room_west = "key room";

				break;
		case "key room":
			textBuffer = "You are in a room, that's called \n"+
				"the key room, for some reason,\n"+
				"There is a drawer in front of you.\n"+
					"Press 'm' to open the drawer\n";
			if (Input.GetKeyDown(KeyCode.M)){
				hasKey = true;
				currentRoom = "got key";
			}
			break;
		case "got key":
				textBuffer = "Congrats. You found the key. Leave. Press any key";
				if (Input.anyKeyDown){
					currentRoom = "magicRoom";
				}
			break;
			case "partyRoom":
					textBuffer = "You are in the party room.\n";
					room_west = "magicRoom";
					room_east = "party room door";
				break;
		case "party room door":
				if (hasKey){
					textBuffer = "You use the key to open the door";
					room_south = "after party room";
		
				}
				else{
					textBuffer= "The door is locked. Press any key to return to the party room.";
					if (Input.anyKeyDown){
						currentRoom = "partyRoom";
					}
			 	}	
			break;
		case "after party room":
		textBuffer = "You are in the after party room. \n" +
			"all of your friends are here.\n"+
					"you won.";
			break;

		default:
				break;
		}



		if (room_north!= ""){
			textBuffer += "\n Press 'n' to go to the " + room_north + ".";
		
			if (Input.GetKeyDown(KeyCode.N)){
				currentRoom = room_north;
			}
		}
		if (room_south!= ""){
			textBuffer += "\n Press 's' to go to the " + room_south + ".";
		
			if (Input.GetKeyDown(KeyCode.S)){
				currentRoom = room_south;
			}
		}		
		if (room_east!= ""){
			textBuffer += "\n Press 'e' to go to the " + room_east + ".";
		
			if (Input.GetKeyDown(KeyCode.E)){
				currentRoom = room_east;
			}
		}		
		if (room_west!= ""){
			textBuffer += "\n Press 'w' to go to the " + room_west + ".";
		
			if (Input.GetKeyDown(KeyCode.W)){
				currentRoom = room_west;
			}
		}
		GetComponent<TextMesh> ().text = textBuffer;



	}
}
