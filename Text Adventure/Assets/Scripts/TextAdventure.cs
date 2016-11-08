using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextAdventure : MonoBehaviour {
	
	public string currentRoom;
	public AudioSource sfxSource; 
	public AudioClip click;

	private bool hasKey = false;
	private bool hasTorch = false;
	private bool needTorch = false;

	//variables to store possible room connections
	private string room_north;
	private string room_south;
	private string room_west;
	private string room_east;

	// Use this for initialization
	void Start () {
		currentRoom = "Prologue";
	}
	
	// Update is called once per frame
	void Update () {

		room_east = "nil";
		room_north = "nil";
		room_south = "nil";
		room_west = "nil";

		if (currentRoom == "Prologue") {
			room_north = "Entry"; 
			GetComponent<Text> ().text = "Tales of hidden treasure and long lost artifacts have brought you to a mysterious house located in the middle of a misty alpine forest.";
			GetComponent<Text> ().text += "\nYou find yourself at the front steps of this seemingly quaint little home. You enter without a second thought about possible hidden dangers like ghosts or scary hillbilly zombies.";
			GetComponent<Text> ().text += "\nThe front door is unlocked. It creaks open. Spooky.\n\n";

		} else if (currentRoom == "Entry") {
			room_north = "Hallway";
			GetComponent<Text> ().text = "You are in the entryway. A few cobwebs here and there. Nothing out of the ordinary.";
			GetComponent<Text> ().text += "\nThe front door has locked itself, barring you from exiting. There doesn't seem to be a keyhole either.\n\n";

		} else if (currentRoom == "Hallway") {
			room_east = "Kitchen";
			room_south = "Entry";
			room_west = "Study";
			GetComponent<Text> ().text = "You are in the main hall. The walls are aligned with several dusty paintings. The wallpaper is stained, peeling off as time wears at the adhesive. You can see the rot in the floorboards. They creak with every step. Try not to wake anyone...or anything.";
			GetComponent<Text> ().text += "\nPoke around the different rooms to continue your search.\n\n";

		} else if (currentRoom == "Kitchen") {
			room_west = "Hallway";
			GetComponent<Text> ().text = "You are in the kitchen. Some cupboards are open, others have its doors hanging by the hinge. ";
			GetComponent<Text> ().text += "You may want to search the area for anything useful. You definitely won't find anything edible, however. "; 
			GetComponent<Text> ().text += "\nPress 'i' to inspect the room.\n\n";

			if (Input.GetKeyDown (KeyCode.I)) {
				currentRoom = "Drain";
				sfxSource.Play ();
			}
				
			if (hasKey) {
				GetComponent<Text> ().text = "The kitchen lies bare. There doesn't seem to be anything of interest except some scrapes on the floorboards. They seem to resemble nail marks.";
				GetComponent<Text> ().text += "\nBetter head back and see where this key fits.\n\n"; 
			}

		} else if (currentRoom == "Drain") {
			hasKey = true;
			GetComponent<Text> ().text = "Upon closer inspection of the room, you eventually find a key. Nice! Presumably it will open the locked door. Won't hurt to try.";
			GetComponent<Text> ().text += "\n\nPress 'space' to continue.";

			if (Input.GetKeyDown (KeyCode.Space)) {
				currentRoom = "Kitchen";
			}

		} else if (currentRoom == "Study") {
			
			if (hasKey) {
				room_east = "Hallway";
				GetComponent<Text> ().text = "You enter the Study. Old tomes and books still line the bookshelves. Strangely, you feel a slight breeze coming in from under one of the bookshelves. There must be someway to get behind it! ";
				GetComponent<Text> ().text += "\nYou notice that there are 26 books on the shelf that have a letter of the alphabet. On the wall above the bookshelf are 4 unlit candles. Perhaps you should investigate these dusty old tomes to find an answer...\n\n";

				if (Input.GetKeyDown (KeyCode.O)) {
					currentRoom = "Study1";
					sfxSource.Play ();
				}


			} else {
				room_east = "Hallway";
				GetComponent<Text> ().text = "The door is locked. You will need to find a key to open it. Perhaps it is in the other rooms. Go find out.\n\n";
			}

		} else if (currentRoom == "Study1") {
			GetComponent<Text> ().text = "O _ _ _\n";
			GetComponent<Text> ().text += "As you pull out the book marked 'O', you hear a soft click from behind the bookshelf.\n";
			GetComponent<Text> ().text += "The first candle mysteriously becomes lit. Pretty spooky but you should probably investigate further.";

			if (Input.GetKeyDown (KeyCode.P)) {
				currentRoom = "Study2";
				sfxSource.Play ();
			}

		} else if (currentRoom == "Study2") {
			GetComponent<Text> ().text = "O P _ _\n";
			GetComponent<Text> ().text += "As you pull out the book marked 'P', you hear another soft click.\n";
			GetComponent<Text> ().text += "The second candle lights itself just as the first did. The room feels a bit chilly now.";

			if (Input.GetKeyDown (KeyCode.E)) {
				currentRoom = "Study3";
				sfxSource.Play ();
			}

		} else if (currentRoom == "Study3") {
			GetComponent<Text> ().text = "O P E _\n";
			GetComponent<Text> ().text += "As you pull out the book marked 'E', you hear another soft click.\n";
			GetComponent<Text> ().text += "The third candle lights up. Who's lighting these candles? Only one more left.";

			if (Input.GetKeyDown (KeyCode.N)) {
				currentRoom = "Study4";
				sfxSource.Play ();
			}

		} else if (currentRoom == "Study4") {
			GetComponent<Text> ().text = "O P E N\n";
			GetComponent<Text> ().text += "As the final candle sparks into flames, you hear the whirring of gears and clanking of metal. The bookshelf starts sliding backwards, revealing a small staircase leading down into the darkness.\n";
			GetComponent<Text> ().text += "You're a miracle worker. Who would've guessed that it spelled 'OPEN'?\n";
			GetComponent<Text> ().text += "\nPress Up to go to the Secret Passageway";

			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				currentRoom = "Secret Passageway";
				sfxSource.Play ();
			}

		} else if (currentRoom == "Secret Passageway") {
			room_east = "Basement";
			
			GetComponent<Text> ().text = "The bookshelf slides back into its place, blocking you from the Study. Hopefully you'll find another exit. Hopefully...\n";
			GetComponent<Text> ().text += "Only way out from here is through this passageway.\n\n";

		} else if (currentRoom == "Basement") {
			room_west = "Secret Passageway";
			room_north = "Dark Corridor";
			GetComponent<Text> ().text = "You are in the Basement. It's cold and dry. Lit torches line the walls, revealing markings on the floor that lead into a dark corridor. You feel a chilling breeze coming from it. ";
			GetComponent<Text> ().text += "Scratch marks lead into the dark corridor. This is totally a bad omen. Like, totally. ";
			GetComponent<Text> ().text += "No matter, your thirst for treasure and ancient artifacts push you onwards. Are those blood stains on the wall?\n\n";

			if (needTorch) {
				GetComponent<Text> ().text += "Press 'I' to grab a lantern.\n";

				if (Input.GetKeyDown (KeyCode.I)) {
					hasTorch = true;
					sfxSource.Play ();
					GetComponent<Text> ().text += "You grabbed a lantern!\n\n";
				}
			}
				
		} else if (currentRoom == "Dark Corridor") {
			if (hasTorch) {
				room_north = "Cave";
				room_south = "Basement";
				GetComponent<Text> ().text = "It's a good thing you have this lantern. There seems to be no other light source down here. Make your way through, carefully. It's a relief nothing has surprised you...yet. \n\n";
			} else {
				room_south = "Basement";

				needTorch = true;
				GetComponent<Text> ().text = "It's way too dark for you to be wandering in. Something might get the jump on you. Go grab something bright.\n\n";
			} 
				
		} else if (currentRoom == "Cave") {
			room_east = "Unlit Tunnel";
			room_south = "Dark Corridor";
			GetComponent<Text> ().text = "You find yourself in a large underground cave. Visibility is poor down here even with your lantern. You can faintly hear scratching sounds from across the cave. ";
			GetComponent<Text> ().text += "You can't help but to think about the horror you might face. Scratch marks on the floors, blood stains in the basement walls, mysterious candles that light themselves...this is insane. ";
			GetComponent<Text> ().text += "Make your way carefully across the cave. Try not to attract the attention of whatever is making that scratching noise.\n\n";

		} else if (currentRoom == "Unlit Tunnel") {
			room_west = "Cave";

			GetComponent<Text> ().text = "As you enter the rocky tunnel, you notice that the walls and floor are splattered with a dark red substance. Lines of red lead into the dark beyond. There's a noticable handprint of red on the floor of the tunnel as well as scratch marks. Whatever made those marks really wanted to claw its way out...\n\n";
			GetComponent<Text> ().text += "If you choose to go forward, there may be no turning back. Well it's not like you had a choice anyways, the way back is blocked. ";
			GetComponent<Text> ().text += "\n\n Press Up to traverse into the unknown. FOR TREASURE.\n";

			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				currentRoom = "The Monster's Lair";
			}

		} else if (currentRoom == "The Monster's Lair") {
			GetComponent<Text> ().text = "Bones. Bones everywhere. Some are bare, other's still have the meat on them...bloody...red. Broken lanterns everywhere. Whatever made this pile is a messy eater. That does not bode well for you. As you try silently walking past all of this, your foot crunches one of the bones. You hear something breathe, almost cackling as it does. You feel its breath over your shoulder. The lantern goes dim.";
			GetComponent<Text> ().text += "\nClever Girl.";
			GetComponent<Text> ().text += "\n\nPress Space to continue...";

			if (Input.GetKeyDown (KeyCode.Space)) {
				currentRoom = "Game Over";
			}

		} else if (currentRoom == "Game Over") {
			GetComponent<Text> ().text = "You are just more bones to add to the pile. Play again to add more bones to the pile!";	

		} else {
			GetComponent<Text> ().text = "something broke";

		}

		if (room_north != "nil") {
			GetComponent<Text> ().text += "Press Up to go to the " + room_north + "\n";
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				currentRoom = room_north;
			}
		}
		if (room_south != "nil") {
			GetComponent<Text> ().text += "Press Down to go to the " + room_south + "\n";
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				currentRoom = room_south;
			}
		}
		if (room_west != "nil") {
			GetComponent<Text> ().text += "Press Left to go to the " + room_west + "\n";
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				currentRoom = room_west;
			}
		}
		if (room_east != "nil") {
			GetComponent<Text> ().text += "Press Right to go to the " + room_east + "\n";
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				currentRoom = room_east;
			}
		}
	}
}
