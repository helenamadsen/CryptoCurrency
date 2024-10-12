﻿public class Converter {
    public Dictionary<string, double> currency = new Dictionary<string, double>();
    //Main method
    public static void Main(string[] args) {}

    /// <summary>
    /// Angiver prisen for en enhed af en kryptovaluta. Prisen angives i dollars.
    /// Hvis der tidligere er angivet en værdi for samme kryptovaluta, 
    /// bliver den gamle værdi overskrevet af den nye værdi
    /// </summary>
    /// <param name="currencyName">Navnet på den kryptovaluta der angives</param>
    /// <param name="price">Prisen på en enhed af valutaen målt i dollars. Prisen kan ikke være negativ</param>
    public void SetPricePerUnit(String currencyName, double price) {
        // If price is negative don't do anything 
        if (price < 0)
            throw new ArgumentException("Price must be a non-negative value");

        // if currency is already in dictionary, update price value
        if(currency.ContainsKey(currencyName)) {
            currency[currencyName] = price;
        }
        else { 
            // else add new currency
            currency.Add(currencyName, price);
        }
    }

    /// <summary>
    /// Konverterer fra en kryptovaluta til en anden. 
    /// Hvis en af de angivne valutaer ikke findes, kaster funktionen en ArgumentException
    /// 
    /// </summary>
    /// <param name="fromCurrencyName">Navnet på den valuta, der konverterers fra</param>
    /// <param name="toCurrencyName">Navnet på den valuta, der konverteres til</param>
    /// <param name="amount">Beløbet angivet i valutaen angivet i fromCurrencyName</param>
    /// <returns>Værdien af beløbet i toCurrencyName</returns>
    public double Convert(String fromCurrencyName, String toCurrencyName, double amount) {
               
        // if one currency is not in dictionary throw argumentException
        if (!currency.ContainsKey(fromCurrencyName) || !currency.ContainsKey(toCurrencyName))
            throw new ArgumentException("Currency does not exist in dictionary");

        // if amount is negative throw argumentException
        if (amount < 0)
            throw new ArgumentException("Amount was negative");

        // store currency prices
        double fromPrice = currency[fromCurrencyName];
        double toPrice = currency[toCurrencyName];

        // calculate and return new currency worth.
        return amount * (toPrice / fromPrice);
    }
}