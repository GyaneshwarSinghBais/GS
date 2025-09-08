namespace GS_API.DTO
{
    public class UpdateCancellationRequest
    {
        public DateTime? cancellationDate { get; set; }
        public string? batchno { get; set; }
    }
}
