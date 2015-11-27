using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace Teamod_2
{
	public partial class MainForm : Form
	{
		
		List<List<ListViewItem>> RoomsLABELS = new List<List<ListViewItem>>(0);
		static string[][] Rooms = new string[][] {
			new string[] {"00 - The Dark Margin","01 - Loop Demo"},
			new string[] {"00 - The Empty Realm","01 - Roxas's Room","02 - The Usual Spot","03 - Back Alley","04 - Sandlot","05 - Sandlot (Day 4)","06 - Market Street: Station Heights","07 - Market Street: Tram Common","08 - Station Plaza","09 - Central Station","0A - Sunset Terrace","0B - Sunset Station","0C - Sunset Hill","0D - The Woods","0E - The Old Mansion","0F - Mansion: Foyer","10 - Mansion: Dining Room","11 - Mansion: Library","12 - Mansion: The White Room","13 - Mansion: Basement Hall","14 - Mansion: Basement Hall (In the Fire Wall)","15 - Mansion: Computer Room","16 - Mansion: Basement Corridor","17 - Mansion: Pod Room","18 - On the Train","19 - The Tower","1A - Tower: Entryway","1B - Tower: Sorcerer's Loft","1C - Tower: Wardrobe","1D - Tower: Star Chamber","1E - Tower: Moon Chamber","1F - Tower: Wayward Stairs","20 - Station of Serenity","21 - Station of Calling","22 - Station of Awakening","23 - The Mysterial Train","24 - Tunnelway","25 - Underground Concourse","26 - Tower: Wayward Stairs","27 - Tower: Wayward Stairs","28 - Between and Betwix"},
			new string[] {"00 - Beach","01 - Main Island: Ocean's Road","02 - Main Island: Shore"},
			new string[] {"00 - Villain's Vale","01 - The Dark Depths","02 - The Great Maw","03 - Crystal Fissure","04 - Castle Gate","05 - Ansem's Study","06 - Postern","07 - Restoration Site (Before Destruction)","08 - Bailey (Before Destruction)","09 - Borough","0A - Marketplace","0B - Corridors","0C - Heartless Manufactory","0D - Merlin's House","0E - Castle Oblivion","0F - Ansem's Study (Before Xehanort took over)","10 - Ravine Trail","11 - The Great Maw (1,000 Heartlesses Conditions)","12 - Restoration Site (After Destruction)","13 - Bailey (After Destruction)","14 - Corridors (Sealed)","15 - Cavern of Remembrance: Depths","16 - Cavern of Remembrance: Mining Area","17 - Cavern of Remembrance: Engine Chamber","18 - Cavern of Remembrance: Mineshaft","19 - Transport to Remembrance","1A - Garden of Assemblage","1B - The Underground","1C - Memory's Contortion (Xemnas I Battle Area) (BSOD!)","1D - The World of Nothing (Twilight Xemnas Battle Area) (BSOD!)","1E - Hall of Empty Melodies (Bottom Part) (BSOD!)","1F - ?? (BSOD!)","20 - Front Mansion","21 - Station of Remembrance","22 - Destiny Islands","23 - Addled Impasse (BSOD!)","24 - Mansion: Basement Hall (In the Fire Wall) (BSOD!)","25 - Havoc's Divide (BSOD!)","26 - Station of Oblivion"},
			new string[] {"00 - Entrance Hall","01 - Parlor","02 - Belle's Room","03 - Beast's Room","04 - Ballroom (Normal)","05 - Ballroom (Covered in Darkness)","06 - Courtyard","07 - The East Wing","08 - The West Hall","09 - The West Wing","0A - Dungeon","0B - Undercroft","0C - Secret Passage","0D - Bridge (Normal)","0E - Ballroom","0F - Bridge (Xaldin Battle Area)"},
			new string[] {"00 - The Coliseum","01 - Colliseum Gates (Normal)","02 - Colliseum Gates (Destroyed) (Day)","03 - Underworld Entrance","04 - Colliseum Foyer","05 - Valley of the Dead","06 - Hades' Chamber","07 - Cave of the Dead: Entrance","08 - Well of Captivity","09 - The Underdrome","0A - Cave of the Dead: Inner Chamber","0B - Underworld Caverns: Entrance","0C - The Lock","0D - The Underdrome","0E - Colliseum Gates (Destroyed) (Night)","0F - Cave of the Dead: Passage","10 - Underworld Caverns: The Lost Road","11 - Underworld Caverns: Atrium","12 - Coliseum Gates (Hydra Battle Area)","13 - The Underdrome","BD - The Pain and Panic Cup","BE - The Cerberus Cup","BF - The Titan Cup","C0 - The Goddess of Fate Cup","C1 - The Pain and Panic Paradox Cup","C2 - The Cerberus Paradox Cup","C3 - The Titan Paradox Cup","C4 - The Hades Paradox Cup"},
			new string[] {"00 - Agrabah","01 - Bazaar","02 - The Peddler's Shop (1st Visit)","03 - The Palace","04 - Vault","05 - Above Agrabah (Jafar Battle Area)","06 - Palace Walls","07 - The Cave of Wonders: Entrance","08 - Freeze","09 - The Cave of Wonders: Stone Guardians","0A - The Cave of Wonders: Treasure Room","0B - Ruined Chamber","0C - The Cave of Wonders: Valley of Stone","0D - The Cave of Wonders: Chasm of Challenges","0E - Sandswept Ruins","0F - The Peddler's Shop (2nd Visit)"},
			new string[] {"00 - Bamboo Grove","01 - Encampment","02 - Checkpoint","03 - Mountain Trail","04 - Village","05 - Village Cave","06 - Ridge","07 - Summit","08 - Imperial Square","09 - Palace Gate","0A - Antechamber","0B - Throne Room","0C - Village (Repaired)"},
			new string[] {"00 - The Hundred Acre Wood","01 - Starry Hill","02 - Pooh Bear's House","03 - Rabbit's House","04 - Piglet's House","05 - Kanga's House","06 - A Windsday Tale","07 - The Honey Hunt","08 - Blossom Valley","09 - The Spooky Cave"},
			new string[] {"00 - Pride Rock","01 - Stone Hollow","02 - The King's Den","03 - Wildebeest Valley (Present)","04 - The Savannah","05 - Elephant Graveyard","06 - Gorge","07 - Wastelands","08 - Jungle","09 - Oasis","0A - Pride Rock (Restored)","0B - Oasis (Night)","0C - Overlook","0D - Peak","0E - Scar's Darkness","0F - The Savannah (Groundshaker Battle Area)","10 - Wildebeest Valley (Past)"},
			new string[] {"00 - Triton's Throne","01 - Ariel's Grotto","02 - Undersea Courtyard (Day)","03 - Undersea Courtyard (Dawn)","04 - The Palace: Performace Hall","05 - Sunken Ship","06 - The Shore (Day)","07 - The Shore (Night)","08 - The Shore (Dawn)","09 - Wrath of the Sea","0A - Wedding Ship"},
			new string[] {"00 - Audience Chamber","01 - Library","02 - Colonnade","03 - Courtyard","04 - The Hall of the Cornerstone (With Thorns)","05 - The Hall of the Cornerstone (Normal)","06 - Gummi Hangar","07 - Gathering Place"},
			new string[] {"00 - Cornerstone Hill","01 - Pier","02 - Waterway","03 - Wharf","04 - Lilliput","05 - Building Site","06 - Scene of the Fire","07 - Mickey's House","08 - Villian's Vale (Black & White)"},
			new string[] {"00 - Halloween Town Square","01 - Dr. Finkelstein's Lab","02 - Graveyard","03 - Curly Hill","04 - Hinterlands","05 - Yuletide Hill","06 - Candy Cane Lane","07 - Christmas Tree Plaza","08 - Santa's House","09 - Toy Factory: Shipping and Receiving","0A - Toy Factory: The Wrapping Room"},
			new string[] {"00 - World Map","01 - DUMMY"},
			new string[] {"00 - Rampart","01 - Harbor","02 - Town","03 - The Interceptor","04 - The Interceptor: Ship's Hold","05 - The Black Pearl","06 - The Black Pearl: Captain's Stateroom","07 - The Interceptor","08 - Isla de Muerta: Rock Face","09 - Isla de Muerta: Cave Mouth","0A - Isla de Muerta: Treasure Heap","0B - Ship Graveyard: The Interceptor's Hold","0C - Isla de Muerta: Powder Store","0D - Isla de Muerta: Moonlight Nook","0E - Ship Graveyard: Seadrift Keep","0F - Ship GraveYard: Seadrift Row","10 - Isla de Muerta: Rock Face","11 - Isla de Muerta: Treasure Heap","12 - The Black Pearl","13 - The Black Pearl","14 - The Black Pearl","15 - The Interceptor","16 - The Interceptor","17 - The Black Pearl: Captain's Stateroom","18 - Harbor","19 - Isla de Muerta: Rock Face"},
			new string[] {"00 - Pit Cell","01 - Canyon","02 - Game Grid","03 - Dataspace","04 - I/O Tower: Hallway","05 - I/O Tower: Communications Room","06 - Simulation Hangar","07 - Solar Sailer Simulation","08 - Central Computer Mesa","09 - Central Computer Core","0A - Solar Sailer Simulation"},
			new string[] {"00 - Where Nothing Gathers","01 - Alley to Between","02 - Fragment Crossing","03 - Memory's Skyscraper","04 - The Brink of Despair","05 - The Soundless Prison","06 - Nothing's Call","07 - Crooked Ascension (Bottom Part)","08 - Crooked Ascension (Top Part)","09 - Twilight's View","0A - Hall of Empty Melodies (Bottom Part)","0B - Hall of Empty Melodies (Top Part)","0C - Naught's Skyway","0D - Proof of Existance","0E - Havoc's Divide","0F - Addled Impasse","10 - Naught's Approach","11 - Ruin and Creation's Passage","12 - The Alter of Naught (No Door to The World of Nothing)","13 - Memory's Contortion (Xemnas I Battle Area)","14 - The World of Nothing (Twilight Xemnas Battle Area)","15 - Station of Awakening (Roxas Battle Area)","16 - The World of Nothing (Armored Dragon Battle Area)","17 - The World of Nothing (Armor Xemnas II Battle Area)","18 - The World of Nothing (Armor Xemnas I Battle Area)","19 - The World of Nothing (Core Area)","1A - The World of Nothing (Twin Cannons)","1B - The World of Nothing (First Area)","1C - The World of Nothing (Second Area)","1D - Alter of Naught (No Kingdom Hearts Moon)"}};
		
		List<List<List<ListViewItem>>> AllEventsLABELS = new List<List<List<ListViewItem>>>(0);
		static readonly string[][][] AllEvents = new string[][][] {
			new string[][] {
				new string[] {"00 - No Event","33 - Letter","39 - At the Dark Margin","3A - FMV Ending & Credits","3C - The Gathering","3D - Birth by Sleep"},
				new string[] {"00 - No Event","38 - Menu Trailer"}},new string[][] {
				new string[] {"00 - No Event","33 - The Name is Naminé"},
				new string[] {"00 - No Event","34 - Connected Dreams","35 - The Dream That Will Become the Key","36 - Dream of a Promise","37 - Farewell Dream","38 - Waking From the Dream","39 - The Usual Awakening","3A - Waking From the Illusion","3B - Uncertain Awakening","3C - Unclear Awakening","3D - Overlapping Awakenings"},
				new string[] {"00 - No Event","01 - A Message From Pence and Olette","02 - Tutorial 5 - Saving","3F - Something's Been Stoled","40 - Photographs of Memories","41 - We'll Go to the Beach!","42 - The Letter Hayner Left Behind","43 - Sorry.","44 - Summer Vacation Homework","45 - Two Days Left of Summer Vacation","46 - The World Starts to Fade","47 - Falling Down","48 - Kairi Disappeared Into the Darkness","A7 - Missing","124 - The 7 Wonders of Twilight Town"},
				new string[] {"00 - No Event","01 - Getting the Twilight Town Map","03 - Axel Under Orders","04 - Axel's Grief","05 - Nostalgic Town?","49 - Nobody Wave Battle","4A - The Sunset's Radiance","4B - The Mysterious Man","138 - DiZ's Guidance"},
				new string[] {"00 - No Event","01 - Leave the Rest to Me!","12 - Sora and Seifer's Argument","4C - Choose Your Stuggle Weapon","4D - Tutorial 4 - Fighting","4E - Seifer I Battle","4F - Dusk Battle","50 - Nobody Waves Battle","51 - Versus Seifer","52 - Decisive Battle at the Plaza","53 - To the Original World","B5 - Seifer II Battle","B6 - Hayner Battle (Struggle Competition)","B7 - Setzer Battle (Struggle Competition)","B8 - Seifer Battle (Struggle Competition)","EA - Mysterious Enemies Appear","108 - The Girl's Voice","160 - Saix Make Bewilder"},
				new string[] {"00 - No Event","01 - Midsummer Struggle Battle","03 - 1st Match: VS Hayner","04 - The Finals","05 - The Invitation of the Champion","54 - Hayner Struggle Battle","55 - Vivi Struggle Battle","56 - Triple Dusks Battle","57 - Axel I Battle","58 - Setzer Struggle Battle","118 - Finish the Fight","11A - The Approaching Enemy","11B - Axel Appears","11C - A Heart's Outcry","11E - Roxas's Victory"},
				new string[] {"00 - No Event","01 - The Promise With Hayner","02 - Encounter With the Girl","0C - The Story of a Party-Time Job","59 - Cargo Climb (Roxas)","5A - Grandstander (Roxas)","5B - Mail Delivery (Roxas)","A8 - The Promise Made Yesterday","C1 - Cargo Climb (Sora)","C2 - Grandstander (Sora)","C3 - Mail Delivery (Sora)"},
				new string[] {"00 - No Event","01 - The Road to the Mansion","03 - Talk to the Clerk","5F - Tutorial 1 - Movement","61 - Tutorial 2 - Reaction Commands","63 - Tutorial 3 - Lock-on","64 - Junk Sweep (Roxas)","65 - Bumble-Buster (Roxas)","66 - Poster Duty (Roxas)","6B - The Nobody's Direction","BB - SB Street Rave","C7 - Junk Sweep (Sora)","C8 - Bumble-Buster (Sora)","C9 - Poster Duty (Sora)"},
				new string[] {"00 - No Event","01 - The Mysterious Man Once Again","02 - The Usual Station, The Usual Friends","03 - Struggle in Front of the Station","04 - Why Kairi?","6C - Infinite Nobodies Battle","6D - So Many Memories","6E - Giving Hayner the Normal Amount of Munny","6F - Giving Hayner the Maximum Amount of Munny","70 - \"Can You Feel Sora?\"","71 - 4 People's Treasure","72 - It Starts With an 'S'!","73 - The 7th Rumor","74 - The Crystal Ball's Light","D8 - Parting With a Partner","14C - The King Appears"},
				new string[] {"00 - No Event","01 - The Munny Disappeared","03 - Matching Pouches","04 - Tears","0C - Setting Off For the Seven Wonders","75 - Having Dismounted.","76 - Time For Goodbye","77 - Guidance From the Photo"},
				new string[] {"00 - No Event","78 - Head to the Wall While Avoiding the Balls!","79 - Shadow Roxas Battle","7A - The 6th Rumor"},
				new string[] {"00 - No Event","7B - Ended Up At the Residental Area","7C - The Train Vanished","128 - The Truth of the Rumor"},
				new string[] {"00 - No Event","01 - The World Seen From the Hill","7D - Stop the Moving Bag!","D7 - The 4 at Sunset Hill"},
				new string[] {"00 - No Event","01 - The Girl Disappeared, An Enemy Appeared","7E - The Shadows Roaming the Forest"},
				new string[] {"00 - No Event","01 - The Enemy Attacks","02 - The Haunted House","03 - The Keyblade's Memory","05 - Another Twilight Town","08 - Reunion With the King","29 - Nobody Waves Battle (With Mickey)","7F - First Encounter With a Dusk (With Struggle Weapon)","80 - First Encounter With a Dusk (With Kingdom Key)","82 - The Curtain Swaying in the Wind","D2 - The Meaning of \"Roxas\"","ED - The Keyblade Appears","EE - The Key Vanishes"},
				new string[] {"00 - No Event","01 - Entrance to the Parallel World"},
				new string[] {"00 - No Event","83 - Time For the Finishing Touches"},
				new string[] {"00 - No Event","01 - The Hidden Room"},
				new string[] {"00 - No Event","01 - Many Sketches","84 - The Girl's Room","85 - Those Who Don't Exist, Nobodies"},
				new string[] {"00 - No Event","01 - The Opponent That Blocks the Way","03 - Entrance to the Darkness","86 - Nobody Wave Battle","87 - Battle's End","88 - Reborn","141 - Axel's Resignation"},
				new string[] {"00 - No Event","89 - Axel II Battle (Normal)","D3 - Data Axel Appears","D4 - Data Axel Disappears","D5 - Axel II Battle (Data)"},
				new string[] {"00 - No Event","01 - In Front of the Computer","02 - The Password is...","03 - Input Success","04 - To the Other World","8A - DiZ and the Mysterious Man","8B - In the World of Darkness","8C - Dream Encounter","8D - The Laboratory's Light","8E - Uncontrollable Factors","8F - The Name is Ansem","90 - Resurrected Recollection","91 - Roxas'S Twilight Town"},new string[] {"00 - No Event","01 - Sleeping Friends"},new string[] {"00 - No Event","01 - The World's Servant, DiZ","02 - \"My Summer Vacation.\"","92 - The Girl in the White Room","93 - The Voice of Awakening"},new string[] {"00 - No Event","94 - Everyone On the Train"},new string[] {"00 - No Event","01 - I'm the One and Only Pete","95 - Wave of Shadows Battle","96 - The Mysterious Tower","154 - The Tower's Dweller is..."},new string[] {"00 - No Event","01 - Master Yen Sid","02 - Past and Future","04 - Departure"},new string[] {"00 - No Event","01 - The 3 Fairies","02 - A Gift From the Fairies","97 - The Witch's Revival","E4 - Tutorial 6 - Puzzle Pieces"},new string[] {"00 - No Event","98 - Heartless Waves Battle"},new string[] {"00 - No Event","99 - Heartless Waves Battle","155 - The Worlds Remain Unchanged"},
				new string[] {"00 - No Event","01 - Select Your Level Up Setup","9A - Triple Dusks Battle","9B - The Keyblade","9C - The Station of Awakening"},
				new string[] {"00 - No Event","01 - The Giant Looming Shadow","9D - Twilight Thorn Battle","10C - Roxas's Victory"},new string[] {"00 - No Event","9E - Far-Off World"},new string[] {"00 - No Event","9F - Multiple Vivis Battle"},
				new string[] {"00 - No Event","01 - The Lanes Between","02 - To the Final Frontier","A0 - Nobody Wave (Without Axel as Partner)","A1 - Nobody Waves Battle (With Axel as Partner)","A2 - The Dark Corridor","16E - Axel's Atonement","16F - Exchanged Words of Victory"}},new string[][] {
				new string[] {"00 - No Event","33 - Kairi and Selphie","34 - Kairi Running"},
				new string[] {"00 - No Event","35 - The Letter to the Boy","36 - Axel Talks to Kairi"}},new string[][] {
				new string[] {"00 - No Event","01 - Worn Out Pete","02 - Maleficent's Revival"},
				new string[] {"00 - No Event","01 - Xemnas' Speculation","02 - The Enemy Has Begun to Move","14 - The Conclusion","15 - A Message From Sephiroth","16 - One Winged Angel","4B - Sephiroth Battle","5C - A Message Left Behind"},
				new string[] {"00 - No Event","01 - The Leader of Organization XIII","02 - The Gathering of Mushrooms (Must Complete 12 Mushroom Missions to Make Mushroom XIII Appear!)","02 - Ansem's Apprentice","4E - Hollow Bastion Armageddon"},
				new string[] {"00 - No Event","01 - Good Morning, Goofy"},
				new string[] {"00 - No Event","01 - The Melodious Nocture, Demyx","37 - Demyx Battle (Normal)","72 - Demyx Battle (Data)","8C - Data Demyx Appears","8D - Data Demyx Disappears","D0 - Good Night, Goofy"},
				new string[] {"00 - No Event","01 - Ansem's Study","02 - Leon Reveals a Secret Path","03 - Transfer Device Activated","04 - Finding the Password!","05 - The Puzzle's Mystery","06 - The True Meaning of the Scribbles","08 - Response From the Program's World","09 - The Sealed Data","0C - Aerith Watches Over the Study","0D - We're Waiting, Tron","11 - The Researcher of Darkness, Ansem","12 - Ansem's True Form","45 - To the World of Programs Once More","47 - Cyberspace","5F - Data Transmission","60 - Hollow Bastion's Restoration","66 - In Ansem's","67 - Insurgence From the MCP"},
				new string[] {"00 - No Event","01 - Looking For Leon","02 - Sephiroth Descends","5D - Run Leon","5E - Radiant Garden"},
				new string[] {"00 - No Event","01 - Look at That","02 - The 3 Mysterious Girls","03 - Their Goal is...","34 - Sora & Leon VS Nobody Waves","A6 - Organization XIII Gathering"},
				new string[] {"00 - No Event","01 - The Town's Defense Mechanism","02 - Everyone's Invited","03 - The Stolen Picture Book","0A - The Boundary Disappeared","0B - Malfunctioning Defense System","0C - Dispersed, Dancing Light","33 - Nobody Waves Battle","3A - Heartless Waves Battle 1","48 - Heartless Waves Battle 2","64 - SB Freestyle","A1 - The Great Ninja Yuffie","AE - Pooh's Fine, Right?"},
				new string[] {"00 - No Event","01 - Arrival at Hollow Bastion","02 - Bad Sign","0A - The Heartless Again?","12 - Cloud's Determination"},
				new string[] {"00 - No Event","01 - To the Underground Passage","02 - Maleficent Joins to the Brawl","03 - Y-R-P!"},
				new string[] {"00 - No Event","0A - Heartless Manufactory"},
				new string[] {"00 - No Event","01 - The Hollow Bastion Restoration Committee","02 - A Report From Cid","03 - Merlin's Insight","04 - Pooh's Picture Book","05 - To the World Inside the Book","06 - Heartless Attack","08 - The Missing Memory","0A - Yuffie's Explanation","0B - Peace in the Town","0C - Program Complete"},
				new string[] {"00 - No Event","01 - The King's Memory"},
				new string[] {"00 - No Event","3E - Sora & Yuffie VS Heartless Waves","3F - Sora & Leon VS Heartless Waves","40 - Sora & Tifa VS Heartless Waves","41 - Sora & Cloud VS Heartless Waves","4F - Yuffie and Aerith's Valiant Stand","50 - Stitch Stands Strong","51 - Y-R-P's Great Performance","52 - Leon and Cloud","53 - Cloud, Dark Fate"},
				new string[] {"00 - No Event","42 - 1,000 Heartlesses Battle"},
				new string[] {"00 - No Event","01 - Aerith and Leon","0A - Pillars of Light","49 - Nobody Waves Battle"},
				new string[] {"00 - No Event","03 - Before the Broken Path","04 - Sorry, Your Highness!","05 - The Opened Path","3D - Heartless Invasion","54 - \"Everyone, Hang in There!\"","C4 - Hurry to the Castle Gate!"},
				new string[] {"00 - No Event","56 - Heartless and Nobody Waves Battle"},
				new string[] {"00 - No Event","01 - Welcome to the Cavern of Remembrance"},
				new string[] {"00 - No Event","01 - Activate the Engines"},
				new string[] {"00 - No Event","01 - Heartless Waves Battle 1","02 - Heartless Waves Battle 2"},
				new string[] {"00 - No Event","01 - Nobody Waves Battle 1","02 - Nobody Waves Battle 2","03 - Nobody Waves Battle 3"},
				new string[] {"00 - No Event","01 - The 13 Strange Portals","03 - The Garden of Assemblage"},
				new string[] {"00 - No Event","109 - To the Hidden Stage"},
				new string[] {"00 - No Event","73 - Vexen Battle (Absent Silhouette)","78 - The Chilly Academic, Vexen","79 - The Absent Silhouette of Vexen Disappears","82 - Data Vexen Appears","83 - Data Vexen Disappears","92 - Vexen Battle (Data)"},
				new string[] {"00 - No Event","7A - The Silent Hero, Lexaeus","7B - The Absent Silhouette of Lexaeus Disappears","80 - The Savage Nymph, Larxene","81 - The Absent Silhouette of Larxene Disappears","84 - Data Lexaeus Appears","85 - Data Lexaeus Disappears","8A - Data Larxene Appears","8B - Data Larxene Disappears","8E - Lexaeus Battle (Absent Silhouette)","8F - Larxene Battle (Absent Silhouette)","93 - Lexaeus Battle (Data)","94 - Larxene Battle (Data)"},
				new string[] {"00 - No Event","7C - The Cloaked Schemer, Zexion","7D - The Absent Silhouette of Zexion Disappears","86 - Data Zexion Appears","87 - Data Zexion Disappears","97 - Zexion Battle (Absent Silhouette)","98 - Zexion Battle (Data)"},
				new string[] {"00 - No Event","7E - The Graceful Assassin, Marluxia","7F - The Absent Silhouette of Marluxia Disappears","88 - Data Marluxia Appears","89 - Data Marluxia Disappears","91 - Marluxia Battle (Absent Silhouette)","96 - Marluxia Battle (Data)"}},new string[][] {
				new string[] {"00 - No Event","01 - The Voice Echoing in the Castle","02 - Find Belle","03 - Belle's Scream","0A - Beast is Ready For the Ball","0B - A Special Day","0c - Xaldin's Goal","4B - Nobody Waves Battle","7C - To the Castle's Exterior"},
				new string[] {"00 - No Event","01 - Assault in the Parlor","44 - Infinite Heartless Waves Battle","66 - Beast's Dilemma"},
				new string[] {"00 - No Event","01 - Belle Goes After Xaldin","02 - Someone's Voice","0A - Dress-Up","0B - Belle, Deep Within Her Sorrow","68 - Belle's Distress"},
				new string[] {"00 - No Event","01 - Organization XIII's Attempt","0A - The Missing Rose","0B - Don't Cast Aside Your Hopes","45 - Beast Battle","6E - Beast Regains His Sanity"},
				new string[] {"00 - No Event","01 - Decisive Battle in the Ballroom","0A - Uninvited Guests","4A - Nobody Wave Battle","77 - The Precious Thing"},
				new string[] {"00 - No Event","4E - Shadow Stalker Battle","4F - Dark Thorn Battle","71 - Showdown, Dark Thorn","72 - The Heartless's Final Moments"},
				new string[] {"00 - No Event","0A - Belle Has Been Kidnapped","0B - Together, Always"},
				new string[] {"00 - No Event","02 - Find a Way Into the Undercroft","03 - The Talking Wardrobe","5F - Move the Wardrobe Out of the Way"},
				new string[] {"00 - No Event","0A - The Rose's Secret"},
				new string[] {"00 - No Event","01 - The Dwellers of the Castle","6C - The Hidden Truth"},
				new string[] {"00 - No Event","01 - The Guardian of the Door","48 - Thresholder Battle","81 - Inside the Dungeon"},
				new string[] {"00 - No Event","01 - The Dark Lanterns","02 - Light the Lanterns"},
				new string[] {"00 - No Event","0A - Belle? The Rose?"},
				new string[] {"00 - No Event","01 - The Battle Afterward"},
				new string[] {"00 - No Event","52 - Xaldin Battle (Normal)","61 - Xaldin Battle (Data)","62 - Data Xaldin Appears","63 - Data Xaldin Disappears","7F - Xaldin's End"}},new string[][] {
				new string[] {"00 - No Event","01 - Hercules the Hero","02 - The Advice is Two Words","04 - Abducted Meg","44 - Hercules VS the Hydra","8C - Phil's Training - Practice","8D - Phil's Training - Maniac"},
				new string[] {"00 - No Event","02 - Reunion With the Hero Hercules"},
				new string[] {"00 - No Event","01 - Enraged Hydra","8E - Phil's Training - Practice","8F - Phil's Training - Maniac"},
				new string[] {"00 - No Event","02 - The Hero's Companion, Megara","05 - Arriving in the Underworld","07 - What Happened at Olympus?","0A - Enter the Underworld Coliseum","0C - Hades Cup Exhibition","0D - The Road to the Finals","12 - Hurry to Hades","13 - To the Underworld Coliseum","C5 - Astray in the Underworld","C6 - Auron Disappeared","C7 - Farewell to Auron","D2 - To Hades"},
				new string[] {"00 - No Event","01 - The Hero's Fatigue","02 - Megara's Unease","03 - The Olympus Stone"},
				new string[] {"00 - No Event","01 - The Way of the Dead","03 - Hades' Pursuit","6F - Escape From Hades"},
				new string[] {"00 - No Event","02 - Underworld Warrior, Auron","0A - Auron's Past","41 - Hades' Power","42 - This is My Game","43 - Hades' Intent","70 - Hades Battle (Hades is Invincible)","7E - Nobody Waves Battle","D8 - From Hero to Zero","F8 - Internal Discord?"},
				new string[] {"00 - No Event","01 - Hell's Watchdog, Cerberus","0A - Manipulated Auron","72 - Cerberus Battle","DD - Escape Successful!"},
				new string[] {"00 - No Event","01 - Pete Never Learns","02 - Uniting Power","73 - Defending Megara From Pete","74 - Sora & Hercules VS Pete I","ED - The True Hero","F0 - Laughing Hades"},
				new string[] {"00 - No Event","7C - \"Spin Strike\" Heartless Wave Battle","7D - \"Bad Alert\" Heartless Wave Battle","BD - The Pain and Panic Cup","BE - The Cerberus Cup","BF - The Titan Cup","C0 - The Goddess of Fate Cup","C1 - The Pain and Panic Paradox Cup","C2 - The Cerberus Paradox Cup","C3 - The Titan Paradox Cup","C4 - The Hades Paradox Cup"},
				new string[] {"00 - No Event","01 - Escaping Organization XIII","03 - Legendary Guardian"},
				new string[] {"00 - No Event","02 - The Hero is Never Neglected"},
				new string[] {"00 - No Event","0A - Take Back the Heart","0B - Hercules Revived!","47 - Hercules VS Auron","B4 - Winning the Pain and Panic Cup Trophy","B5 - Winning the Cerberus Cup Trophy","B6 - Winning the Titan Cup Trophy","B7 - Winning the Goddess of Fate Cup Trophy","B8 - Winning the Hades Paradox Cup Trophy","C9 - Hades Battle (Part I)","CA - Hades Battle (Part II)","FF - Hades, to the Realm of the Dead"},
				new string[] {"00 - No Event","0A - The Hero's Star"},
				new string[] {"00 - No Event","01 - Suspicious Silhouette"},
				new string[] {"00 - No Event","7B - Demyx's Water Clones Battle","103 - Regained Power"},
				new string[] {"00 - No Event","AB - Hydra Battle","F3 - Spoils of Battle"},
				new string[] {"00 - No Event","01 - Round 01: Shadow x5, Hook Bat x5","02 - Round 02: Large Body x1, Minute Bomb x4","03 - Round 03: Soldier x2, Rabid Dog x5","04 - Round 04: Shadow x4, Hot Rod x2","05 - Round 05: Hook Bat x4, Rapid Thruster x5, Bolt Tower x2","06 - Round 06: Minute Bomb x4, Gargoyle Knight x3, Lance Soldier x4","07 - Round 07: Soldier x2, Rabid Dog x1, Aeroplane x6, Assault Rider x2","08 - Round 08: Rapid Thruster x?","09 - Round 09: Creeper Plant x4, Gargoyle Warrior x2","0A - Round 10: Leon & Yuffie"},
				new string[] {"00 - No Event","01 - Round 01: Air Pirate x2, Trick Ghost x2","02 - Round 02: Driller Mole x3, Hammer Frame x3","03 - Round 03: Tornado Step x3, Wight Knight x3","04 - Round 04: Silver Rock x4, Living Bone x1","05 - Round 05: Icy Cube x5, Shaman x1, Fiery Globe x5","06 - Round 06: Fortuneteller x2, Aerial Knocker x2","07 - Round 07: Cannon Gun x3, Toy Soldier x1","08 - Round 08: Luna Bandit x5","09 - Round 09: Emerald Blues x4, Fat Bandit x1","0A - Round 10: Cerberus"},
				new string[] {"00 - No Event","01 - Round 01: Magnum Loader x2, Dusk x3","02 - Round 02: Morning Star x1, Assassin x4","03 - Round 03: Strafer x4, Berserker x2","04 - Round 04: Sniper x2, Trick Ghost x3","05 - Round 05: Dancer x3, Neoshadow x3","06 - Round 06: Air Pirate x2, Dragoon x2, Bookmaster x1","07 - Round 07: Samurai x2, Crimson Jazz x2","08 - Round 08: Minute Bomb x3, Sniper x2, Assassin x2","09 - Round 09: Devastator x1, Dancer x2, Berserker x2","0A - Round 10: Hercules"},
				new string[] {"00 - No Event","01 - Round 01: Morning Star x1, Emerald Blues x2, Sniper x2, Morning Star x4","02 - Round 02: Hammer Frame x3, Living Bone x1","03 - Round 03: Creeper Plant x3, Toy Soldier x1","04 - Round 04: Nightwalker x2, Crimson Jazz x2","05 - Round 05: Shaman x4, Assassin x2, Devastator x3","06 - Round 06: Fat Bandit x1, Large Body x1","07 - Round 07: Lance Soldier x2, Assault Rider x2","08 - Round 08: Rapid Thruster Swarm","09 - Round 09: Bolt Tower x2, Hot Rod x2","0A - Round 10: Hades & Hammer Frames"},
				new string[] {"00 - No Event","01 - Round 01: Shadow x5, Hook Bat x5","02 - Round 02: Large Body x1, Minute Bomb x4","03 - Round 03: Soldier x2, Rabid Dog x5","04 - Round 04: Shadow x4, Hot Rod x2","05 - Round 05: Hook Bat x4, Rapid Thruster x5, Bolt Tower x2","06 - Round 06: Minute Bomb x4, Gargoyle Knight x3, Lance Soldier x4","07 - Round 07: Soldier x2, Rabid Dog x1, Aeroplane x6, Assault Rider x2","08 - Round 08: Rapid Thruster x?","09 - Round 09: Creeper Plant x4, Gargoyle Warrior x2","0A - Round 10: Leon & Yuffie"},
				new string[] {"00 - No Event","01 - Round 01: Air Pirate x2, Trick Ghost x2","02 - Round 02: Driller Mole x3, Hammer Frame x3","03 - Round 03: Tornado Step x3, Wight Knight x3","04 - Round 04: Silver Rock x4, Living Bone x1","05 - Round 05: Icy Cube x5, Shaman x1, Fiery Globe x5","06 - Round 06: Fortuneteller x2, Aerial Knocker x2","07 - Round 07: Cannon Gun x3, Toy Soldier x1","08 - Round 08: Luna Bandit x5","09 - Round 09: Emerald Blues x4, Fat Bandit x1","0A - Round 10: Cerberus"},
				new string[] {"00 - No Event","01 - Round 01: Magnum Loader x2, Dusk x3","02 - Round 02: Morning Star x1, Assassin x4","03 - Round 03: Strafer x4, Berserker x2","04 - Round 04: Sniper x2, Trick Ghost x3","05 - Round 05: Dancer x3, Neoshadow x3","06 - Round 06: Air Pirate x2, Dragoon x2, Bookmaster x1","07 - Round 07: Samurai x2, Crimson Jazz x2","08 - Round 08: Minute Bomb x3, Sniper x2, Assassin x2","09 - Round 09: Devastator x1, Dancer x2, Berserker x2","0A - Round 10: Hercules"},
				new string[] {"00 - No Event","01 - Round 01: Shadow x3, Soldier x3","02 - Round 02: Driller Mole x4, Hook Bat x2","03 - Round 03: Rapid Thruster x3, Surveillance Robot x2","04 - Round 04: Rapid Dog x5, Creeper Plant x2","05 - Round 05: Volcanic Lord, Soldier x2","06 - Round 06: Cannon Gun x3, Silver Rock x2","07 - Round 07: Icy Cube x3, Shadow x4, Minute Bomb x8","08 - Round 08: Soldier x3, Silver Rock x2, Armored Knight x5, Large Body x1","09 - Round 09: Creeper x4, Samurai x1","0A - Round 10: Yuffie & Tifa","0B - Round 11: Rapid Thruster x5, Aeroplane x3","0C - Round 12: Minute Bomb x4, Magnum Loader x1, Air Pirate x2","0D - Round 13: Luna Bandit x3, Driller Mole x2","0E - Round 14: Lance Soldier x2, Armored Knight x2, Tornado Step x2","0F - Round 15: Blizzard Lord","10 - Round 16: Soldier x4, Wight Knight x2","11 - Round 17: Strafer x4, Neoshadow x4, Aerial Knocker x4","12 - Round 18: Luna Bandit x2, Air Pirate x2, Creeper Plant x3, Wight Knight x3","13 - Round 19: Dusk x2, Assassin x2, Dragoon x1","14 - Round 20: Pete","15 - Round 21: Gargoyle Knight x3, Armored Knight x3","16 - Round 22: Fortuneteller x2, Aeroplane x1, Trick Ghost x2","17 - Round 23: Soldier x2, Creeper Plant x2 Shaman x2","18 - Round 24: Bulky Vendor x3","19 - Round 25: Cloud & Tifa","1A - Round 26: Bolt Tower x2, Hammer Frame x2, Neoshadow x1","1B - Round 27: Gargoyle Warrior x2, Rabid Dog x4, Nightwalker x4","1C - Round 28: Bookmaster x2, Emerald Blues x4, Shaman x4, Silver Rock x3","1D - Round 29: Sniper x2, Gambler x2","1E - Round 30: Hades (Without Hercules as Partner)","1F - Round 31: Samurai x2, Berserker x1, Creeper x2","20 - Round 32: Dancer x2, Demyx's Water Clones x3","21 - Round 33: Samurai x4","22 - Round 34: Sorcerer x2","23 - Round 35: Rapid Thruster Swarm","24 - Round 36: Berserker x3","25 - Round 37: Sniper x2, Assassin x3, Dragoon x4","26 - Round 38: Dusk x6, Samurai x3, Dancer x4, Gambler x4, Sorcerer x1","27 - Round 39: Dragoon x4","28 - Round 40: Leon & Cloud","29 - Round 41: Toy Soldier x2, Graveyard x2","2A - Round 42: Living Bone x2, Fortuneteller x1","2B - Round 43: Morning Star x2, Large Body x2","2C - Round 44: Living Bone x3","2D - Round 45: 1,000 Heartless Battle","2E - Round 46: Hot Rod x2, Devastator x1","2F - Round 47: Bulky Vendor x1, Lance Soldier x2, Living Bone x1, Emerald Blues x2, Assault Rider x2, Morning Star x3, Crescendo x5","30 - Round 48: Cerberus","31 - Round 49: Leon, Cloud, Yuffie, & Tifa","32 - Round 50: Hades (With Hercules as Partner)"}},
			
			new string[][] {
				new string[] {"00 - No Event","01 - Find Aladdin","02 - Jafar's Lamp","03 - The Missing Merchant"},
				new string[] {"00 - No Event","01 - Princess Jasmine","02 - Competition For the Magic Lamp","03 - Come Back Soon","0A - Jafar's Trickery","3B - Blizzard Lord & Volcano Lord Battle","80 - The Joy of Triumph","82 - Getting Along With Everyone"},
				new string[] {"00 - No Event","01 - The Sealed Lamp","0A - Jafar's Revival"},
				new string[] {"00 - No Event","0A - Fierce Fighting, Evil Genie Jafar","3E - Jafar Battle","92 - In the End of Battle"},
				new string[] {"00 - No Event","0A - Genie's Big Performance","0B - Escape Success"},
				new string[] {"00 - No Event","01 - To the Magic Cave"},
				new string[] {"00 - No Event","01 - The Cave's Gimmicks","02 - Protect Abu and Help Him Get to the Pedestal Safely!","03 - The Opening Path"},
				new string[] {"00 - No Event","01 - Mountain of Treasure","3A - 50 Heartlesses Battle","7C - To Agrabah, With Haste"},
				new string[] {"00 - No Event","0A - Iago's Confession"},
				new string[] {"00 - No Event","02 - Behind the Door is...","4F - Chasms of Challenges"},
				new string[] {"00 - No Event","0A - Magic Carpet","0B - Go Towards Jafar's Shadow!","0C - Summoning the Heartless","0D - Follow Jafar's Shadow!","0E - Chase Jafar!","0F - Chase Jafar's Shadow to the Tower!","10 - Mid-air Showdown","11 - Activate the 3 Switches","3D - Magic Carpet (Escape From the Ruins!)","56 - Heartless Waves Battle 1","57 - Heartless Waves Battle 2","66 - Hurry to the Tower Before the Door Shuts!","6F - Magic Carpet (Defeat 65 or More Heartlesses)","8C - Press the Switch","8D - Rush to the Door!"}},new string[][] {
				new string[] {"00 - No Event","01 - Shan Yu's Plot","02 - Former Comrade Mushu"},
				new string[] {"00 - No Event","03 - Hurry! To the Capital!","45 - Mission 1: The Surprise Attack","50 - Mission 2: The Ambush"},
				new string[] {"00 - No Event","01 - Danger Approaches the Summit","47 - Hurry to the Mountain Summit!"},
				new string[] {"00 - No Event","01 - Checking in the Cave","48 - Sora & Ping VS Heartless Waves"},
				new string[] {"00 - No Event","01 - Shan Yu Still Lives","0A - Chasing the Mysterious Figure","0C - The Capital is in Danger!"},
				new string[] {"00 - No Event","01 - The Great Battle on the Snowy Mountain","02 - Avalanche","0A - The Man Standing Atop the Snowy Mountain","49 - Sora VS Infinite Heartless Waves (With Time Limit)","4C - Riku? Battle","78 - Ominous Premonition"},
				new string[] {"00 - No Event","01 - The Capital's Crisis","0A - Going to the Palace","0B - More Heartless","0D - Storm Rider Comes Flying","4A - Heartless Waves Battle (1st Visit)","4F - Storm Rider Battle","51 - Heartless Waves Battle (2nd Visit)","81 - Fireworks"},
				new string[] {"00 - No Event","01 - This is the End!","0A - Mulan's Maturity","4B - Shan Yu Battle","69 - The Hero Who Saved the Land"},
				new string[] {"00 - No Event","0A - The Figure in Front of the Gate","0B - Maybe It's Riku?","0D - Identity of the Earth Sounds","4E - Nobody Waves Battle"},
				new string[] {"00 - No Event","0A - To the Emperor's Side","0B - The Highest Reward","40 - Captain Shang's Been Defeated"},
				new string[] {"00 - No Event","01 - Annihilated Army","0A - The Village With No-One In It"}},new string[][] {
				new string[] {"00 - No Event","01 - The 100 Acre Wood","02 - To the Forest Once More","03 - Piglet's House","04 - Piglet's House Complete","05 - Rabbit's House","06 - Rabbit's House Complete","07 - Kanga and Roo's House","08 - Kanga and Roo's House Complete","09 - The Haunted Cave","0A - The Haunted Cave Accomplished","0B - Starry Hill"},
				new string[] {"00 - No Event","01 - How Are You?","03 - Right Here Without You","34 - The Hunny Pot (Get the Hunny Pot Off of Pooh's Head)","35 - A Dreaming Pooh","49 - The Hunny Pot (Get a Score of 8,000 or More)"},
				new string[] {"00 - No Event","01 - Pooh's House","02 - Reunion, and Then a Strange Incident","03 - Pooh's Situation","04 - Something's Out of Place"},
				new string[] {"00 - No Event","01 - Eeyore's Murmurs","02 - The Mysterious Honey","03 - Rabbit's Secret","04 - Just Enough Honey"},
				new string[] {"00 - No Event","01 - Strategy Meeting","02 - At a Time Like That, Just Jump","04 - A Joyful Jump"},
				new string[] {"00 - No Event","37 - A Blustery Rescue (With Time Limit)","45 - A Blustery Rescue (Without Time Limit)"},
				new string[] {"00 - No Event","39 - Hunny Slider (With Lives)","46 - Hunny Slider (Without Lives)"},
				new string[] {"00 - No Event","3B - Balloon Bounce (With Time Limit)","47 - Balloon Bounce (Without Time Limit)"},
				new string[] {"00 - No Event","01 - Finding Pooh","03 - We Were Worried","3D - The Expotition (With Time Limit)","48 - The Expotition (Without Time Limit)"}},new string[][] {
				new string[] {"00 - No Event","01 - Rafiki's Judgment","02 - King Scar","03 - The Wind's Tidings","04 - Scar's Conspiracy","05 - The New King","0A - Scar's Ghost","0B - The King's Nature","0C - Simba's Whereabouts","0D - The Past Overcome","0E - Circle of Life"},
				new string[] {"00 - No Event","0A - Weak Heart, Wicked Heart"},
				new string[] {"00 - No Event","0A - Irritated Simba","33 - Shenzi, Banzai, and Ed Battle (Protect Timon and Pumbaa)","53 - To the Summit, the Battlefield"},
				new string[] {"00 - No Event","01 - Simba is Alive","03 - Present Hometown","0A - The Hyena's Loud Laughter"},
				new string[] {"00 - No Event","01 - Assaulted Nala","0A - The Elephant Graveyard","38 - Living Bone x2 Battle","39 - Shenzi, Banzai, and Ed Battle (Chase Them!)","44 - Sora is the Savior?","5D - Simba Ran Away"},
				new string[] {"00 - No Event","01 - Wild Kingdom"},
				new string[] {"00 - No Event","01 - Timon and Pumbaa"},
				new string[] {"00 - No Event","01 - A Comfortable Life","02 - Reunion With Simba","03 - Hakuna Matata","04 - Can't Put It Into Words","0A - Encroaching Phantom","0B - Self-Consciousness As the King"},
				new string[] {"00 - No Event","01 - Oasis Night"},
				new string[] {"00 - No Event","01 - Simba's Agony"},
				new string[] {"00 - No Event","01 - The Heartless of Malice and Wrath"},
				new string[] {"00 - No Event","37 - Scar Battle","55 - Reconciliation With the Past"},
				new string[] {"00 - No Event","0A - Groundshaker Attack","3B - Groundshaker Battle","63 - The Collapsing Monstrosity"}},new string[][] {
				new string[] {"00 - No Event","01 - Blowing Off the Anxiety"},
				new string[] {"00 - No Event","01 - The Prince's Bronze Statue","02 - Chapter 4 Prologue","33 - Song 2: Part of Your World (Story-Related)","43 - Song 2: Part of Your World (Not Story-Related)","53 - Song 2: Part of Your World (Theater Mode)","54 - Collaboration With Ariel"},
				new string[] {"00 - No Event","01 - The Kingdom of the Sea, Atlantica","02 - Invitation to the Musical","03 - The Way to Regain Energy","05 - The Complex Music Chart","08 - Ursula's Temptation to Sign the Contract","09 - Searching Ariel","0B - To the Best Musical","34 - Swimming Tutorial","3F - Musical Rhythm"},
				new string[] {"00 - No Event","01 - Chapter 3 Prologue","35 - Song 3: Under the Sea (Story-Related)","44 - Song 3: Under the Sea (Not Story-Related)","57 - Song 3: Under the Sea (Theater Mode)","58 - Sebastian's Distress"},
				new string[] {"00 - No Event","01 - Chapter 1 Prologue","02 - Chapter 5 Prologue","37 - Song 5: A New Day is Dawning (Story-Related)","40 - Song 1: Swim This Way (Story-Related)","42 - Song 1: Swim This Way (Not Story-Related)","46 - Song 5: A New Day is Dawning (Not Story-Related)","4D - Song 1: Swim This Way (Theater Mode)","4E - Triton's Anxiety","66 - Song 5: A New Day is Dawning (Theater Mode)","67 - Because the Worlds Are Connected"},
				new string[] {"00 - No Event","01 - The Statue From the Surface","02 - Chapter 2 Prologue","03 - Unforgivable!"},
				new string[] {"00 - No Event","01 - The Prince Searching For Ariel","02 - The Prince Lost Something","03 - Prince Eric and Ariel"},
				new string[] {"00 - No Event","01 - Encounter With the Prince","02 - The Destined Duo","03 - The Two On the Beach","04 - Ariel's Confession"},
				new string[] {"00 - No Event","01 - Ursula's Plot"},
				new string[] {"00 - No Event","41 - Song 4: Ursula's Revenge (Story-Related)","45 - Song 4: Ursula's Revenge (Not Story-Related)","61 - Song 4: Ursula's Revenge (Theater Mode)","62 - Ursula Disappeared Into the Sea"}},new string[][] {
				new string[] {"00 - No Event","01 - There Are Heartless Here Too?","33 - Guide Minnie to the Throne","51 - The Hidden Entrance"},
				new string[] {"00 - No Event","01 - Pleased to Meet You, Queen Minnie","35 - The Castle's Incident"},
				new string[] {"00 - No Event","02 - Protect Minnie While Heading to the Audience Chamber!","4F - The Sealed Audience Chamber"},
				new string[] {"00 - No Event","01 - Welcome to Disney Castle"},
				new string[] {"00 - No Event","01 - The Cornerstone of Light","02 - The Mysterious Door","03 - Into the Door","36 - The Queen's Wish"},
				new string[] {"00 - No Event","01 - The Castle is Now Protected From the Peace","02 - The Appearance of a Dark Portal"},
				new string[] {"00 - No Event","01 - A Strange Situation?"},
				new string[] {"00 - No Event","44 - Terra's Lingering Sentiment","45 - The Power of the Chosen One","46 - Rematch With Terra","47 - Victory on the Wastelands","49 - Terra Battle"}},new string[][] {
				new string[] {"00 - No Event","01 - The World of Black and White","02 - The Appearing Window","03 - Deepening Mystery","04 - The Same Door","05 - This is the World to the Past","06 - Everyone's Reasoning","07 - Return to the Original World"},
				new string[] {"00 - No Event","01 - Attacking Pete","3A - Pete? Battle","43 - Not the Culprit?"},
				new string[] {"00 - No Event","01 - The Stolen Steamboat","03 - Departure! Willie!","34 - Save the Cornerstone of Light!","56 - Escaping Pete"},
				new string[] {"00 - No Event","01 - There Are 2 Petes?","35 - Pete II Battle","58 - The Door of Time is Sealed"},
				new string[] {"00 - No Event","02 - The King at Lilliput","36 - Heartless Waves Battle","4E - Mysterious Little Window 3"},
				new string[] {"00 - No Event","01 - The King at the Construction Site","37 - Heartless Waves Battle","52 - Mysterious Little Window 4"},
				new string[] {"00 - No Event","02 - The King at the Scene of the Fire","38 - Heartless Waves Battle","4A - Mysterious Little Window 2"},
				new string[] {"00 - No Event","01 - Time Window: Maleficent's Verdict","02 - Time Window: The Good Old Days","03 - Time Window: Door to the Past","04 - Time Window: The Culprit Appears"}},new string[][] {
				new string[] {"00 - No Event","01 - Merry Christmas","02 - The Mayor's Decree","03 - Advance Departure!","0A - Take Back the Presents","0B - Merry Christmas!","33 - Heartless Waves Battle 1","3C - Heartless Waves Battle 2 (Collect the Four Presents)","52 - Santa's Bodyguard","6C - The Incident is Not Yet Over"},
				new string[] {"00 - No Event","01 - The Doctor's Research","0A - The Shadow Creeping Near to the Doctor","0B - Jack's Great Idea"},
				new string[] {"00 - No Event","01 - Welcome to Halloween Town","02 - Maleficent's Shadow","05 - Kidnapped Santa"},
				new string[] {"00 - No Event","01 - Resurrected Boogie","34 - Prison Keeper Battle","39 - The Plan","5E - The Escaping Trio"},
				new string[] {"00 - No Event","01 - The King of Terror, Jack Skellington","02 - The Hinterland Door","0A - Jack's Assistance","3A - Maleficent and Boogie"},
				new string[] {"00 - No Event","01 - Christmas Town","03 - Smog From the Workshop"},
				new string[] {"00 - No Event","01 - There Are Heartless Here Too?","03 - Follow the Footprints","05 - Everyone's Roles","0A - Jack's Programme","35 - Heartless Waves Battle","58 - A Christmas Concern"},
				new string[] {"00 - No Event","0A - The Big Present Plot","40 - The Experiment Battle","72 - The Experiment"},
				new string[] {"00 - No Event","01 - Santa Claus' House","0A - Where's the Real Culprit?","0B - Where Should We Leave the Present?","12 - The First Step","14 - The Stolen Presents"},
				new string[] {"00 - No Event","01 - The Trick-or-Treating Goblins","02 - Rescue Santa","37 - Oogie Boogie Battle","3B - Boogie's Frolic","4B - SB Workshop Rave","64 - Boogie's End"},
				new string[] {"00 - No Event","0A - The Culprit is of Course...","3E - Trap Lock, Shock, & Barrel in Presents","3F - Gift Wrapping (Wrap 100 Presents)","48 - Gift Wrapping (Wrap Over 150 Presents)"}},new string[][] {new string[] {"00 - No Event","  -           "}},new string[][] {
				new string[] {"00 - No Event","01 - The View From High Ground","0A - Port Royal Once More"},
				new string[] {"00 - No Event","01 - The Undead Pirates","0A - The Jack Sparrow Way","33 - Undead Pirates Battle (Immortal)","34 - Undead Pirates Battle (1st Visit)","35 - Undead Pirates Battle (2nd Visit)","36 - Luxord Escapes","5B - The Moon's Light","5C - Chase Barbossa!","74 - Resurrected Pirates"},
				new string[] {"00 - No Event","01 - Elizabeth and Will","37 - Heartless Waves Battle","58 - SB Time Attack","5E - Will's Request"},
				new string[] {"00 - No Event","02 - Onward to the Island of Death","03 - The Black Pearl's Attack","38 - Get Rid of the Burning Barrels!"},
				new string[] {"00 - No Event","01 - In Will's Veins Flows","02 - Barbossa's Trap"},
				new string[] {"00 - No Event","01 - Captured Jack","0A - Interceptor, Discovery","0B - On-board Rivalry","0C - Missing Medals","0D - Where's the Treasure Chest?","0E - All to the Sea","14 - Talk to Jack Sparrow and Choose \"Port Royal\" to Fight the 2nd Grim Reaper.","56 - Parlay From Organization XIII"},
				new string[] {"00 - No Event","0A - What Happened to Will's Body?"},
				new string[] {"00 - No Event","3A - Undead Pirates Battle (Protect the Medallion)","51 - The True Form of the Blood Pact"},
				new string[] {"00 - No Event","03 - To the Island of Death","04 - Each to His Own World"},
				new string[] {"00 - No Event","01 - Elizabeth and Will Run Away","3B - Infinite Undead Pirates Battle (With Time Limit)","64 - The Signal!","65 - Jack Isn't Here"},
				new string[] {"00 - No Event","02 - Immortal Body","0A - Creeping Shadows","3C - Barbossa Battle","6F - Eternal Slumber"},
				new string[] {"00 - No Event","0A - The Ship Graveyard"},
				new string[] {"00 - No Event","0A - Give Back the Gold Coin!","3E - Gambler Nobody Battle","7B - The Captain is Elizabeth?"},
				new string[] {"00 - No Event","01 - What Happened On the Island?","3D - The Blood of Atonement","67 - You Can't Trust a Pirate"},
				new string[] {"00 - No Event","01 - Ambush Battle - Tornado Step x2, Cannon Gun x1, Shadow x4","55 - Grim Reaper I Battle (Normal)"},
				new string[] {"00 - No Event","0A - Ambush Battle 1 - Undead Pirate B x2, Lance Soldier x2","0B - Ambush Battle 2 - Undead Pirate B x3, Rabid Dog x5"},
				new string[] {"00 - No Event","02 - Ambush Battle - Undead Pirate A x2, Undead Pirate B x2"},
				new string[] {"00 - No Event","01 - Ambush Battle - Undead Pirate B x1, Air Pirate x1, Cannon Gun x2"},
				new string[] {"00 - No Event","4F - The Cursed Medallion"},
				new string[] {"00 - No Event","53 - The Plan to Rescue Elizabeth"}},new string[][] {
				new string[] {"00 - No Event","01 - Security Program, Tron","01 - The MCP's Aim","03 - Escape From the Cell","04 - Tron's Request","06 - Where's Tron?","07 - Game Clear!","0A - Hurry to the Game Area","0C - Prevent an All-Out War"},
				new string[] {"00 - No Event","01 - Space Paranoids","02 - Energy Core Activated!","0A - Heartless' Control","33 - Find the Real Parts!","54 - Energy Restored","55 - The Path is Ready"},
				new string[] {"00 - No Event","01 - Invitation to the Game","0A - Tron's in Danger!","35 - Heartless Waves Battle","3D - Light Cycle (Defeat 5 of the Heartless)","3E - Light Cycle (Head For the Goal)","3F - Light Cycle (Mission: Defeat 30 or More Heartlesses and Head For the Goal)","58 - Escape Route"},
				new string[] {"00 - No Event","01 - The Password is...","36 - Infinite Heartless Waves (Stop All of the Monitors)","5B - Tron's Restoration!"},
				new string[] {"00 - No Event","01 - Dangerous Program Initiated","0A - Almost There","37 - Hostile Program Battle","38 - Heartless Waves Battle","5D - Program Erasure"},
				new string[] {"00 - No Event","01 - The MCP's Preparations For Destruction","02 - Tron and Ansem","04 - Now, to Hollow Bastion","0A - Reception Successful!"},
				new string[] {"00 - No Event","0A - In the Sea of Data","39 - Heartless Waves Battle"},
				new string[] {"00 - No Event","0A - Arrival at the Central Computer Core"},
				new string[] {"00 - No Event","0A - Crash, Commander Sark","3A - Sark Battle (Normal)","3B - Sark (Big) and the MCP Battle","6A - All of the Function's Will.","6B - The MCP's Breakdown"},
				new string[] {"00 - No Event","0A - The Solar Sailer's Departure"}},new string[][] {
				new string[] {"00 - No Event","33 - Number XIII, Roxas","73 - The Organization's Agenda: Eliminate the Traitor","74 - The Organization's Agenda: The Hero of Light","75 - The Organization's Agenda: Saix's Report","76 - The Organization's Agenda: Everything Has Begun to Move","77 - The Organization's Agenda: Insufficient"},
				new string[] {"00 - No Event","01 - The Land of Battle","40 - Prowling Pluto"},
				new string[] {"00 - No Event","01 - The Roadless Road","02 - The Road Continuing Onto the Castle","5F - Wriggling Heartless"},
				new string[] {"00 - No Event","01 - Kairi and Naminé"},
				new string[] {"00 - No Event","104 - The Truth of the Room of Sleep"},
				new string[] {"00 - No Event","01 - Protagonists Together","02 - The Freeshooter, Xigbar","39 - Xigbar Battle (Normal)","64 - Xigbar Battle (Data)","6B - Data Xigbar Appears","6C - Data Xigbar Disappears","BF - Friends at the Origin"},
				new string[] {"00 - No Event","01 - This Isn't a Dream..."},
				new string[] {"00 - No Event","01 - DiZ's Truth"},
				new string[] {"00 - No Event","01 - Road Opened","02 - A New Path"},
				new string[] {"00 - No Event","01 - The Gambler of Fate, Luxord","3A - Luxord Battle (Normal)","65 - Luxord Battle (Data)","6F - Data Luxord Appears","70 - Data Luxord Disappears","C4 - The Battle's Outcome"},
				new string[] {"00 - No Event","01 - The Luna Diviner, Saix","38 - Saix Battle (Normal)","60 - A Friend in the Heart","66 - Saix Battle (Data)","6D - Data Saix Appears","6E - Data Saix Disappears","7A - I Wanted to See You Too"},
				new string[] {"00 - No Event","01 - \"Riku, I Wanted to See You\"","02 - Ansem the Wise's Gamble","03 - Farewell, King","05 - In the Original Form"},
				new string[] {"00 - No Event","01 - Maleficent and Pete's Heart"},
				new string[] {"00 - No Event","01 - The Skyscraper's Decisive Battle","3B - Xemnas I Battle (Normal)","61 - Xemnas I Battle (Data)","67 - Data Xemnas I Appears","68 - Data Xemnas I Disappears","D1 - Kairi's Voice"},
				new string[] {"00 - No Event","4A - Twilight Xemnas Battle (Normal)","55 - The Final Battle","62 - Twilight Xemnas Battle (Data)","69 - Data Twilight Xemnas Appears","6A - Data Twilight Xemnas Disappears","DA - In the End of Nothing"},
				new string[] {"00 - No Event","01 - Sora VS Roxas Cutscene (Part II) - The Reason Sora Was Chosen)","41 - Roxas Battle (Normal)","63 - Roxas Battle (Data)","71 - Data Roxas Appears","72 - Data Roxas Disappears","79 - Roxas' Time to Sleep"},new string[] {"00 - No Event","48 - Armored Dragon Battle"},new string[] {"00 - No Event","49 - Armor Xemnas II Battle","54 - For the Sake of Ending It All"},new string[] {"00 - No Event","47 - Armor Xemnas I Battle","57 - The Throne of Xemnas"},new string[] {"00 - No Event","46 - Battle Within the Core"},new string[] {"00 - No Event","45 - Battle on the Twin Cannons"},new string[] {"00 - No Event","4B - Final Battle (Part I)","5E - The Town Squirms"},new string[] {"00 - No Event","44 - Final Battle (Part II)"},new string[] {"00 - No Event","5C - To the Heart in the Midst of Nothingness","5D - Escape From the Outer Space"}}};
		int[][] eventsInfos = new int[][] {new int[] {0,1},
			new int[] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,27,28,29,30,32,34,35,36,40},
			new int[] {1,2},
			new int[] {0,1,2,3,4,5,6,8,9,10,11,12,13,15,16,17,18,19,20,21,22,24,25,26,27,32,33,34,38},
			new int[] {0,1,2,3,4,5,6,8,9,10,11,12,13,14,15},
			new int[] {0,1,2,3,4,5,6,7,8,9,10,12,13,14,15,17,18,189,190,191,192,193,194,195,196},new int[] {2,3,4,5,6,7,9,10,11,13,14},new int[] {0,2,3,5,6,7,8,9,10,11,12},new int[] {0,1,2,3,5,6,7,8,9},new int[] {0,1,2,4,5,6,8,9,11,12,13,14,15},new int[] {0,1,2,3,4,5,6,7,8,9},new int[] {0,1,2,3,4,5,6,7},new int[] {0,1,2,3,4,5,6,8},new int[] {0,1,2,3,4,5,6,7,8,9,10},new int[] {-1},new int[] {0,1,2,3,4,5,6,7,8,9,10,11,14,17,18,19,21,22,23,25},new int[] {0,1,2,3,4,5,7,8,9,10},new int[] {0,1,4,5,9,10,11,12,13,14,15,16,17,19,20,21,22,23,24,25,26,27,28,29}};
		
		public void InitWarpStrings()
		{
			for (int i =0;i<Rooms.Length;i++)
			{
				RoomsLABELS.Add(new List<ListViewItem>(0));
				for (int j =0;j<Rooms[i].Length;j++)
					RoomsLABELS[i].Add(new ListViewItem(Rooms[i][j].Replace("- ","$").Split('$')[1]));
				
			}
			for (int i =0;i<AllEvents.Length;i++)
			{
				AllEventsLABELS.Add(new List<List<ListViewItem>>(0));
				for (int j =0;j<AllEvents[i].Length;j++)
				{
					AllEventsLABELS[i].Add(new List<ListViewItem>(0));
					for (int k =0;k<AllEvents[i][j].Length;k++)
					{
						string new_ = AllEvents[i][j][k].Split('-')[1];
						AllEventsLABELS[i][j].Add(new ListViewItem(new_.Substring(1,new_.Length-1)));
					}
				}
			}
		}
		
		int selectedWorld = 0;
		int selectedRoom = 0;
		int WarpPopUpState = 0;
		
		void PopUpWarpValid(int ValidIndex)
		{
			WarpPopUpState++;
			if (WarpPopUpState==1)
			{
				selectedRoom = Convert.ToInt32(Rooms[selectedWorld][ValidIndex].Substring(0,2),16);
				for (int i=0;i<eventsInfos[selectedWorld].Length;i++)
					if (eventsInfos[selectedWorld][i]==selectedRoom)
					{
						OpenPopUp(AllEventsLABELS[selectedWorld][i].ToArray());
						return;
					}
			}
			if (WarpPopUpState==2)
			{
				eventNum = 0;
					for (int i=0;i<eventsInfos[selectedWorld].Length;i++)
						if (eventsInfos[selectedWorld][i]==selectedRoom)
							eventNum = Convert.ToInt32(AllEvents[selectedWorld][i][ValidIndex].Split(' ')[0],16);
			}
			if (WarpPopUpState<3)
			{
				WarpSet.Visible = true;
				warpSetStatus = 0;
				worldNum = selectedWorld+1;
				roomNum = selectedRoom;
				ToolCloseClick(null,null);
			}
		}
		
		int eventNum = 0;
		int roomNum = 0;
		int worldNum = 0;
		
		int warpSetStatus = 0;
		
		void WarpLock()
		{
			if (WarpSet.Visible==false||!IsTitlePassed) return;
			if (!IsMapLoaded&&warpSetStatus==0) warpSetStatus = 1;
			if (IsMapLoaded&&warpSetStatus==1) WarpSet.Visible = false;
			if (selectedWorld==6)
			{
				WriteInteger(0x2032BAE0,(short)0x0906);
				WriteInteger(0x2032BAE2,(byte)eventNum);
				WriteInteger(0x2032BAE4,(short)roomNum);
				WriteInteger(0x2032BAE6,(short)roomNum);
				WriteInteger(0x2032BAE8,(short)roomNum);
			}
			else
			{
				WriteInteger(0x2032BAE0,(byte)worldNum);
				WriteInteger(0x2032BAE1,(short)roomNum);
				WriteInteger(0x2032BAE4,(short)eventNum);
				WriteInteger(0x2032BAE6,(short)eventNum);
				WriteInteger(0x2032BAE8,(short)eventNum);
			}
		}
		
		public void WarpSetClick(object sender, EventArgs e)
		{
			WarpSet.Visible = false;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	}
}
