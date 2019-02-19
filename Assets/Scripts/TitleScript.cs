using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour {


	//PUBLIC VARIABLES
	public Sprite highlightSprite;
	public Sprite nadirSprite;

	public bool startButton = false;

	//SET IN THE EDITOR
	public string hoverText = "Default String";


	// Use this for initialization
	void Start () {
		if (hoverText.Equals("Default String") == true) {
			hoverText = "Default String for " + this.gameObject.name;
		}
	}

	void UpdateHoverText()
	{
		//hoverTextBox.text = hoverText;
		//or Call to MouseOverText.cs function
		MouseOverText.instance.setMouseOverText(hoverText);
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

	void OnMouseEnter()
	{
		UpdateHoverText ();
		Highlight ();
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
		if (startButton)
			Application.LoadLevel (GameController.PERFORMANCE_REVIEW);
		else
			Application.LoadLevel (GameController.CREDITS_SCREEN);
	}
		
}
