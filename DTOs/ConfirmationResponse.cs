namespace MahalliyMarket.DTOs;

public class ConfirmationResponse
{
    string message { get; set; }

    public ConfirmationResponse(string message)
    {
        this.message = message;
    }
}
