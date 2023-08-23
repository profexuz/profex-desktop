﻿namespace Profex_ViewModels.Vacancies;

public class Vacancy
{
    public long Id { get; set; }
    public long CategoryId { get; set; }
    public long UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public double Longitude { get; set; }
    public double Latidute { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public List<string> ImagePath { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
