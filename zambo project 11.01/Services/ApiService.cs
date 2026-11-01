using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace zambo_project_11__01.Services
{
    public class BodyPart { public int Id { get; set; } public string Name { get; set; } = ""; public int RecoveryStatus { get; set; } public string StatusColor { get; set; } = ""; }
    public class Workout { public int Id { get; set; } public string Title { get; set; } = ""; public string TargetMuscle { get; set; } = ""; public int DurationMinutes { get; set; } public string GoalType { get; set; } = ""; }
    public class DietPlan { public int Id { get; set; } public string MealName { get; set; } = ""; public int Calories { get; set; } public int Protein { get; set; } public string Category { get; set; } = ""; }

    public static class ApiService
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5215/api/") };

        public static async Task<List<BodyPart>> GetBodyPartsAsync() => await client.GetFromJsonAsync<List<BodyPart>>("BodyParts") ?? new();
        public static async Task TrainBodyPartAsync(int id) => await client.PostAsync($"BodyParts/{id}/train", null);

        public static async Task<List<Workout>> GetWorkoutsAsync() => await client.GetFromJsonAsync<List<Workout>>("Workouts") ?? new();
        public static async Task GenerateWorkoutsAsync(string goal)
        {
            var content = new StringContent(JsonSerializer.Serialize(goal), Encoding.UTF8, "application/json");
            await client.PostAsync("Workouts/generate-plan", content);
        }

        public static async Task<List<DietPlan>> GetDietsAsync(string category) => await client.GetFromJsonAsync<List<DietPlan>>($"DietPlans/recommend/{category}") ?? new();
    }
}