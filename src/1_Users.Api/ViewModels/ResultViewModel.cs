namespace Users.Api.ViewModels
{
    public class ResultViewModel
    {
        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public dynamic Data { get; set; }
    }
}