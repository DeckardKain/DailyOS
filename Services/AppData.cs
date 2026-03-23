using DailyOS.Models;

namespace DailyOS.Services;

public static class AppData
{
    public static List<ScheduleItem> WeekdaySchedule => new()
    {
        new(){Time="6:00",Task="Wake + 500ml remineralized water",Category="water",Duration="5 min"},
        new(){Time="6:05",Task="Dream journal — capture everything, don't filter",Category="spirit",Duration="10 min"},
        new(){Time="6:15",Task="Pranayama — pick from your book, rotate practices",Category="spirit",Duration="10 min"},
        new(){Time="6:25",Task="Meditation — stillness, lower frequency, explore",Category="spirit",Duration="10 min"},
        new(){Time="6:35",Task="Morning stretch / physio exercises",Category="move",Duration="15 min"},
        new(){Time="6:50",Task="Guitar — focused skill session (overload block)",Category="guitar",Duration="20 min"},
        new(){Time="7:10",Task="Micro-nap (10 min, eyes closed, consolidate)",Category="rest",Duration="10 min"},
        new(){Time="7:20",Task="Grab morning fuel (protein balls + tea) + get ready",Category="nutrition",Duration="10 min"},
        new(){Time="7:30",Task="Get Zoe ready",Category="family",Duration="10 min"},
        new(){Time="7:40",Task="Drop off Zoe — eat protein balls in car, sip tea",Category="family",Duration="20 min"},
        new(){Time="8:00",Task="500ml water + settle in, mouse mover on",Category="water",Duration="5 min"},
        new(){Time="8:05",Task="STARTUP RITUAL → open project, read last note, set 1 target",Category="work",Duration="5 min"},
        new(){Time="8:10",Task="Dream project — Deep Work Block 1 (protect this)",Category="work",Duration="80 min"},
        new(){Time="9:30",Task="Check actual work (emails, messages)",Category="dayjob",Duration="15 min"},
        new(){Time="9:45",Task="STARTUP RITUAL → re-read target, resume",Category="work",Duration="5 min"},
        new(){Time="9:50",Task="Dream project — Deep Work Block 2",Category="work",Duration="70 min"},
        new(){Time="11:00",Task="500ml water + light snack if hungry",Category="water",Duration="15 min"},
        new(){Time="11:15",Task="Dream project or day job if needed",Category="work",Duration="45 min"},
        new(){Time="12:00",Task="F45 / Home workout / Physio day (rotate)",Category="move",Duration="60 min"},
        new(){Time="1:00",Task="Shower + first real meal",Category="nutrition",Duration="25 min"},
        new(){Time="1:25",Task="Greek nap — 20 min, set alarm, consolidate learning",Category="rest",Duration="20 min"},
        new(){Time="1:45",Task="500ml water",Category="water",Duration="5 min"},
        new(){Time="1:50",Task="STARTUP RITUAL → project state, 1 target, go",Category="work",Duration="5 min"},
        new(){Time="1:55",Task="Dream project — Deep Work Block 3 (post-nap clarity)",Category="work",Duration="50 min"},
        new(){Time="2:45",Task="Check actual work",Category="dayjob",Duration="15 min"},
        new(){Time="3:00",Task="15-min power clean (one zone per day)",Category="chores",Duration="15 min"},
        new(){Time="3:15",Task="Dream project or day job — last push",Category="work",Duration="60 min"},
        new(){Time="4:15",Task="Day close — save state, write where you left off",Category="work",Duration="15 min"},
        new(){Time="4:30",Task="Pick up Zoe",Category="family",Duration="30 min"},
        new(){Time="5:00",Task="Family time — be fully present, play with kids",Category="family",Duration="30 min"},
        new(){Time="5:30",Task="Dinner prep + cook (ground beef rotation, batch)",Category="nutrition",Duration="30 min"},
        new(){Time="6:00",Task="Family dinner — no screens",Category="family",Duration="30 min"},
        new(){Time="6:30",Task="Kids wind-down — bath, teeth, story, calm energy",Category="family",Duration="30 min"},
        new(){Time="7:00",Task="Kids in room / settled — lights low, firm boundary",Category="family",Duration="15 min"},
        new(){Time="7:15",Task="Kitchen cleanup",Category="chores",Duration="15 min"},
        new(){Time="7:30",Task="Guitar — relaxed noodling / review AM session",Category="guitar",Duration="20 min"},
        new(){Time="7:50",Task="Learning block — videos, reading, new ideas, study",Category="learn",Duration="30 min"},
        new(){Time="8:20",Task="Plan tomorrow (tasks, targets, meals)",Category="plan",Duration="10 min"},
        new(){Time="8:30",Task="Evening pranayama or meditation (different from AM)",Category="spirit",Duration="10 min"},
        new(){Time="8:40",Task="Wind-down — read, journal, relax. No screens.",Category="rest",Duration="20 min"},
        new(){Time="9:00",Task="500ml water + bed prep",Category="water",Duration="15 min"},
        new(){Time="9:15",Task="Lights out — 9hr sleep window",Category="rest",Duration=""},
    };

