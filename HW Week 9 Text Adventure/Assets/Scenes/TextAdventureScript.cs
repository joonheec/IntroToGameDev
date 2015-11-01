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
	public AudioSource sfx;
	public AudioClip sfx_janKeyCard;
	public AudioClip sfx_hasGun;


	private bool hasJanKeyCard = false;
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
			textBuffer = "You have entered the office building.\n" + "Find and kill your annoying boss!\n"
				+ "The Stairwell is to the north";
			room_north = "Stairwell";


			break;
		case "Stairwell":
			textBuffer = "You're in the stairwell. Press 'Enter' to go to the next floor.";
				if (Input.GetKeyDown(KeyCode.KeypadEnter)){
				currentRoom = "Second Floor";

			}
			break;
		case "Second Floor":
			textBuffer = "You're on the second floor. There is a connector room to your north.";
			room_north = "Connector";
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
			if (Input.GetKeyDown(KeyCode.M)){
				if(!hasJanKeyCard){
				hasJanKeyCard = true;

				}
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