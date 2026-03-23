namespace DailyOS.Models;

public class DayRecord
{
    public string Date { get; set; } = "";
    public Dictionary<string, bool> Checks { get; set; } = new();
    public string Note { get; set; } = "";
}

public class DayHistory
{
    public int Pct { get; set; }
    public int Done { get; set; }
    public int Total { get; set; }
}

public class TaskItem
{
    public string Id { get; set; } = "";
    public string Text { get; set; } = "";
    public string Category { get; set; } = "";
    public bool Done { get; set; }
}

public class Anchor
{
    public string Id { get; set; } = "";
    public string Label { get; set; } = "";
    public string Group { get; set; } = "";
    public string Icon { get; set; } = "";
}

public class ScheduleItem
{
    public string Time { get; set; } = "";
    public string Task { get; set; } = "";
    public string Category { get; set; } = "";
    public string Duration { get; set; } = "";
}

public class WorkoutDay
{
    public string Day { get; set; } = "";
    public string Type { get; set; } = "";
    public string Notes { get; set; } = "";
}

public class MacroInfo
{
    public string Nutrient { get; set; } = "";
    public string Target { get; set; } = "";
    public string Why { get; set; } = "";
    public string Sources { get; set; } = "";
}

public class MealInfo
{
    public string Meal { get; set; } = "";
    public string Items { get; set; } = "";
    public string Prep { get; set; } = "";
}

public class EssentialInfo
{
    public string Category { get; set; } = "";
    public string Items { get; set; } = "";
    public string Priority { get; set; } = "";
}

public class CategoryColor
{
    public string Bg { get; set; } = "";
    public string Text { get; set; } = "";
    public string Border { get; set; } = "";
}