    public static List<ScheduleItem> WeekendSchedule => new()
    {
        new(){Time="7:00",Task="Wake + 500ml remineralized water",Category="water",Duration="5 min"},
        new(){Time="7:05",Task="Dream journal",Category="spirit",Duration="10 min"},
        new(){Time="7:15",Task="Pranayama — longer weekend session, go deeper",Category="spirit",Duration="15 min"},
        new(){Time="7:30",Task="Meditation — extended sit",Category="spirit",Duration="15 min"},
        new(){Time="7:45",Task="Morning stretch / physio",Category="move",Duration="15 min"},
        new(){Time="8:00",Task="Family breakfast — real food together",Category="nutrition",Duration="30 min"},
        new(){Time="8:30",Task="Guitar — focused overload session",Category="guitar",Duration="25 min"},
        new(){Time="8:55",Task="Micro-nap (consolidate guitar learning)",Category="rest",Duration="10 min"},
        new(){Time="9:05",Task="500ml water",Category="water",Duration="5 min"},
        new(){Time="9:10",Task="SAT: Groceries + errands / SUN: Meal prep (protein balls, eggs, veg)",Category="chores",Duration="50 min"},
        new(){Time="10:00",Task="Family time / park / social events",Category="family",Duration="60 min"},
        new(){Time="11:00",Task="CHORE BLOCK — whole family helps",Category="chores",Duration="45 min"},
        new(){Time="11:45",Task="Light lunch before activity",Category="nutrition",Duration="30 min"},
        new(){Time="12:15",Task="Get ready + travel to Gymnastics/Swimming",Category="family",Duration="50 min"},
        new(){Time="1:05",Task="SAT: Gymnastics / SUN: Swimming",Category="family",Duration="90 min"},
        new(){Time="2:35",Task="Travel home + 500ml water",Category="water",Duration="25 min"},
        new(){Time="3:00",Task="Greek nap — 20 min, recharge for evening",Category="rest",Duration="20 min"},
        new(){Time="3:20",Task="YOUR TIME — dream project, learning, or guitar",Category="work",Duration="40 min"},
        new(){Time="4:00",Task="500ml water + snack for everyone",Category="water",Duration="15 min"},
        new(){Time="4:15",Task="Free time / outdoor play / social",Category="family",Duration="45 min"},
        new(){Time="5:00",Task="Dinner prep + cook",Category="nutrition",Duration="45 min"},
        new(){Time="5:45",Task="Family dinner",Category="family",Duration="30 min"},
        new(){Time="6:15",Task="Kids wind-down — bath, teeth, story, calm energy",Category="family",Duration="30 min"},
        new(){Time="6:45",Task="Kids in room / settled — lights low, firm boundary",Category="family",Duration="15 min"},
        new(){Time="7:00",Task="Kitchen cleanup",Category="chores",Duration="15 min"},
        new(){Time="7:15",Task="Evening pranayama or meditation",Category="spirit",Duration="10 min"},
        new(){Time="7:25",Task="Plan the week + learning (videos, reading, ideas)",Category="plan",Duration="30 min"},
        new(){Time="7:55",Task="Wind-down — guitar noodling, read, relax",Category="rest",Duration="35 min"},
        new(){Time="8:30",Task="500ml water + bed prep",Category="water",Duration="15 min"},
        new(){Time="8:45",Task="In bed by 10:30 LATEST on weekends",Category="rest",Duration=""},
    };

