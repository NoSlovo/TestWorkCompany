public struct DataUser
{
    public string Name
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