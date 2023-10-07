public struct DataUser
{
    public readonly string Name
    {
        get => Name;
        private set => Name = value;
    }

    public void SetNameUser(string UserName)
    {
        if (UserName != null)
            Name = UserName;
    }
}