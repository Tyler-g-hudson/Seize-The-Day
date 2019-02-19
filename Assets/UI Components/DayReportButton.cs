using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayReportButton : MonoBehaviour {

	const int MORNING = 0;
	const int EVENING = 1;
	public const int GAME_OVER = 2;

	public static DayReportButton instance;

	public static string morningButtonTitle = "Thanks";
	public static string eveningButtonTitle = "Go To Sleep";
	public static string gameOverButtonTitle = "Return to Start";
	public static string playAgainButtonTitle = "Play Again";

	public AudioClip music1;
	public AudioClip music2;
	public AudioClip music3;
	public AudioClip music3MoreA;
	public AudioClip music3MoreB;

	public AudioClip sfxAlarm1;
	public AudioClip sfxAlarm2;

	static Text textBox;
	Button reportButton;

	public static int morningOrEvening = MORNING;

	void Awake () {
		instance = this;
		textBox = gameObject.GetComponentInChildren<Text> ();
		reportButton = GetComponent<Button> ();
		music1 = ((GameObject) Resources.Load ("music1")).GetComponent<AudioSource> ().clip;
		music2 = ((GameObject)Resources.Load ("music2")).GetComponent<AudioSource> ().clip;
		music3 = ((GameObject)Resources.Load ("music3")).GetComponent<AudioSource> ().clip;
		music3MoreA = ((GameObject)Resources.Load ("music3moreA")).GetComponent<AudioSource> ().clip;
		music3MoreB = ((GameObject)Resources.Load ("music3moreBLOOP")).GetComponent<AudioSource> ().clip;

		sfxAlarm1 = ((GameObject)Resources.Load ("alarm")).GetComponent<AudioSource> ().clip;
		sfxAlarm2 = ((GameObject)Resources.Load ("alarm2")).GetComponent<AudioSource> ().clip;
	}

	void Start () {
		updateReportText (morningButtonTitle);
	}

	public static void updateButtonPlayAgain()
	{
		textBox.text = playAgainButtonTitle;
	}	

	public static void updateButtonGameOver()
	{
		textBox.text = gameOverButtonTitle;
	}

	public void updateReportText (string desiredText) {
		textBox.text = desiredText;
	}

	public void onButtonPress() {
		switch (morningOrEvening) {
		case MORNING:
			morningReportButtonPressed ();
			break;
		case EVENING:
			dayReportButtonPressed ();
			break;
		case GAME_OVER:
			gameOverButtonPressed ();
			break;
		default:
			break;
		}
	}

	void gameOverButtonPressed()
	{
		Application.Quit ();
	}

	void DoMorningStuff()
	{
		DayReport.instance.performMorningReport ();
		GameController.TimeMinutes = 30;
		if (GameController.EarlyRiser)
			GameController.TimeMinutes += 15;
		updateReportText (morningButtonTitle);
		morningOrEvening = MORNING;
	}

	void BrandNewDay()
	{
		if (GameController.CurrentEvent.Equals (GameController.PERFORMANCE_REVIEW)) {
			//Load MARGARET EVENT
			Application.LoadLevel (GameController.MARGARET_ACCOUNTING);
			GameController.CurrentEvent = (GameController.MARGARET_ACCOUNTING);
			GameController.instance.PlayMusic (music1);
		} else if (GameController.Amazon) {
			//Load MODEST PROPOSAL
			GameController.Amazon = false;
			Application.LoadLevel (GameController.MODEST_PROPOSAL);
			GameController.CurrentEvent = GameController.MODEST_PROPOSAL;
			GameController.instance.PlayMusic (music1);
		} else if (GameController.ForbiddenKnowledge) {
			//Load Ritual
			GameController.ForbiddenKnowledge = false;
			Application.LoadLevel (GameController.DARK_RITUAL);
			GameController.CurrentEvent = GameController.DARK_RITUAL;
			GameController.instance.PlayMusic (music1);
		} else if (GameController.CurrentEvent.Equals (GameController.DARK_RITUAL)) {
			//Load Lubbock
			Application.LoadLevel (GameController.LUBBOCK_PORTAL);
			GameController.CurrentEvent = GameController.LUBBOCK_PORTAL;
			GameController.instance.PlayMusic (music2);
		} else if (GameController.PortalInspector) {
			GameController.PortalInspector = false;
			Application.LoadLevel (GameController.HELPER_DEMON);
			GameController.CurrentEvent = GameController.HELPER_DEMON;
			GameController.instance.PlayMusic (music2);
		} else if (GameController.CultSite && GameController.BindingAgreement) {
			GameController.CultSite = false;
			GameController.BindingAgreement = false;
			Application.LoadLevel (GameController.CONTRACT_ELDER);
			GameController.CurrentEvent = GameController.CONTRACT_ELDER;
			GameController.instance.PlayMusic (music2);
		} else if (GameController.ContractWithAGod){
			Bathroom.isChaos = true;
			GameController.ContractWithAGod = false;
			Application.LoadLevel (GameController.SIBLING_RIVALRY);
			GameController.CurrentEvent = GameController.SIBLING_RIVALRY;
			GameController.instance.PlayMusic (music3MoreA);
			Invoke ("PlayPartB", music3MoreA.length);
		} else if (GameController.CurrentEvent.Equals(GameController.SIBLING_RIVALRY))
		{
			Application.LoadLevel (GameController.HUMAN_SUFFERING);
			GameController.CurrentEvent = GameController.HUMAN_SUFFERING;
			GameController.instance.PlayMusic (music3MoreA);
			Invoke ("PlayPartB", music3MoreA.length);
		} else {
			//Load Random Event
			Application.LoadLevel (Application.loadedLevel);
			switch(Random.Range(0,13)){
			case 0:
				GameController.CurrentEvent = GameController.BANK_VISIT;
				break;
			case 1:
				GameController.CurrentEvent = GameController.TRIP_DMV;
				break;
			case 2:
				GameController.CurrentEvent = GameController.MEDICAL_EXAM;
				break;
			case 3:
				GameController.CurrentEvent = GameController.WORKING_OVERTIME;
				break;
			case 4:
				GameController.CurrentEvent = GameController.DENTAL_CLEANING;
				break;
			case 5:
				GameController.CurrentEvent = GameController.GOOD_DAY;
				break;
			case 6:
				GameController.CurrentEvent = GameController.NETFLIX_MARATHON;
				break;
			case 7:
				GameController.CurrentEvent = GameController.YARD_WORK;
				break;
			case 8:
				GameController.CurrentEvent = GameController.CLEANING_SPOONS;
				break;
			case 9:
				GameController.CurrentEvent = GameController.BAD_NEWS;
				break;
			case 10:
				GameController.CurrentEvent = GameController.POKER_NIGHT;
				break;
			case 11:
				GameController.CurrentEvent = GameController.DANCING;
				break;
			case 12:
				GameController.CurrentEvent = GameController.SOUP_KITCHEN;
				break;
			case 13:
				GameController.CurrentEvent = GameController.BAD_SERVICE;
				break;
			default:
				break;
			}
			GameController.instance.PlayMusic (music1);
		}

		DoMorningStuff ();
	}

	void dayReportButtonPressed () {
		DayReport.instance.refreshTextBox ();
		GameController.DayNum++;
		//Other end of day stuff

		//Determine Next Event
		GameController.instance.PlaySFX(sfxAlarm1);
		BrandNewDay();
	}

	void morningReportButtonPressed () {
		DayReportGroup.instance.deactivateDayReport ();
		DayReport.instance.refreshTextBox ();
		LogText.instance.refreshTextBox ();
		morningOrEvening = EVENING;
		updateReportText (eveningButtonTitle);
		NextDayButton.instance.setInteractable(true);
	}

	void PlayPartB() {
		GameController.instance.PlayMusic (music3MoreB);
	}
}