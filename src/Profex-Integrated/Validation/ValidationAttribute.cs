using System.Text.RegularExpressions;

namespace Profex_Integrated.Validation;

public class ValidationAttribute
{
    public (bool isSuccessful, string Message) IsValidPhoneNumber(string phone_number)
    {
        if (phone_number is null) return (false, "Telefon raqami bo'sh bo'lishi mumkin emas!");

        Regex regex = new Regex(@"^[\+][0-9]{3}?[0-9]{9}$");
        if (regex.Match(phone_number.ToString()!).Success)
            return (true, " ");

        return (false, "To'g'ri telefon raqamini kiriting!");
    }
    public (bool isSuccessful, string Message) IsValidName(string name)
    {
        if (name is null) return (false, "Name can not be null!");

        Regex regex = new Regex(@"^[a-z,A-Z]{3,25}$");
        if (regex.Match(name.ToString()!).Success)
            return (true, " ");

        return (false, "Enter correct name!");
    }

    public (bool isSuccessful, string Message) IsValidTitle(string title)
    {
        if (title is null) return (false, "Sarlavha bo'sh bo'lishi mumkin emas!");

        Regex regex = new Regex(@"^[a-z,A-Z]{3,25}$");
        if (regex.Match(title.ToString()!).Success)
            return (true, " ");

        return (false, "Sarlavhani to'g'ri kiriting!");
    }

    public (bool isSuccessful, string Message) IsValidSurname(string name)
    {
        if (name is null) return (false, "Surname can not be null!");

        Regex regex = new Regex(@"^[a-z,A-Z]{3,25}$");
        if (regex.Match(name.ToString()!).Success)
            return (true, " ");

        return (false, "Enter correct surname!");
    }
    public (bool isSuccessful, string Message) IsValidRegion(string name)
    {
        if (name is null) return (false, "Mintaqa bo'sh bo'lishi mumkin emas!");

        Regex regex = new Regex(@"^[A-Za-z0-9 -]{3,30}$");
        if (regex.Match(name.ToString()!).Success)
            return (true, " ");

        return (false, "Mintaqani to'g'ri kiriting!");
    }
    public (bool isSuccessful, string Message) IsValidDistrict(string name)
    {
        if (name is null) return (false, "Tuman bo'sh bo'lishi mumkin emas!");

        Regex regex = new Regex(@"^[A-Za-z0-9 -]{3,30}$");
        if (regex.Match(name.ToString()!).Success)
            return (true, " ");

        return (false, "Tumandi to'g'ri kiriting!");
    }
    public (bool isSuccessful, string Message) IsValidPrice(string price)
    {
        if (price is null) return (false, "Narx bo'sh bo'lishi mumkin emas!");

        Regex regex = new Regex(@"^\d+(\.\d{1,2})?$");
        if (regex.Match(price.ToString()!).Success)
            return (true, " ");

        return (false, "Narxni to'g'ri kiriting! Misol: 123.45 yoki 500");
    }
    public (bool isSuccessful, string Message) IsValidDescription(string description)
    {
        if (description is null) return (false, "Tavsif bo'sh bo'lishi mumkin emas!");

        if (description.Length >= 10 && description.Length <= 500)
            return (true, " ");

        return (false, "Tavsifni to'g'ri kiriting! Tavsif 10 dan 500 belgiga to'g'ri kelishi kerak.");
    }
}
