namespace Models
{
    public class UserResult
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool? Result { get; set; }

        public string ResultText => Result switch
        {
            null => "Не завершено",
            false => "Поражение",
            true => "Победа"
        } + (Score == null ? "" : ", " + Score + " очков");

        public int? Score { get; set; }
    }
}