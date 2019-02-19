using UnityEngine;
using System.Collections;

public class DayReport : Log {

	public static DayReport instance;

	int baseHappinessLoss = 10;
	int baseLucidityLoss = 5;
	int baseHygieneLoss = 10;

	string morningGreeting = "Good Morning!";
	string eveningGreeting = "For the rest of the day...";

	protected override void Awake () {
		base.Awake ();
		instance = this;
	}

	protected override void Start () {
		base.Start ();
		base.refreshTextBox ();
		performMorningReport ();
	}

	public override void updateTextBox (string input) {
		base.updateTextBox (input);
		DayReportSB.instance.updateReportScrollPosition (1f);
	}

	void TriggerEnding()
	{
		refreshTextBox ();
		GameController.DayNum++;

		if (!GameController.MeetupAtJJ && Cactus.isDead)
			updateTextBox ("Chaos is a Ladder\n\nHaving taken over the corrupt company and thusly, the world, the Elder God grants you your promised promotion. You are now the assistant to the liaison of the overlord. You can’t help but feel like you could have gotten more out of the deal. Life is “okay,” you suppose.");
		else if (GameController.MeetupAtJJ && Cactus.isDead)
			updateTextBox ("I like the Cut of your Jib\n\n As you pull into the parking lot, you can see the elder god waiting for you. “Hey man, you got Margaret with you? I’m starving.” By his side you see his lacky and your former supervisor, Figaro Newton on his cell phone. Just seeing him fills you with rage. With the unshakeable confidence of a man who does not fear death, you shout, “I’m pretty hungry myself and I’m done eating leftovers. Now, Helper Demon!” Helper demon sinks his fangs into Figaro’s neck, draining his soul. You feel the wicked man’s power transfer to you.\n\nThe Elder God quakes and lightning streaks across the sky. It roars: “You dare defy me!?” \n\nAnd dare you did. The Elder God smacks you around a bit, but you get a few good licks in. The Elder God is impressed by your chutzpah and decides to spare you and Margaret. You live happily ever after as its demonic lieutenants.");
		else if (GameController.MeetupAtJJ && !Cactus.isDead)
			updateTextBox (" As you pull into the parking lot, you can see the elder god waiting for you. “Hey man, you got Margaret with you? I’m starving.” By his side you see his lacky and your former supervisor, Figaro Newton on his cell phone. Just seeing him fills you with rage. With the unshakeable confidence of a man who does not fear death, you shout, “I’m pretty hungry myself and I’m done eating leftovers. Now, Helper Demon!” Helper demon sinks his fangs into Figaro’s neck, draining his soul. You feel the wicked man’s power transfer to you. “How’s that for initiative,” you ask with a smirk.\n\nThe Elder God quakes and lightning streaks across the sky. It roars: “You dare not defy me!?” \n\nBut you dared. The Elder God lays down a hate-filled pummeling upon your weak, human body. Just before it strikes the final, fatal blow, a javelin of brilliant light erupts from the direction of your apartment. The Elder God howls in agony as it is pierced by what appears to be a spine from a cactus. You spot a glowing cactus against the darkened sky, it’s Percival! He begins to spin like a top, launching more spines at machine gun speeds. The Elder God recoils at the assault and opens a portal, back to Lubbock. “I can’t believe you betrayed me, not cool man!” he shouts as he makes his retreat. \n\nAs the dusty settles, you are joined by Percival. He explains that for years he has been storing the love and care you have given him in his plump and juicy innards, and in your moment of need, he used that immense power to gain sentience. With the ancient evil gone, the world ripe for reshaping. With your courage, Percival’s power, and Margaret’s ever-watchful auditing eye, you recreate the earth in your image. \n\f");
		DayReportButton.updateButtonPlayAgain();
		DayReportButton.morningOrEvening = DayReportButton.GAME_OVER;
	}

