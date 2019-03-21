namespace AcademyDocker.DataContract.Data.Permissions
{
    public class Permission
    {
        public Role[] Roles { get; set; }
        public int Id { get; set; }
        public string Value { get; set; }
        public string Scope { get; set; }
        public string Description { get; set; }
    }
}
