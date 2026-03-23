using System.Net.Http.Json;
using System.Text.Json;
using DailyOS.Models;

namespace DailyOS.Services;

public class SupabaseService
{
    private readonly HttpClient _http;
    private static readonly JsonSerializerOptions JsonOpts = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    public SupabaseService(HttpClient http) => _http = http;

    private HttpRequestMessage BuildRequest(HttpMethod method, string url, object? body = null)
    {
        var req = new HttpRequestMessage(method, url);
        req.Headers.Add("Prefer", "return=representation");
        if (body != null)
            req.Content = JsonContent.Create(body, options: JsonOpts);
        return req;
    }

    // ── Auth ──────────────────────────────────────────
    public async Task<Guid> RegisterUser(string username, string? emoji)
    {
        var resp = await _http.PostAsJsonAsync("/rest/v1/rpc/register_user", new
        {
            p_username = username.Trim().ToLower(),
            p_display_emoji = emoji
        }, JsonOpts);
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadFromJsonAsync<Guid>(JsonOpts);
    }

    public async Task<bool> UsernameExists(string username)
    {
        var list = await _http.GetFromJsonAsync<List<JsonElement>>(
            $"/rest/v1/users?username=eq.{username.Trim().ToLower()}&limit=1", JsonOpts);
        return list?.Count > 0;
    }

    // ── Daily Records ──────────────────────────────────
    public async Task SyncDailyRecord(Guid userId, string date, Dictionary<string, bool> checks, string note, int pct, int done, int total)
    {
        try
        {
            var req = BuildRequest(HttpMethod.Post, "/rest/v1/daily_records", new
            {
                user_id = userId,
                date,
                checks,
                note,
                completion_pct = pct,
                base_points = 0,
                streak_multiplier = 1.0,
                adjusted_base = 0,
                tier_bonuses = 0,
                cheer_points = 0,
                task_points = 0,
                total_points = 0,
                pinocchio_points = 0,
                streak_day = 0
            });
            req.Headers.Remove("Prefer");
            req.Headers.Add("Prefer", "resolution=merge-duplicates,return=representation");
            var resp = await _http.SendAsync(req);
            // If conflict, update instead
            if (!resp.IsSuccessStatusCode)
            {
                var patch = BuildRequest(HttpMethod.Patch,
                    $"/rest/v1/daily_records?user_id=eq.{userId}&date=eq.{date}", new
                    {
                        checks,
                        note,
                        completion_pct = pct
                    });
                await _http.SendAsync(patch);
            }
        }
        catch { /* Fail silently — localStorage is primary */ }
    }

    public async Task RecalcDaily(Guid userId, string date)
    {
        try
        {
            await _http.PostAsJsonAsync("/rest/v1/rpc/recalc_daily_record", new
            {
                p_user_id = userId,
                p_date = date
            }, JsonOpts);
        }
        catch { }
    }

    // ── Leaderboard ──────────────────────────────────
    public async Task<List<LeaderboardRow>> GetOverallLeaderboard()
    {
        try
        {
            return await _http.GetFromJsonAsync<List<LeaderboardRow>>(
                "/rest/v1/leaderboard_overall?limit=50&order=adjusted_total.desc", JsonOpts) ?? new();
        }
        catch { return new(); }
    }

    public async Task<List<LeaderboardRow>> GetStreakLeaderboard()
    {
        try
        {
            return await _http.GetFromJsonAsync<List<LeaderboardRow>>(
                "/rest/v1/leaderboard_streak?limit=50&order=current_streak.desc", JsonOpts) ?? new();
        }
        catch { return new(); }
    }

    public async Task<List<LeaderboardRow>> GetPinocchioLeaderboard()
    {
        try
        {
            return await _http.GetFromJsonAsync<List<LeaderboardRow>>(
                "/rest/v1/leaderboard_pinocchio?limit=50&order=total_pinocchio.desc", JsonOpts) ?? new();
        }
        catch { return new(); }
    }
}

public class LeaderboardRow
{
    [System.Text.Json.Serialization.JsonPropertyName("user_id")]
    public Guid UserId { get; set; }
    [System.Text.Json.Serialization.JsonPropertyName("username")]
    public string Username { get; set; } = "";
    [System.Text.Json.Serialization.JsonPropertyName("display_emoji")]
    public string? DisplayEmoji { get; set; }
    [System.Text.Json.Serialization.JsonPropertyName("adjusted_total")]
    public long AdjustedTotal { get; set; }
    [System.Text.Json.Serialization.JsonPropertyName("total_pinocchio")]
    public long TotalPinocchio { get; set; }
    [System.Text.Json.Serialization.JsonPropertyName("current_streak")]
    public int CurrentStreak { get; set; }
}