	void TriggerPromotionEnding()
	{
		refreshTextBox ();
		GameController.DayNum++;

		updateTextBox ("You’re Promoted\n\nFigaro Newton stops by your cubicle. He looks at you with pity and says, “Larry, I’m giving you a promotion.” \n\nYour name’s not Larry. That’s fine you guess, but you still feel empty inside. \n\n GAME OVER");
		DayReportButton.updateButtonGameOver();
		DayReportButton.morningOrEvening = DayReportButton.GAME_OVER;
	}

	public void performDayReport () {
		updateTextBox (eveningGreeting);
		switch (GameController.CurrentEvent) {
		case GameController.PERFORMANCE_REVIEW:
			if (GameController.TimeMinutes >= 15 || GameController.Day1Radio) {
				updateTextBox ("Despite the horrendous traffic, you find an alternative route to work and make it there just in time for your performance review.");

			} else {
				updateTextBox ("Traffic is especially horrendous today. The Radio DJ mentions a careless individual has blocked off the highway in order to propose to his girlfriend. You see the police handcuff a weeping man and a visibly embarrassed woman as you pass the scene. You can see the boss with a look of disapproval as you pass his office");
				GameController.Happiness -= 5;
			}
			updateTextBox ("During the performance review, your supervisor Figaro Newton says despite meeting all his expectations, you need to show more initiative if you want to be promoted to management. When you ask him what he means by that, he laughs and continues without answering the question.");
			if (GameController.Cleanliness < 8) {
				updateTextBox ("He then sniffs and asks, “what’s the smell?” You suspect that it’s you, but you blame it on the air conditioner instead.");
				GameController.Happiness -= 5;
			}
			if (GameController.Sanity < 5) {
				updateTextBox ("You ask if anyone called him Fig Newton when he was a schoolboy. You see deadly seriousness in his eyes as he smiles and says, “Yes.”");
				GameController.Happiness -= 5;
				if(GameController.Sanity < 5)
					GameController.Sanity += 5;
				GameController.Sanity += 5;
			}
			GameController.Happiness -= baseHappinessLoss;
			GameController.Sanity -= baseLucidityLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			break;
		case GameController.MARGARET_ACCOUNTING:
			updateTextBox ("The night gets off to a rocky start, as Margaret, from Accounting, seems confused and annoyed at your retelling of last night’s episode of Sci-fi Channel’s “The Expanse”. They ask if you’re speaking in code. You’re not really sure what what they mean but you nervously nod in agreement. Things really take off as you discuss whether “the martians” are guilty of “war crimes”.");
			if (GameController.Cleanliness > 0) {
				updateTextBox ("Before the night is through, Margaret comments on how white your teeth are and you exchange dental hygiene tips.");
				GameController.Happiness += 10;
			}
			if (GameController.Sanity < 0) {
				updateTextBox ("You offer to accompany her home “just to be safe.” Seeing Margaret fumble with the keys to the apartment door reminds you of a scene from a movie starring Will Smith and Eva Mendes. Confident that you’ve been given the signal, you go in for the goodnight kiss. Margaret is stunned by your boldness. You don your aviator sunglasses and walk away, swagger fully engaged.");
			}
			if (GameController.Sanity < 1) {
				GameController.Happiness += 1;
			}
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss - 5;
			break;
		case GameController.MODEST_PROPOSAL:
			updateTextBox ("You present your proposal for expanding the office’s lavatory, presenting data on traffic during peak usage hours and the increasing frequency of “accident” incidents. Your audience seems preoccupied with texting, writing on their notepads and staring at whatever is going on out the window. Only Margaret seems to be paying attention.");
			if (GameController.Sanity < 5) {
				updateTextBox ("You decide to spice things up by making an impromptu addition. You suggest that the facilities be made unisex. Everyone is impressed by your confident and progressive attitude.");
				GameController.Happiness += 5;
			}
			if (GameController.Cleanliness < 5) {
				updateTextBox ("You finish your proposal and your supervisor, Figaro Newton, notes that you look like you know your way around a scrubbing brush. He approves your proposal and appoints you as the auxiliary janitor. It’s a lateral move.");
				GameController.Happiness -= 10;
				baseHygieneLoss += 5;
			}
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss;
			break;
		case GameController.DARK_RITUAL:
			updateTextBox ("You feel an ancient malevolent power swirl around you as you recite the incantation,. You open yourself to it, letting it flow through you. In your mind’s eye, you see the vastness of the infinite being sucked into singularity. You now understand that though there are many paths to take, there is only one possible destination. \n\nAs your vision ends, you fall to the floor in a heap and your consciousness fades.");
			GameController.Happiness += 50;
			GameController.Sanity -= 25;
			GameController.Percival = 0;
			break;
		case GameController.LUBBOCK_PORTAL:
			updateTextBox ("With a bundle of breakfast tacos in your arms, you find a seat next to Margaret in the breakroom. As you feast, they comment that you seem different today. Between bites, you explain that you’ve had a vision for a whole new world and you’re excited to share it with everyone. She suggests you make a website to spread the word. ");
			if(GameController.Cleanliness < 0){
				updateTextBox("Your new found confidence, devil may care attitude and pungent natural musk have attracted Margaret’s attention. For a moment you see a flair of pure animal magnetism before they recover their senses. ");
				GameController.Happiness+=5;
			}
			break;
		case GameController.HELPER_DEMON:
			updateTextBox ("You’re having so much fun watching the unexpected guest make itself comfortable in your apartment that you never got around to going to work. You wonder if Margaret is allergic to demon cats.");
			if (GameController.Sanity > 10) {
				updateTextBox ("Thankfully you remembered to call in sick to work, so you still have a job. Your boss didn’t know who you were when you called, though. You’re not sure if that’s something you should be worried about. ");
				GameController.Happiness += 5;
			}
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss - 5;
			GameController.Sanity -= baseLucidityLoss;
			break;
		case GameController.CONTRACT_ELDER:
			updateTextBox ("When you arrive at the office, you find Margaret from Accounting in a state of panic. She explains that she's been investigating Figaro Newton for embezzling from the company, but it turns out the corruption goes all the way to the top. She now fears for her life. You take her by the hand and lead her to the door. \n\nShe looks panicked as she asks, “Where are we going?” You turn to her, look her directly in the eye, and answer: “Jamba-Juice.”\n");
			GameController.Sanity -= baseLucidityLoss;
			if (GameController.TrashDay)
				GameController.Cleanliness -= 20;
			break;
		case GameController.SIBLING_RIVALRY:
			updateTextBox ("When you arrive at work, you find an email in your inbox with the subject, “Restructuring.” It goes on to say that due to dramatic changes in the marketplace, management has decided to appoint the Elder God as acting CEO. Your blood boils as you read that Figaro Newton has been designated as liaison to the overlord.");
			if(Cactus.isDead)
				GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss;
			break;
		case GameController.HUMAN_SUFFERING:
			if (GameController.MeetupAtJJ)
				updateTextBox ("You spend most of the day considering your options. On one hand, you risk incurring the wrath of an elder god. On the other, you like Margaret. Like, really, really like her. As you think over the events of the past month, you become more and more enraged. You realize that the joy you have discovered comes not from serving the will of an ancient force of evil, but from finding dedicating yourself to a singular purpose. You decide not to settle for replacing one douchey boss with another. It’s time to seize the day for yourself!");
			else
				updateTextBox ("You spend most of the day considering your options. On one hand, you risk incurring the wrath of an elder god. On the other, Margaret is nice. You went on a date once and that was nice. The more you think over the events of the past month, you realize that you’re happier than you’ve ever been and it’s all thanks to the sense of purpose you’ve found while serving the elder god. You call Margaret and arrange to meet at a nearby Chipotle. ");
			TriggerEnding ();
			break;
		case GameController.BANK_VISIT:
			updateTextBox ("As you’re standing in line, you watch with mild discomfort as a large, bearded man picks a fight with the bank teller in front of you. The big man’s wearing a t-shirt and jean shorts that leave absolutely nothing to the imagination. Unfortunately, due to the belligerent baboon’s bombastic language, you spend your entire evening filling out police reports. You don’t really understand the correlation. \n\nYou have a microwave dinner. ");
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss;
			break;
		case GameController.TRIP_DMV:
			updateTextBox ("DMV experiences are seldom good. You stood in line for four and a half hour, signed 18 forms in triplicate, and stood for three photographs. The entire endeavor was made worthwhile because you are 72.3% sure you convinced at least seven government employees to form a suicide pact. ");
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss;
			break;
		case GameController.MEDICAL_EXAM:
			updateTextBox ("You stopped by the doctor’s and had a routine check up. Vitals and blood work all came back normal. While waiting in the examination room, you are reminded of how uncomfortable the exam table paper is to sit on. You feel like the doctor spends a little too much time touching various parts of you. \n\nYou actually found the smell of the hospital arousing. You felt awkward about that for the rest of the night. ");
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss;
			break;
		case GameController.WORKING_OVERTIME:
			updateTextBox ("You stayed late working on the project. Fortunately you managed to get it in almost on time. Unfortunately your entire evening was spent typing away at your keyboard, but, hey, at least your boss almost called you the right name today.");
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss;
			break;
		case GameController.DENTAL_CLEANING:
			updateTextBox ("You went to visit your overly cheery dentist… who was, of course, unbearably chatty. You have some cavities that need to be filled, and most of your mouth is crooked. They recommend mouthwash. You are unsure how it is supposed to help. The dentist smiles and tells you to keep flossing. You half-heartedly smile back, feeling woefully inadequate as you compare yourself to their perfect teeth.");
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss;
			break;
		case GameController.GOOD_DAY:
			updateTextBox ("You got your tie stuck in your car door when you arrived at the office. You then realized that your keys were locked in your car. Your car was left in neutral and started to roll down a hill. The tie tightened around your neck as your car gained speed. You blacked out.\n\nLet’s hope that tomorrow is a better day. ");
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss;
			break;
		case GameController.NETFLIX_MARATHON:
			updateTextBox ("Your day at work was lackluster, but you got home, heated up some leftovers, and got three episodes into “Super-Powered Bisexual Prisoner Vigilantes” before your internet failed. But at least you got to see the main character’s boobies. And three dicks. ");
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss;
			break;
		case GameController.YARD_WORK:
			updateTextBox ("You spent your entire day cutting grass, cleaning the gutter, raking the leaves, trimming the hedges, planting a shrubbery, weeding the garden, aerating the grass, trimming the tree, edging the grass, planting new grass, removing an old stump, planting a small oak, removing excess branches, cutting around the fences, putting up new fences, making a path by planting another shrubbery next to the first shrubbery, digging a hole for a pond, filling the pond with water, getting a urinating angel for the pond, grabbing a glass of lemonade, removing moles from your face, planting new flowers in your garden, picking the dirt out from underneath your nails, and generally giving up all hope. ");
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss;
			break;
		case GameController.CLEANING_SPOONS:
			updateTextBox ("You spend the entire night binge-watching beach volleyball and cleaning your spoons. You realize that you will only get a couple hours of sleep before work. You gaze upon your dripping spoons, feeling unfulfilled and a little sticky from spoon polish.");
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss;
			break;
		case GameController.BAD_NEWS:
			updateTextBox ("You spend three hours on the phone with your dear old mom. She apparently has Alzheimers.  Again; For the third time this year. ");
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss;
			break;
		case GameController.POKER_NIGHT:
			updateTextBox ("You got home right after work with beer in one hand and snacks in the other. You set up your poker table, dimmed the lights, and pulled out cigars. \n\nNo one showed up. ");
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss;
			break;
		case GameController.DANCING:
			updateTextBox ("You got home after work, propped your feet up, and watched “Dancing with the Tzars.” You fell asleep on the couch. ");
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss;
			break;
		case GameController.SOUP_KITCHEN:
			updateTextBox ("On your way to the soup kitchen, a few fire trucks passed you by. You didn’t think much of it at the time. You arrived at the soup kitchen: a smoldering lump in the middle of the block. There were a lot of ugly people weeping and moaning all around. The firemen shook their heads as they looked into a pile of rubble. The news was already on the scene. They claimed the death toll to be around eleven. Another day wasted.");
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss;
			break;
		case GameController.BAD_SERVICE:
			updateTextBox ("You arrived at the restaurant, and nobody there spoke your language. You tried ordering, but all you could read from the menu was “H'nglui mglw'nafh cthulhu r'lyeh wgah'nagl fhtagn.” It tasted like French soup. ");
			GameController.Happiness -= baseHappinessLoss;
			GameController.Cleanliness -= baseHygieneLoss;
			GameController.Sanity -= baseLucidityLoss;
			break;
		default:
			Debug.LogError ("No report for day " + GameController.DayNum);
			break;
		}
		StatText.updateAllStatVals ();
		GameController.Percival++;
		if (GameController.Percival >= 3 && !Cactus.isDead) {
			updateTextBox ("Percival has died. You've somehow managed to kill a cactus. Great job.");
			Cactus.isDead = true;
		}
		if (GameController.Happiness <= -100) {
			TriggerPromotionEnding ();
		}
	}

