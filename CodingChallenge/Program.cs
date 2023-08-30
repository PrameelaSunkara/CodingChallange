using CodingChallenge.Model;
using Newtonsoft.Json;



public partial class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        LoadCustomerData(app);

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    public static List<Customer> customers { get; set; }
    public static string FileName { get; set; } 
    public static void LoadCustomerData(WebApplication? app)
    {
        try
        {

            FileName = Path.Combine(app.Environment.ContentRootPath, "Data", "CustomerDetails.json");
            string jsonData = File.ReadAllText(FileName);
            customers = JsonConvert.DeserializeObject<List<Customer>>(jsonData);
        }
        catch
        {
            customers = new List<Customer>();
        }
    }
}
