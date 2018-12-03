using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace World.Models
{
  public class Country
  {
    private int _population;
    private string _name;
    private string _continent;


    public Country (int population, string name, string continent)
    {
      _population = population;
      _name = name;
      _continent = continent;
    }

    public int GetPopulation()
    {
      return _population;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetContinent()
    {
      return _continent;
    }

    public void SetPopulation(int newPopulation)
    {
      _population = newPopulation;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public void SetContinent(string newContinent)
    {
      _continent = newContinent;
    }


    public static List<Country> GetAll()
    {
      //return _instances;

      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
          string countryName = rdr.GetString(1);
          string countryContinent = rdr.GetString(2);
          int countryPopulation = rdr.GetInt32(6);

          Country newCountry = new Country(countryPopulation, countryName, countryContinent);
          allCountries.Add(newCountry);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      return allCountries;

    }
    public static List<Country> GetCountryInfo(string name)
    {
      //return _instances;

      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country WHERE Name = '" + name + "';";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
          string countryName = rdr.GetString(1);
          string countryContinent = rdr.GetString(2);
          int countryPopulation = rdr.GetInt32(6);

          Country newCountry = new Country(countryPopulation, countryName, countryContinent);
          allCountries.Add(newCountry);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      return allCountries;

    }
    //
    // public static void ClearAll()
    // {
    //   _instances.Clear();
    // }



    // public static Country Find(int searchPopulation)
    // {
    //   return _instances[searchId-1];
    // }

  }
}