    public static List<Anchor> Anchors => new()
    {
        new(){Id="spirit1",Label="Dream journal — recorded on waking",Group="Spiritual Practice",Icon="🌙"},
        new(){Id="spirit2",Label="Pranayama — morning session",Group="Spiritual Practice",Icon="🔥"},
        new(){Id="spirit3",Label="Meditation — sat in stillness",Group="Spiritual Practice",Icon="🕉️"},
        new(){Id="spirit4",Label="Evening practice (pranayama or meditation)",Group="Spiritual Practice",Icon="✨"},
        new(){Id="water1",Label="Morning water (500ml on waking)",Group="BMW — Water",Icon="💧"},
        new(){Id="water2",Label="Mid-morning water (500ml)",Group="BMW — Water",Icon="💧"},
        new(){Id="water3",Label="Afternoon water (500ml)",Group="BMW — Water",Icon="💧"},
        new(){Id="water4",Label="Evening water (500ml)",Group="BMW — Water",Icon="💧"},
        new(){Id="move1",Label="Morning stretch / physio",Group="BMW — Move",Icon="🏃"},
        new(){Id="move2",Label="Midday workout (F45 / home / physio)",Group="BMW — Move",Icon="💪"},
        new(){Id="nap1",Label="Took a recovery nap (10-20 min)",Group="Energy Collection",Icon="⚡"},
        new(){Id="eat1",Label="First meal — nutrient-dense, not heavy",Group="Nutrition",Icon="🥚"},
        new(){Id="eat2",Label="Second meal — home-cooked, clean",Group="Nutrition",Icon="🥩"},
        new(){Id="eat3",Label="Kids ate real food today",Group="Nutrition",Icon="👶"},
        new(){Id="work1",Label="Used startup ritual before deep work",Group="Dream Project",Icon="🔑"},
        new(){Id="work2",Label="Did real deep work on dream project",Group="Dream Project",Icon="🚀"},
        new(){Id="work3",Label="Chose project over gaming when tempted",Group="Dream Project",Icon="⚔️"},
        new(){Id="guitar1",Label="Focused guitar session + micro-nap",Group="Guitar",Icon="🎸"},
        new(){Id="plan1",Label="Planned tomorrow (tasks, meals, targets)",Group="Planning & Growth",Icon="📋"},
        new(){Id="learn1",Label="Learning block — consumed new ideas",Group="Planning & Growth",Icon="📖"},
        new(){Id="chore1",Label="15-min power clean (one zone)",Group="Home",Icon="🏠"},
        new(){Id="chore2",Label="Kitchen clean before bed",Group="Home",Icon="🍳"},
        new(){Id="kidbed",Label="Kids settled by 7:30 (the domino)",Group="Home",Icon="🌒"},
        new(){Id="weed",Label="No weed today ✓",Group="Discipline",Icon="🛡️"},
        new(){Id="screens",Label="No gaming during work hours",Group="Discipline",Icon="🎮"},
        new(){Id="sleep",Label="In bed on time",Group="Discipline",Icon="😴"},
    };

    public static List<WorkoutDay> Workouts => new()
    {
        new(){Day="Monday",Type="F45",Notes="Full class. Modified bicep movements."},
        new(){Day="Tuesday",Type="Physio + Light",Notes="Full physio program. 20-min walk or light home workout."},
        new(){Day="Wednesday",Type="F45",Notes="Focus on work capacity — build fresh."},
        new(){Day="Thursday",Type="Home Strength",Notes="Power rack. Squat, bench (light bicep), rows. 45 min."},
        new(){Day="Friday",Type="F45",Notes="End-of-week push."},
        new(){Day="Saturday",Type="Active Recovery",Notes="Walk with kids, physio stretches, mobility 20 min."},
        new(){Day="Sunday",Type="Physio + Optional",Notes="Full physio. Optional light bodyweight or rest."},
    };

    public static List<TaskItem> DefaultTasks => new()
    {
        new(){Id="t1",Text="Clear garage — make workout space usable, power rack accessible",Category="Environment",Done=false},
        new(){Id="t2",Text="Toy purge — keep 20%, donate/store rest. Less toys = less mess",Category="Environment",Done=false},
        new(){Id="t3",Text="Create kids zone — mat/rug, toy bin, bookshelf. Their space.",Category="Environment",Done=false},
        new(){Id="t4",Text="Fix desk area — paint the wall where shelf fell",Category="Environment",Done=false},
        new(){Id="t5",Text="Clean and organize desk — clear surface, cable manage",Category="Environment",Done=false},
        new(){Id="t6",Text="Set up kids bedtime station — nightlight, books, mat/bed",Category="Environment",Done=false},
        new(){Id="t7",Text="Sunday meal prep — protein balls, hard-boil eggs, prep veg",Category="Weekly Recurring",Done=false},
        new(){Id="t8",Text="Grocery run — plan meals, make list, buy for the week",Category="Weekly Recurring",Done=false},
        new(){Id="t9",Text="Catch up on guitar lessons — review what you've missed",Category="Growth",Done=false},
        new(){Id="t10",Text="Set up guitar practice station — tuner, book/tablet, chair",Category="Environment",Done=false},
        new(){Id="t11",Text="Deep clean kitchen — top to bottom, organize pantry",Category="Home Reset",Done=false},
        new(){Id="t12",Text="Laundry system — designate days, don't let it pile",Category="Home Reset",Done=false},
        new(){Id="t13",Text="Living space reset — clear surfaces, home for everything",Category="Home Reset",Done=false},
        new(){Id="t14",Text="Schedule physio follow-up for bicep",Category="Health",Done=false},
        new(){Id="t15",Text="Research quality collagen + electrolyte brands, order",Category="Health",Done=false},
        new(){Id="t16",Text="Buy or make bone broth — start daily habit",Category="Health",Done=false},
    };

