using Microsoft.EntityFrameworkCore;
using SmartMedicinesTestAPi.Context;
using SmartMedicinesTestAPi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<MedicineDataContext>
    (option => 
    option.UseNpgsql("Host=localhost;Port=5432;Database=medicinesDb;Username=admin;Password=admin1234"));

builder.Services.AddSwaggerGen();

builder.Services.AddCors(c =>  
{  
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());  
});  

var app = builder.Build();

app.UseSwagger();

app.MapPost("AddMedicine", async (Medicine medicine, MedicineDataContext context) =>
{
    context.Medicine.Add(medicine);
    await context.SaveChangesAsync();
});

app.MapDelete("DeleteMedicine/{id}", async (int id, MedicineDataContext context) =>
{
    var medicineToDelete = await context.Medicine.FirstOrDefaultAsync(p => p.Id == id);
    if (medicineToDelete != null)
    {
        context.Medicine.Remove(medicineToDelete);
        await context.SaveChangesAsync();
    }
});

app.MapGet("GetListMedicines", async (MedicineDataContext context) =>
{
    return await context.Medicine.ToListAsync();
});

app.UseSwaggerUI();
app.Run();
