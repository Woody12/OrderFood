using System;

public enum Category
{
    american,
    chinese,
    greek,
    mexican
}

[Serializable]
public struct Menu
{
    public int id;
    public Category category;
    public MenuDetail[] menuDetails;
}

[Serializable]
public struct MenuDetail
{
    public string name;
    public string detail;
    public string imageName;
    public float price;
}

[Serializable]
public struct Restaurant
{
    public Category category;
    public string name;
    public string address;
    public string city;
    public string state;
    public string zip;
}
