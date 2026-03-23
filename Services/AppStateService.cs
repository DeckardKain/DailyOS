using Blazored.LocalStorage;
using DailyOS.Models;

namespace DailyOS.Services;

public class AppStateService
{
    private readonly ILocalStorageService _storage;
    private readonly SupabaseService _supa;

    public Dictionary<string, bool> Checks { get; set; } = new();
    public string Note { get; set; } = "";
    public Dictionary<string, DayHistory> History { get; set; } = new();
    public List<TaskItem> Tasks { get; set; } = new();
    public List<Anchor> UserAnchors { get; set; } = new();
    public List<ScheduleItem> UserWeekdaySchedule { get; set; } = new();
    public List<ScheduleItem> UserWeekendSchedule { get; set; } = new();
    public bool IsLoaded { get; private set; }

    public Guid? UserId { get; private set; }
    public string? Username { get; private set; }
    public string? UserEmoji { get; private set; }
    public bool IsLoggedIn => UserId.HasValue;

    public string Today => DateTime.Now.ToString("yyyy-MM-dd");
    public string DayName => DateTime.Now.ToString("dddd");
    public string DateDisplay => DateTime.Now.ToString("MMMM d");
    public bool IsWeekend => DateTime.Now.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;

    public List<Anchor> ActiveAnchors => UserAnchors.Count > 0 ? UserAnchors : AppData.Anchors;
    public List<ScheduleItem> ActiveWeekdaySchedule => UserWeekdaySchedule.Count > 0 ? UserWeekdaySchedule : AppData.WeekdaySchedule;
    public List<ScheduleItem> ActiveWeekendSchedule => UserWeekendSchedule.Count > 0 ? UserWeekendSchedule : AppData.WeekendSchedule;

    public int CompletedCount => Checks.Values.Count(v => v);
    public int TotalAnchors => ActiveAnchors.Count;
    public int Percentage => TotalAnchors > 0 ? (int)Math.Round(100.0 * CompletedCount / TotalAnchors) : 0;

    public AppStateService(ILocalStorageService storage, SupabaseService supa)
    {
        _storage = storage;
        _supa = supa;
    }

    public async Task LoadAsync()
    {
        try
        {
            var uid = await _storage.GetItemAsync<string>("dos-user-id");
            if (Guid.TryParse(uid, out var id)) UserId = id;
            Username = await _storage.GetItemAsync<string>("dos-username");
            UserEmoji = await _storage.GetItemAsync<string>("dos-user-emoji");
        }
        catch { }

        try
        {
            var day = await _storage.GetItemAsync<DayRecord>($"dos-day-{Today}");
            if (day != null)
            {
                Checks = day.Checks ?? new();
                Note = day.Note ?? "";
            }
        }
        catch { }

        try
        {
            var hist = await _storage.GetItemAsync<Dictionary<string, DayHistory>>("dos-history");
            if (hist != null) History = hist;
        }
        catch { }

        try
        {
            var tasks = await _storage.GetItemAsync<List<TaskItem>>("dos-tasks");
            Tasks = tasks ?? AppData.DefaultTasks.Select(t => new TaskItem
            {
                Id = t.Id, Text = t.Text, Category = t.Category, Done = t.Done
            }).ToList();
        }
        catch
        {
            Tasks = AppData.DefaultTasks.Select(t => new TaskItem
            {
                Id = t.Id, Text = t.Text, Category = t.Category, Done = t.Done
            }).ToList();
        }

        try
        {
            var anchors = await _storage.GetItemAsync<List<Anchor>>("dos-anchors");
            if (anchors != null) UserAnchors = anchors;
        }
        catch { }

        try
        {
            var wd = await _storage.GetItemAsync<List<ScheduleItem>>("dos-schedule-weekday");
            if (wd != null) UserWeekdaySchedule = wd;
            var we = await _storage.GetItemAsync<List<ScheduleItem>>("dos-schedule-weekend");
            if (we != null) UserWeekendSchedule = we;
        }
        catch { }

        IsLoaded = true;
    }

    // ── Auth ──────────────────────────────────────────

    public async Task LoginAsync(Guid userId, string username, string? emoji)
    {
        UserId = userId;
        Username = username;
        UserEmoji = emoji;
        await _storage.SetItemAsync("dos-user-id", userId.ToString());
        await _storage.SetItemAsync("dos-username", username);
        if (emoji != null) await _storage.SetItemAsync("dos-user-emoji", emoji);
    }

    public async Task LogoutAsync()
    {
        UserId = null;
        Username = null;
        UserEmoji = null;
        await _storage.RemoveItemAsync("dos-user-id");
        await _storage.RemoveItemAsync("dos-username");
        await _storage.RemoveItemAsync("dos-user-emoji");
    }

    // ── Anchors CRUD ─────────────────────────────────

    public async Task ToggleAnchorAsync(string id)
    {
        Checks[id] = !Checks.GetValueOrDefault(id);
        await SaveDayAsync();
    }

    public async Task AddAnchorAsync(string label, string group, string icon)
    {
        var id = $"a{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
        if (UserAnchors.Count == 0)
            UserAnchors = AppData.Anchors.Select(a => new Anchor { Id = a.Id, Label = a.Label, Group = a.Group, Icon = a.Icon }).ToList();
        UserAnchors.Add(new Anchor { Id = id, Label = label, Group = group, Icon = icon });
        await _storage.SetItemAsync("dos-anchors", UserAnchors);
    }

