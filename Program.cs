using System.Collections;

public class PhoneList:DictionaryBase
{
    public void Add(string user, string phonenumber)
    {
        this.InnerHashtable.Add(user, phonenumber);
    }
    public string Item(string user)
    {
        return this.InnerHashtable[user].ToString();
    }
    public void Remove(string user)
    {
        this.InnerHashtable.Remove(user);
    }
    public bool SearchByUser(string user)
    {
        foreach (DictionaryEntry x in this.InnerHashtable)
        {
            if(x.Key.ToString() == user) return true;
        }
        return false;
    }
    public bool SearchByPhoneNumber(string phonenumber)
    {
        foreach(DictionaryEntry so in this.InnerHashtable)
        {
            if(so.Value.ToString()==phonenumber)return true;
        }
        return false;
    }
}
public class Program
{
  public static void Main(string[] args)
  {
    PhoneList contact = new PhoneList();
    contact.Add("Nam", "0123001");
    contact.Add("Hoa", "0123002");
    contact.Add("Xuan", "0123003");
    Console.WriteLine($"User Nam: {contact.SearchByUser("Hoa")}");
    Console.WriteLine($"Phone 0123002: {contact.SearchByPhoneNumber("0123002")}");
  }
}