	public void performMorningReport () {
		updateTextBox (morningGreeting);
		switch (GameController.CurrentEvent) {
		case GameController.PERFORMANCE_REVIEW:
			updateTextBox ("I have a performance review this morning with the boss. I should make sure I’m not late.");
			break;
		case GameController.MARGARET_ACCOUNTING:
			updateTextBox ("Accountability.\n Margaret, from accounting, called last night. They asked if you had noticed any “irregularities” recently but you’re not paying attention. You decide that now is the perfect opportunity to ask them out. They agree to dinner at eight.");
			break;
		case GameController.MODEST_PROPOSAL:
			updateTextBox ("A Modest Proposal\n You have been tasked with presenting a proposal for expanding the office lavatories.");
			break;
		case GameController.DARK_RITUAL:
			updateTextBox ("You keep thinking about the mysterious book and the dark ritual in it. You’re not entirely sure what the ritual might do, but it couldn’t be that bad, could it? It’s probably just the product of some teenager’s dark fantasy. Rituals are more superstition than dark else. Life has become ritual, it’s almost dark worth ritual dark of bed ritual. Sometimes dark ritual dark might dark ritual dark ritual.");
			break;
		case GameController.LUBBOCK_PORTAL:
			updateTextBox ("Still Alive\n Today is breakfast taco day at work, better get there before they’re all gone.");
			break;
		case GameController.HELPER_DEMON:
			updateTextBox ("The Help\nA black cat has appeared in your apartment. You assume that it came through the portal to Lubbock since the door and window are closed. You’re more of a dog person, but you suppose it can keep Percival company while you’re at work. It looks at you and says, “Sup?”");
			break;
		case GameController.CONTRACT_ELDER:
			updateTextBox ("You awake at your normal time, remembering that you need to take out the trash. You actually catch yourself looking forward to work because you get to see Margaret from Accounting again. The helper demon’s ears perk up as a deep voice emanates from the portal, “Psst, hey man. Come over here.");
			break;
		case GameController.SIBLING_RIVALRY:
			if (GameController.MeetupAtJJ)
				updateTextBox ("Last night went better than expected. You and Margaret arrive at the Jamba Juice to find your cult fully assembled. You explain that you’ve summoned the elder god to the mortal plane and how that’s a good thing. Your fellow cultists exchange tips with Margaret on how to adapt to the new world order as the sky is torn asunder and the elder one emerges from its cosmic womb. One of the cultists offers to put her up for the night. You return to your place for the night.");
			else
				updateTextBox ("Your attempts to console Margaret are ineffective as she fears for her life. You try to explain that pretty soon, none of that is going to matter but she doesn’t seem to get it. As the sky is torn asunder and the elder one emerges from its cosmic womb, you feel as thought your point has been made. Margaret flees, leaving behind her berry upbeat smoothy. You take it with you back to your place.");
			if (Cactus.isDead)
				updateTextBox ("You are wake the next morning to find Helper Demon sitting on your face. It looks to Percival’s dying corpse and asks, “Are you going to eat that?” ");
			else
				updateTextBox ("You awake the next morning to a crashing sound. Percival has been knocked from his normal spot. In his place you see Helper Demon. It says, “What? It wasn’t me.” You see no one else in the room.");
			updateTextBox ("Your room seems a little different. The portal to Lubbock has disappeared and you regain access to your closet, which is nice because you were getting a little tired of wearing the same outfit every day. Things are looking a bit overcast outside, you decide to bring an umbrella with you to work today.");
			break;

		case GameController.HUMAN_SUFFERING:
			updateTextBox ("The elder gods are whispering into your eardrums. “You know what would really hit the spot right now? A virgin sacrifice! How about Margaret from Accounting? The affection you’ve sprinkled on her should season her soul nicely.”\n\nYou’re surprised that Margaret is a virgin, but you decide that it doesn’t really bother you. ");
			break;
		case GameController.BANK_VISIT:
			updateTextBox ("Today you need to go to the bank. Should be a quick, if soulless, transaction.\n");
			break;
		case GameController.TRIP_DMV:
			updateTextBox ("Your driver’s license expired seven years ago, so you need to stop by the DMV tonight. You spent most of your day at work yesterday picking out the most remote DMV in the city, and chatted with a dozen people trying to optimize your arrival time. You are determined to not spend more than four hours in line. \n");
			break;
		case GameController.MEDICAL_EXAM:
			updateTextBox ("You need to go to see the doctor today. You cringe at the mere idea the hospital’s smell.\n");
			break;
		case GameController.WORKING_OVERTIME:
			updateTextBox ("You have a big project due today. You feel good about the time frame and think that you might even get it done early.\n");
			break;
		case GameController.DENTAL_CLEANING:
			updateTextBox ("You need to go to the dentist today. You strain to remember the last time you flossed your teeth\nand shutter at the thought of the dentist's drill. ");
			break;
		case GameController.GOOD_DAY:
			updateTextBox ("Today might just be a good day.\n");
			break;
		case GameController.NETFLIX_MARATHON:
			updateTextBox ("Netflix is releasing its newest original series this evening, “Super-Powered Bisexual Prisoner Vigilantes.” You have every intention of marathoning it tonight. ");
			break;
		case GameController.YARD_WORK:
			updateTextBox ("You just remembered: you have a yard! You have a large amount of neglected yard work to do. You should also hide those complaint letters from the Homeowners’ Association. ");
			break;
		case GameController.CLEANING_SPOONS:
			updateTextBox ("You wake up in a cold sweat, remembering the antique spoon set you inherited from your deceased great aunt a year ago. You wonder when the last time was that they were cleaned. \n");
			break;
		case GameController.BAD_NEWS:
			updateTextBox ("Your father sent you an email asking that you call your mother today. \n");
			break;
		case GameController.POKER_NIGHT:
			updateTextBox ("You decide to invite all your friends at the office to a large game of poker. You’re excited just thinking about all the fun you’ll have tonight.");
			break;
		case GameController.DANCING:
			updateTextBox ("You wake up feeling restless. You want to go dancing. Yes, absolutely, tonight you are going to go out dancing. Maybe you’ll even meet somebody.");
			break;
		case GameController.SOUP_KITCHEN:
			updateTextBox ("You feel like being generous and volunteering at the local soup kitchen today. You know that a few co-workers volunteer there on a semi-regular basis. Perhaps it would give you an edge in getting that promotion.  ");
			break;
		case GameController.BAD_SERVICE:
			updateTextBox ("A new restaurant opened up just recently downtown. You decide that tonight would be a good night to go out on the town and try new things. ");
			break;
		default:
			Debug.LogError ("No morning report for day " + GameController.DayNum);
			break;
		}
		StatText.updateAllStatVals ();
	}
}