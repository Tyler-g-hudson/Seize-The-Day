using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	//PUBLIC VARIABLES
	public static GameController instance;
	public const string RADIO_NAME = "Radio";
	public const string COFFEE_NAME = "Coffee";
	public const string PERCIVAL_NAME = "Cactus";
	public const string COMPUTER_NAME = "LaptopEbay";
	public const string BATHROOM_NAME = "Bathroom-Dirty";
	public const string ALARM_NAME = "Clock";
	public const string BOOK_NAME = "EvilBook";
	public const string CD_NAME = "CD";
	public const string TRASH_NAME = "Trash";
	public const string PORTAL_NAME = "Clothes";
	public const string DEMON_NAME = "Cat";

	public const string TITLE_SCREEN = "TitleScreen";
	public const string CREDITS_SCREEN = "Credits";
	public const string PERFORMANCE_REVIEW = "PerformanceReview";
	public const string MARGARET_ACCOUNTING = "Margaret";
	public const string MODEST_PROPOSAL = "ModestProposal";	
	public const string DARK_RITUAL = "DarkRitual";
	public const string LUBBOCK_PORTAL = "Lubbock";
	public const string HELPER_DEMON = "HelperDemon";
	public const string CONTRACT_ELDER = "Contract";
	public const string SIBLING_RIVALRY = "SiblingRivalry";
	public const string HUMAN_SUFFERING = "HumanSuffering";
	public const string BANK_VISIT = "BankVisit";
	public const string TRIP_DMV = "TripDMV";
	public const string MEDICAL_EXAM = "MedicalExam";
	public const string WORKING_OVERTIME = "WorkingOvertime";
	public const string DENTAL_CLEANING = "DentalCleaning";
	public const string GOOD_DAY = "AGoodDay";
	public const string NETFLIX_MARATHON = "NetflixMarathon";
	public const string YARD_WORK = "YardWork";
	public const string CLEANING_SPOONS = "CleaningSpoons";
	public const string BAD_NEWS = "BadNewsAgain";
	public const string POKER_NIGHT = "PokerNight";
	public const string DANCING = "Dancing";
	public const string SOUP_KITCHEN = "VolunteerAtSoupKitchen";
	public const string BAD_SERVICE = "BadService";


	//PRIVATE VARIABLES
	private static int dayNum = 1;
	private static int timeHours = 0;
	private static int timeMinutes = 30;
	private static int happiness;
	private static int cleanliness;
	private static int sanity;
	private static string currentEvent;

	private int coffee = 0;
	private static bool day1Radio = false;
	private static int percival = 0;
	private static bool amazonBook = false;
	private static bool cleanBathroom = false;
	private static bool earlyRiser = false;
	private static bool forbiddenKnowledge = false;
	private static bool trashDay = false;
	private static bool portalInspector = false;
	private static bool cultSite = false;
	private static bool bindingAgreement = false;
	private static bool meetupAtJJ = false;
	private static bool contractWithAGod = false;

	bool fade = false;

	//SOUND SOURCES
	public AudioSource musicSource;
	public AudioSource sfxSource;

	//ACCESSORS
	static public int DayNum
	{
		get
		{ 
			return dayNum;
		}
		set
		{
			if (value > 0) {
				dayNum = value;
				DayText.instance.updateDateText();
			}
			else {
			}//NEGATIVE DAY ERROR
		}
	}

	static public int TimeHours
	{
		get
		{ 
			return timeHours;
		}
		set
		{
			if (value > 0)
				timeHours = value;
			else
				timeHours = 0;
		}
	}	

	static public int TimeMinutes
	{
		get
		{ 
			return timeMinutes;
		}
		set
		{
			if (value > 0) {
				timeMinutes = value;
				TimeText.instance.updateTimeText ();
			} else {
				timeMinutes = 0;
				TimeText.instance.updateTimeText ();
			}
		}
	}	

	static public int Happiness
	{
		get
		{ 
			return happiness;
		}
		set
		{
			happiness = value;
			Stat1Text.instance.updateStatValue (happiness);
		}
	}	

	static public int Cleanliness
	{
		get
		{ 
			return cleanliness;
		}
		set
		{
			cleanliness = value;
			Stat2Text.instance.updateStatValue (cleanliness);
		}
	}	

	static public int Sanity
	{
		get
		{ 
			return sanity;
		}
		set
		{
			sanity = value;
			Stat3Text.instance.updateStatValue (sanity);
		}
	}

	static public bool Day1Radio
	{
		get
		{ 
			return day1Radio;
		}
		set 
		{
			day1Radio = value;
		}
	}

	static public string CurrentEvent
	{
		get
		{ 
			return currentEvent;
		}
		set 
		{
			//IFS AND SHIT
			currentEvent = value;
		}
	}

	static public int Percival
	{
		get
		{ 
			return percival;
		}
		set
		{
			percival = value;
		}
	}

	static public bool Amazon
	{
		get
		{ 
			return amazonBook;
		}
		set
		{ 
			amazonBook = value;
		}
	}

	static public bool CleanBathroom
	{
		get
		{ 
			return cleanBathroom;
		}
		set
		{ 
			cleanBathroom = value;
		}
	}

	static public bool EarlyRiser
	{
		get
		{ 
			return earlyRiser;
		}
		set
		{ 
			earlyRiser = value;
		}
	}

	static public bool ForbiddenKnowledge
	{
		get {
			return forbiddenKnowledge;
		}
		set{ 
			forbiddenKnowledge = value;
		}
	}

	static public bool TrashDay
	{
		get{
			return trashDay;
		}
		set{
			trashDay = value;
		}
	}

	static public bool PortalInspector
	{
		get{
			return portalInspector;
		}
		set
		{ 
			portalInspector = value;
		}
	}

	static public bool CultSite
	{
		get{
			return cultSite;
		}
		set
		{ 
			cultSite = value;
		}
	}

	static public bool BindingAgreement
	{
		get{
			return bindingAgreement;
		}
		set
		{ 
			bindingAgreement = value;
		}
	}

	static public bool MeetupAtJJ
	{
		get{
			return meetupAtJJ;
		}
		set
		{ 
			meetupAtJJ = value;
		}
	}

	static public bool ContractWithAGod
	{
		get{
			return contractWithAGod;
		}
		set
		{ 
			contractWithAGod = value;
		}
	}



	void Awake(){
		if (GameObject.FindWithTag ("gameManager"))
			Destroy (this.gameObject);
		else
			this.gameObject.tag = "gameManager";
		DontDestroyOnLoad(transform.gameObject);
		if (CurrentEvent == null)
			CurrentEvent = Application.loadedLevelName;

		musicSource = ((GameObject) Instantiate (Resources.Load ("Music Source"))).GetComponent<AudioSource> ();
		musicSource.transform.parent = transform;
		musicSource.Play ();
		sfxSource = ((GameObject) Instantiate (Resources.Load ("SFX Source"))).GetComponent<AudioSource> ();
		sfxSource.transform.parent = transform;
	}
	
	void Start () {
		instance = this;
	}

	void Update(){
		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();
		if (fade) {
			musicSource.volume -= .02f;
			if (musicSource.volume <= 0.05f) {
				musicSource.Stop ();
				musicSource.volume = 1;
				fade = false;
			}
		}
	}

	public void UpdateStats(int happy = 0, int clean = 0, int sane = 0, int time = 0)
	{
		TimeMinutes -= time;
		Happiness += happy;
		Cleanliness += clean;
		Sanity += sane;
	}

	public void DrinkCoffee()
	{
		coffee++;
	}

	public bool CaffineHigh()
	{
		if (coffee >= 3)
			return true;
		return false;
	}

	public void PlayMusic (AudioClip desiredMusic) {
		musicSource.clip = desiredMusic;
		musicSource.Play ();
	}

	public void StopMusic () {
		fade = true;
	}

	public void PlaySFX (AudioClip desiredSFX) {
		sfxSource.clip = desiredSFX;
		sfxSource.Play ();
	}
}