    public async Task RemoveAnchorAsync(string id)
    {
        if (UserAnchors.Count == 0)
            UserAnchors = AppData.Anchors.Select(a => new Anchor { Id = a.Id, Label = a.Label, Group = a.Group, Icon = a.Icon }).ToList();
        UserAnchors.RemoveAll(a => a.Id == id);
        Checks.Remove(id);
        await _storage.SetItemAsync("dos-anchors", UserAnchors);
        await SaveDayAsync();
    }

    // ── Schedule CRUD ────────────────────────────────

    public async Task AddScheduleItemAsync(bool weekend, string time, string task, string category, string duration)
    {
        var list = weekend ? UserWeekendSchedule : UserWeekdaySchedule;
        if (list.Count == 0)
        {
            var source = weekend ? AppData.WeekendSchedule : AppData.WeekdaySchedule;
            list.AddRange(source.Select(s => new ScheduleItem { Time = s.Time, Task = s.Task, Category = s.Category, Duration = s.Duration }));
            if (weekend) UserWeekendSchedule = list; else UserWeekdaySchedule = list;
        }
        list.Add(new ScheduleItem { Time = time, Task = task, Category = category, Duration = duration });
        list.Sort((a, b) => string.Compare(a.Time, b.Time, StringComparison.Ordinal));
        await _storage.SetItemAsync(weekend ? "dos-schedule-weekend" : "dos-schedule-weekday", list);
    }

    public async Task RemoveScheduleItemAsync(bool weekend, int index)
    {
        var list = weekend ? UserWeekendSchedule : UserWeekdaySchedule;
        if (list.Count == 0)
        {
            var source = weekend ? AppData.WeekendSchedule : AppData.WeekdaySchedule;
            list.AddRange(source.Select(s => new ScheduleItem { Time = s.Time, Task = s.Task, Category = s.Category, Duration = s.Duration }));
            if (weekend) UserWeekendSchedule = list; else UserWeekdaySchedule = list;
        }
        if (index >= 0 && index < list.Count) list.RemoveAt(index);
        await _storage.SetItemAsync(weekend ? "dos-schedule-weekend" : "dos-schedule-weekday", list);
    }

    // ── Notes ────────────────────────────────────────

    public async Task SaveNoteAsync(string note)
    {
        Note = note;
        await SaveDayAsync();
    }

    private async Task SaveDayAsync()
    {
        var record = new DayRecord { Date = Today, Checks = Checks, Note = Note };
        await _storage.SetItemAsync($"dos-day-{Today}", record);

        History[Today] = new DayHistory { Pct = Percentage, Done = CompletedCount, Total = TotalAnchors };
        await _storage.SetItemAsync("dos-history", History);

        if (UserId.HasValue)
        {
            _ = _supa.SyncDailyRecord(UserId.Value, Today, Checks, Note, Percentage, CompletedCount, TotalAnchors);
        }
    }

    // ── Tasks ────────────────────────────────────────

    public async Task SaveTasksAsync() => await _storage.SetItemAsync("dos-tasks", Tasks);

    public async Task AddTaskAsync(string text, string category)
    {
        Tasks.Add(new TaskItem
        {
            Id = $"t{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}",
            Text = text, Category = category, Done = false
        });
        await SaveTasksAsync();
    }

    public async Task ToggleTaskAsync(string id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task != null) task.Done = !task.Done;
        await SaveTasksAsync();
    }

    public async Task DeleteTaskAsync(string id)
    {
        Tasks.RemoveAll(t => t.Id == id);
        await SaveTasksAsync();
    }

    // ── Streak / History ─────────────────────────────

    public int GetStreak()
    {
        int streak = 0;
        var date = DateTime.Now;
        for (int i = 0; i < 60; i++)
        {
            var key = date.ToString("yyyy-MM-dd");
            if (History.TryGetValue(key, out var entry))
            {
                if (entry.Pct >= 70) { streak++; date = date.AddDays(-1); }
                else break;
            }
            else if (i == 0) { date = date.AddDays(-1); }
            else break;
        }
        return streak;
    }

    public List<(string Label, string Key, DayHistory? Data, bool IsToday)> GetLast7()
    {
        var days = new List<(string, string, DayHistory?, bool)>();
        for (int i = 6; i >= 0; i--)
        {
            var d = DateTime.Now.AddDays(-i);
            var key = d.ToString("yyyy-MM-dd");
            History.TryGetValue(key, out var data);
            days.Add((d.ToString("ddd"), key, data, key == Today));
        }
        return days;
    }

    // ── Reset ────────────────────────────────────────

    public async Task ResetTodayAsync()
    {
        Checks = new();
        Note = "";
        await _storage.RemoveItemAsync($"dos-day-{Today}");
    }

    public async Task ResetEverythingAsync()
    {
        Checks = new(); Note = ""; History = new();
        Tasks = AppData.DefaultTasks.Select(t => new TaskItem { Id = t.Id, Text = t.Text, Category = t.Category, Done = t.Done }).ToList();
        UserAnchors = new(); UserWeekdaySchedule = new(); UserWeekendSchedule = new();
        await _storage.RemoveItemAsync($"dos-day-{Today}");
        await _storage.RemoveItemAsync("dos-history");
        await _storage.RemoveItemAsync("dos-tasks");
        await _storage.RemoveItemAsync("dos-anchors");
        await _storage.RemoveItemAsync("dos-schedule-weekday");
        await _storage.RemoveItemAsync("dos-schedule-weekend");
    }
}
