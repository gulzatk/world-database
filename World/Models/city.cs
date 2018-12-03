using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace World.Models
{
  public class City
  {
    private int _id;
    private string _name;
    private string _countryCode;


    public City (int id, string name, string countryCode)
    {
      _id = id;
      _name = name;
      _countryCode = countryCode;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetCountryCode()
    {
      return _countryCode;
    }

    public void SetId(int newId)
    {
      _id = newId;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public void SetCountryCode(string newCountryCode)
    {
      _countryCode = newCountryCode;
    }


    public static List<City> GetAll()
    {
      //return _instances;

      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
          int cityId = rdr.GetInt32(0);
          string cityName = rdr.GetString(1);
          string cityCountryCode = rdr.GetString(2);

          City newCity = new City(cityId, cityName, cityCountryCode);
          allCities.Add(newCity);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      return allCities;

    }
    //
    // public static void ClearAll()
    // {
    //   _instances.Clear();
    // }



    // public static City Find(int searchId)
    // {
    //   return _instances[searchId-1];
    // }

  }
}