    public static List<MealInfo> MealTiming => new()
    {
        new(){Meal="Morning Fuel (7:20am, grab-and-go)",Items="Protein balls from the fridge + hot tea. Eat while getting Zoe ready, finish in the car. Dense fuel to carry you to 1pm.",Prep="SUNDAY PREP: 1 cup oats, ½ cup nut butter, ⅓ cup raw honey, 2 scoops collagen, 2 tbsp cacao, 2 tbsp chia seeds, pinch salt. Roll 12-15 balls, fridge. Hard-boil 12 eggs as backup."},
        new(){Meal="Post-Workout Meal (1:00pm — first real meal)",Items="Ground beef bowl, leftover dinner, eggs + rice + avocado, or bone broth with meat and veg. Sit down, no screen, eat with intention.",Prep="Cook extra dinner the night before. Lunch = last night's leftovers. Zero extra effort."},
        new(){Meal="Family Dinner (6:00pm)",Items="Ground beef rotation. Cook enough for tomorrow's lunch. Kids eat what you eat — same meal, smaller portions.",Prep="Prep veg while kids play after pickup. 30 min cook max with ground beef."},
        new(){Meal="Between Meals",Items="Protein balls, handful of nuts, bone broth, apple + almond butter, or nothing. If not hungry, don't eat.",Prep=""},
    };

    public static List<MacroInfo> Macros => new()
    {
        new(){Nutrient="Protein",Target="100-130g/day",Why="Moderate, high-quality. Enough for muscle maintenance without taxing digestion.",Sources="Ground beef, pasture-raised eggs, wild salmon, bone broth, organ meats"},
        new(){Nutrient="Healthy Fats",Target="80-110g/day",Why="Primary sustained energy. Hormones, brain, joints. Cleanest fuel.",Sources="Grass-fed butter/ghee, tallow, avocado, EVOO, wild sardines"},
        new(){Nutrient="Complex Carbs",Target="100-200g/day",Why="Scale to activity. F45 days higher, rest days lower. Around workouts.",Sources="Sweet potato, white rice, squash, plantains, raw honey post-workout, seasonal fruit"},
        new(){Nutrient="Fiber",Target="25-35g/day",Why="Gut microbiome, blood sugar. Comes naturally from vegetables.",Sources="Cruciferous veg, leafy greens, berries, sauerkraut, cooked onions/garlic"},
    };

    public static List<EssentialInfo> Essentials => new()
    {
        new(){Category="Electrolytes",Items="Sodium (quality salt), Potassium, Magnesium — add to distilled water. Redmond Real Salt or LMNT.",Priority="critical"},
        new(){Category="Fat-Soluble Vitamins",Items="A (liver 1×/wk), D3+K2 (5000IU D3 daily, especially Vancouver), E (sunflower seeds, almonds)",Priority="critical"},
        new(){Category="B Vitamins",Items="B12 (red meat, eggs), B6 (poultry, fish), Folate (leafy greens, liver). Food > pills.",Priority="high"},
        new(){Category="Minerals",Items="Zinc (oysters, pumpkin seeds), Selenium (brazil nuts 2/day), Iron (red meat), Copper (liver, dark chocolate)",Priority="high"},
        new(){Category="Omega-3 (EPA/DHA)",Items="Wild salmon 2-3×/wk, sardines, or fish oil (Nordic Naturals). Target 2-3g EPA+DHA.",Priority="critical"},
        new(){Category="Gut Health",Items="Raw sauerkraut, kimchi, kefir/yogurt daily. Bone broth for gut lining. Prebiotics from onions, garlic, leeks.",Priority="high"},
        new(){Category="Antioxidants",Items="Blueberries, dark leafy greens, green tea, turmeric+black pepper, raw cacao.",Priority="medium"},
        new(){Category="Creatine",Items="5g monohydrate daily. Brain function, muscle recovery, energy.",Priority="high"},
        new(){Category="Adaptogens",Items="Ashwagandha (cortisol), Rhodiola (energy), Magnesium Glycinate (sleep, 400mg before bed)",Priority="medium"},
        new(){Category="Collagen",Items="Bone broth daily or collagen peptides (20g). Joints, tendons — especially bicep tendonitis.",Priority="high"},
    };

