using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using College.UI;
using College.UI.Interfaces;
using College.UI.Services;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

var uriBase = "https://localhost:7106/";

builder
    .Services.AddHttpClient<IGradeStudentService, GradeStudentService>()
    .ConfigureHttpClient(httpClient =>
    {
        httpClient.BaseAddress = new Uri(uriBase);
    });

builder
    .Services.AddHttpClient<IGradeService, GradeService>()
    .ConfigureHttpClient(httpClient =>
    {
        httpClient.BaseAddress = new Uri(uriBase);
    });

builder
    .Services.AddHttpClient<IStudentService, StudentService>()
    .ConfigureHttpClient(httpClient =>
    {
        httpClient.BaseAddress = new Uri(uriBase);
    });

builder
    .Services.AddHttpClient<ITeacherService, TeacherService>()
    .ConfigureHttpClient(httpClient =>
    {
        httpClient.BaseAddress = new Uri(uriBase);
    });


builder.Services.AddBlazoredToast();
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<DialogService>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();