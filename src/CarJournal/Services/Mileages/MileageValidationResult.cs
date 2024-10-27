namespace CarJournal.Services.Mileages;

public class MileageValidationResult
{
    public bool IsValid { get; private set; }
    public string ErrorMessage { get; private set; }

    public MileageValidationResult(bool isValid)
    {
        IsValid = isValid;
        ErrorMessage = string.Empty;
    }

    public MileageValidationResult(bool isValid, string errorMessage)
    {
        IsValid = isValid;
        ErrorMessage = errorMessage;
    }
}