    public static List<string> AvoidList => new()
    {
        "Seed oils (canola, soybean, sunflower, safflower) — inflammatory",
        "Artificial sweeteners — gut microbiome disruption",
        "Ultra-processed foods — engineered to override satiety",
        "Conventional dairy (if tolerated, go raw/grass-fed only)",
        "Added sugars beyond raw honey or maple in small amounts",
        "Dirty Dozen produce — go organic for those",
        "Farm-raised fish — wild-caught only",
        "Overeating — even clean food. 2 focused meals > 3 bloated ones.",
        "Eating out of boredom — if not hungry, don't eat",
    };

    public static List<string> BeefRotation => new()
    {
        "MON: Beef + rice bowls — ground beef, white rice, sautéed greens, avocado, quality salt",
        "TUE: Shepherd's pie — beef, sweet potato mash, carrots, onions. Batch-friendly.",
        "WED: Lettuce wrap tacos — beef, salsa, cheese, avocado. Kids love building these.",
        "THU: Beef bone broth soup — slow simmer bones, add beef, root veg, greens.",
        "FRI: Burgers — thick patties, eggs on top, side of roasted veg",
        "SAT: Beef bolognese — zucchini noodles or pasta for kids. Tomato, garlic, herbs.",
        "SUN: Beef stir-fry — broccoli, peppers, coconut aminos, over rice.",
    };

    public static List<string> KidsNutrition => new()
    {
        "Swap: Goldfish → cheese + seed crackers, fruit leather → real dried fruit",
        "Smoothie trick: Spinach + frozen berries + banana + collagen — they won't taste greens",
        "Make it fun: Let them 'build' meals — tortilla + toppings, rice bowls, fruit kebabs",
        "80/20 rule: 80% real food, 20% whatever. Don't make it a battle.",
        "Always have cut fruit/veg visible at kid height in the fridge",
        "Cook together: Toddlers can wash, stir, pour. Ownership = willingness to eat it",
    };

    public static string[] TaskCategories => new[]
    {
        "Environment", "Home Reset", "Health", "Growth", "Weekly Recurring", "Dream Project", "Family", "Other"
    };

    public static Dictionary<string, CategoryColor> Colors => new()
    {
        ["water"] = new(){Bg="#1a3a4a",Text="#5bbfdf",Border="#2a5a6a"},
        ["spirit"] = new(){Bg="#1a1a3a",Text="#9b8bef",Border="#2a2a5a"},
        ["move"] = new(){Bg="#3a2a1a",Text="#df8b5b",Border="#5a4a3a"},
        ["nutrition"] = new(){Bg="#1a3a2a",Text="#5bdf8b",Border="#2a5a4a"},
        ["work"] = new(){Bg="#3a3a1a",Text="#dfdf5b",Border="#5a5a3a"},
        ["dayjob"] = new(){Bg="#2a2a2a",Text="#9a9a9a",Border="#4a4a4a"},
        ["family"] = new(){Bg="#3a1a2a",Text="#df5b8b",Border="#5a3a4a"},
        ["chores"] = new(){Bg="#2a3a3a",Text="#5bafaf",Border="#3a5a5a"},
        ["rest"] = new(){Bg="#1a1a2a",Text="#7b7baf",Border="#2a2a4a"},
        ["guitar"] = new(){Bg="#2a1a2a",Text="#cf7bdf",Border="#4a2a4a"},
        ["plan"] = new(){Bg="#2a2a1a",Text="#bfaf5b",Border="#4a4a2a"},
        ["learn"] = new(){Bg="#1a2a2a",Text="#5bafcf",Border="#2a4a4a"},
    };

    public static Dictionary<string, string> TaskColors => new()
    {
        ["Environment"] = "#df8b5b",
        ["Home Reset"] = "#5bafaf",
        ["Health"] = "#5bdf8b",
        ["Growth"] = "#cf7bdf",
        ["Weekly Recurring"] = "#dfdf5b",
        ["Dream Project"] = "#dfdf5b",
        ["Family"] = "#df5b8b",
        ["Other"] = "#8b949e",
    };
}
