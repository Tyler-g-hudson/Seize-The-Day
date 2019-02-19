using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectScript : MonoBehaviour {


	//PUBLIC VARIABLES
	public Sprite highlightSprite;
	public Sprite nadirSprite;
	public AudioClip audioClip;

	//SET IN THE EDITOR
	public string hoverText = "Default String";
	public string logText = "Default String";
	public int hygiene = 0;
	public int happiness = 0;
	public int lucidity = 0;
	public int time_taken = 0;

	//PRIVATE VARIABLES
	private string notEnoughTimeText = "You don't have enough time to do that.";
	private bool used = false;

	// Use this for initialization
	void Start() {
		if (hoverText.Equals("Default String") == true) {
			hoverText = "Default String for " + this.gameObject.name;
		}
		if (logText.Equals("Default String") == true) {
			hoverText = "Default String for " + this.gameObject.name;
		}
	}

	void UpdateHoverText()
	{
		//hoverTextBox.text = hoverText;
		//or Call to MouseOverText.cs function
		MouseOverText.instance.setMouseOverText(hoverText);
	}

	void UpdateMainText()
	{
		LogText.instance.updateTextBox (logText);
	}

	void NotEnoughTime()
	{
		LogText.instance.updateTextBox (notEnoughTimeText);
	}

	void Highlight()
	{
		//Cursor.SetCursor (cursorHighlight, Vector2.zero, CursorMode.Auto);
		this.GetComponent<SpriteRenderer>().sprite = highlightSprite;
	}

	void Nadir()
	{
		//Cursor.SetCursor (cursorTexture, Vector2.zero, CursorMode.Auto);
		this.GetComponent<SpriteRenderer>().sprite = nadirSprite;
	}

	public void updateImage () {
		Nadir ();
	}

	public void setUsed (bool desiredValue) {
		used = desiredValue;
	}

	void UpdateStatistics(int happy = 0, int clean = 0, int sane = 0, int time = 0)
	{
		GameController.instance.UpdateStats (happy, clean, sane, time);
	}

	void OnMouseEnter()
	{
		if (!used) {
			UpdateHoverText ();
			Highlight ();
		}
	}

	void OnMouseExit()
	{
		if (MouseOverText.instance.readMouseOverText() == hoverText) {
			//Blank the textbox text
			MouseOverText.instance.resetMouseOverText();
			Nadir ();
		}
	}

	void OnMouseUpAsButton()
	{
		if (MouseOverText.instance.readMouseOverText() == hoverText) {
			//Blank the textbox text
			MouseOverText.instance.resetMouseOverText();
		}
		if (!used) {
			if (GameController.TimeMinutes >= time_taken) {
				SendMessage ("OnActionPerformed",null,SendMessageOptions.DontRequireReceiver);
				if (audioClip != null) {
					if (this.name == GameController.CD_NAME)
						GameController.instance.PlayMusic (audioClip);
					else
						GameController.instance.PlaySFX (audioClip);
				}
				UpdateStatistics (happiness, hygiene, lucidity, time_taken);
				UpdateMainText ();
				used = true;
				Nadir ();
				switch (this.name) {
				case GameController.COFFEE_NAME:
					GameController.instance.DrinkCoffee ();
					break;

				case GameController.RADIO_NAME:
					if(Application.loadedLevelName.Equals(GameController.PERFORMANCE_REVIEW))
						GameController.Day1Radio = true;
					break;
				case GameController.PERCIVAL_NAME:
					GameController.Percival = 0;
					break;

				case GameController.COMPUTER_NAME:
					if(Application.loadedLevelName.Equals(GameController.MARGARET_ACCOUNTING))
						GameController.Amazon = true;
					if (Application.loadedLevelName.Equals (GameController.HELPER_DEMON))
						GameController.CultSite = true;
					if (Application.loadedLevelName.Equals (GameController.CONTRACT_ELDER))
						GameController.MeetupAtJJ = true;
					break;

				case GameController.BATHROOM_NAME:
					if(Application.loadedLevelName.Equals(GameController.MODEST_PROPOSAL))
						GameController.CleanBathroom = true;
					break;

				case GameController.ALARM_NAME:
					if(Application.loadedLevelName.Equals(GameController.MODEST_PROPOSAL))
						GameController.EarlyRiser = true;
					break;
	
				case GameController.BOOK_NAME:
					if(Application.loadedLevelName.Equals(GameController.MODEST_PROPOSAL))
						GameController.ForbiddenKnowledge = true;
					break;

				case GameController.TRASH_NAME:
					if (Application.loadedLevelName.Equals (GameController.CONTRACT_ELDER))
						GameController.TrashDay = true;
					break;

				case GameController.PORTAL_NAME:
					if (Application.loadedLevelName.Equals (GameController.LUBBOCK_PORTAL))
						GameController.PortalInspector = true;
					if (Application.loadedLevelName.Equals (GameController.CONTRACT_ELDER))
						GameController.ContractWithAGod = true;
					break;

				case GameController.DEMON_NAME:
					if (Application.loadedLevelName.Equals (GameController.HELPER_DEMON))
						GameController.BindingAgreement = true;
					break;

				default:
					break;
				}
			} else {
				NotEnoughTime ();
				Nadir ();
			}
		}
	}
}
