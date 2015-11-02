using UnityEngine;
using System.Collections;

public class TextAdventureScript : MonoBehaviour {
	
	public string currentRoom = "Office Entrance";
	public Camera myCamera;


	public string room_north = "";
	public string room_south = "";
	public string room_west = "";
	public string room_east = "";


	public AudioSource bgm;
	public AudioClip bgm_victory;
	public AudioSource sfx;
	public AudioClip sfx_janKeyCard;
	public AudioClip sfx_hasGun;
	public AudioClip sfx_win;



	private bool hasJanKeyCard = false;
	private bool roomEntered = false;
	private bool hasGun = false;
	private bool won = false;




		
		
		


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
			textBuffer = "Office Massacre\n"+"Joon Hee Choi";
			room_north = "Stairwell";


			break;
		case "Stairwell":
			textBuffer = "You're in the stairwell.\n Press 'Enter' to go to the next floor.";
				if (Input.GetKeyDown(KeyCode.KeypadEnter)){
				currentRoom = "Second Floor";

			}
			break;
		case "Second Floor":
			textBuffer = "You're on the second floor.\n There is a connector room to your north.";
			room_north = "Connector";
			room_south = "Stairwell";
			break;
		case "Connector":
			textBuffer = "You're in the connector room.";
			room_east = "Janitorial Storage Room";
			room_west = "Security Guards' Locker Room";
			room_north = "First Office Room";

			break;
		case "Janitorial Storage Room":
			textBuffer = "You're in the janitor's storage room.\n"+
				"You found the Janitorial Key Card.\n"+"Press 'M' to pick it up.";
			room_east = "Connector";
			if (Input.GetKeyDown(KeyCode.M)){
				currentRoom = "Got Key";
				}
			break;
		case "Got Key":
				textBuffer = "You got the Janitorial Key Card. \n";
			if(!hasJanKeyCard){
				sfx.PlayOneShot(sfx_janKeyCard);
				hasJanKeyCard = true;
			}
				room_east = "Connector";
				

			break;
		case "Security Guards' Locker Room":
			room_west = "Connector";
			if (!hasJanKeyCard){
				textBuffer = "You do not have access to this room. ";
				if(Input.anyKeyDown){
					currentRoom = "Connector";
				}
			}
				else if (hasJanKeyCard){
					textBuffer = "You are in the locker room.\n ";
					if(!hasGun){
						textBuffer += "A guard left a gun behind. \nPress 'M' to pick it up";
						if (Input.GetKeyDown(KeyCode.M)){
							currentRoom = "Gun Room";
						
						}
					}
				}
			break;
		case "Gun Room":
			textBuffer = "You picked up the gun. \nPress any key to leave the \nlocker room.";
			hasGun = true;
			sfx.PlayOneShot(sfx_hasGun);
			if(Input.anyKeyDown){
				currentRoom = "Connector";
			}
			break;
		case "First Office Room":
			textBuffer = "You are in the First Office Room.\n";
			room_south = "Connector";
			room_east = "Second Office Room";
			if (hasGun){
				if (!roomEntered){
					textBuffer += "\nYou're employees are still at \nthe office.\n"
						+"You don't want any witnesses...\n"+ "Press 'M' to kill them.";
					roomEntered = true;
					if(Input.GetKeyDown(KeyCode.M)){
						currentRoom = "Second Office Room";
					}
				}
			}
			break;
		case "Second Office Room":
			textBuffer = "You are in the Second Office Room";
			room_west = "First Office Room";
			room_east = "Executive Office";
			if (hasGun){
				if (!roomEntered){
						textBuffer += "You're employees are still at the office.\n"
							+"You don't want any witnesses...\n"+ "Press 'M' to kill them.";
					roomEntered = true;
						if(Input.GetKeyDown(KeyCode.M)){
							currentRoom = "Executive Office";
						}
					}
				}
			break;
		case "Executive Office":
			textBuffer = "You are in the Executive Office.\n"+"All the Executives have left.";
			room_north = "Secretary";
			room_west = "Second Office Room";
			break;
		case "Secretary":
			textBuffer = "You don't have an appointment with the CEO.\n";
			room_south = "Executive Office";
			room_west = "CEO Office";
			if(hasGun){
				textBuffer+="Press 'M' to kill the secretary";
				if(Input.GetKeyDown(KeyCode.M)){
					currentRoom = "CEO Office";
				}
			}
			room_south = "Executive Office";
			room_west = "CEO Office";

			break;
		case "CEO Office":
			if(!hasGun){
				textBuffer = "You do not have a gun. Press any key... ";
				if(Input.anyKeyDown){
					currentRoom = "Secretary";
				}
			}
			else if(hasGun){
				currentRoom = "Kill CEO";
			}
			   break;
		case "Kill CEO":
			textBuffer = "You found the CEO. Kill this man.\n"+
				"Press 'M' to kill your boss";
			if(Input.GetKeyDown(KeyCode.M)){
				currentRoom = "Dead CEO";

			}
			break;
		case "Dead CEO":
			textBuffer = "You killed the CEO and ended up in jail!\n"+
				"Congrats!!";
			if (!won){
			won = true;
			sfx.PlayOneShot(sfx_win);
			}
			bgm.clip = bgm_victory;
			if(!bgm.isPlaying){
				bgm.Play ();
			}
			break;
		default:
			break;


		}



		if (room_south != "")
		{
			textBuffer += "\nPress 'S' to go to the " + room_south + ".";
			
			if(Input.GetKeyDown(KeyCode.S))
			{
				currentRoom = room_south;
			
			}
		}
		if (room_north != "")
		{
			textBuffer += "\nPress 'N' to go to the " + room_north + ".";
			
			if(Input.GetKeyDown(KeyCode.N))
			{
				currentRoom = room_north;
				
			}
		}
		if (room_west != "")
		{
			textBuffer += "\nPress 'W' to go to the " + room_west + ".";
			
			if(Input.GetKeyDown(KeyCode.W))
			{
				currentRoom = room_west;
				
			}
		}
		if (room_east != "")
		{
			textBuffer += "\nPress 'E' to go to the " + room_east + ".";
			
			if(Input.GetKeyDown(KeyCode.E))
			{
				currentRoom = room_east;
				
			}
		}
		GetComponent<TextMesh> ().text = textBuffer;
	}
}