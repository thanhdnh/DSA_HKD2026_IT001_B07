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

public class BucketHash{
   private const int SIZE = 10;
   ArrayList[] data;
   public BucketHash(){
      data = new ArrayList[SIZE];
      for(int i=0; i<=SIZE-1; i++)
         data[i] = new ArrayList(4);
   }
   public int Hash(string s){//hash function
      long tot = 0;
      char[] chararray;
      chararray = s.ToCharArray();
      for(int i=0; i<=s.Length-1; i++)
         tot+=37*tot+(int)chararray[i];
      tot=tot%data.GetUpperBound(0);
      if(tot<0)
         tot+=data.GetUpperBound(0);
      return (int)tot;
   }
   public void Insert(string item){
      int hash_value = Hash(item);
      if(!data[hash_value].Contains(item))
         data[hash_value].Add(item);
   }
   public void Remove(string item){
      int hash_value = Hash(item);
      if(data[hash_value].Contains(item))
         data[hash_value].Remove(item);
   }
}
public class Program
{
  public static void Main(string[] args)
  {
    /*
    PhoneList contact = new PhoneList();
    contact.Add("Nam", "0123001");
    contact.Add("Hoa", "0123002");
    contact.Add("Xuan", "0123003");
    Console.WriteLine($"User Nam: {contact.SearchByUser("Hoa")}");
    Console.WriteLine($"Phone 0123002: {contact.SearchByPhoneNumber("0123002")}");
    */

    string[] keys = {
                        "Nam",
                        "Bình",
                        "Minh",
                        "Xuân",
                        "Hạ",
                        "Thu",
                        "Đông",
                        "Mai",
                        "Đào",
                        "Bích",
                        "Lê",
                        "Mận"
                    };
    for(int i=0; i<keys.Length; i++)
        Console.WriteLine(keys[i] + " => " + (new BucketHash()).Hash(keys[i]));
  }
}