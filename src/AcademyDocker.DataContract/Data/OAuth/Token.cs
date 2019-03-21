namespace AcademyDocker.DataContract.Data.OAuth
{
    public class Token
    {
        public string Access_Token { get; set; }

        public string Token_Type { get; set; }

        public int Expires_In { get; set; }

        public string Scope { get; set; }

        public string Creation_offset_date_time { get; set; }

        public string Tenant { get; set; }

        public string Jti { get; set; }
    }
}