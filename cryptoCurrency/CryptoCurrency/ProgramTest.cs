using Xunit;

public class ProgramTest {

    Converter converter = new Converter();

    [Fact]
    public void add_new_currency() {
        // arrange
        string newCurrency = "cryptoCoin";
        double newCurrencyPrice = 50;
    
        // act
        converter.SetPricePerUnit(newCurrency, newCurrencyPrice);

        // assert
        Assert.True(converter.currency.ContainsKey(newCurrency));
        Assert.Equal(newCurrencyPrice, converter.currency[newCurrency]);
    }


    [Fact]
    public void update_new_currency() {
        // arrange
        string newCurrency = "cryptoCoin";
        double newCurrencyPrice = 50;
        double updateprice = 48;
        converter.SetPricePerUnit(newCurrency, newCurrencyPrice);
    
        // act
        converter.SetPricePerUnit(newCurrency, updateprice);

        // assert
        Assert.Equal(updateprice, converter.currency[newCurrency]);
    }

    [Fact]
    public void add_new_currency_negative_price() {
        // arrange
        string newCurrency = "cryptoCoin";
        double newCurrencyPrice = -5;
    
        // act

        // assert
        Assert.Throws<ArgumentException>(() => converter.SetPricePerUnit(newCurrency, newCurrencyPrice));
    }

    [Fact]
    public void get_currency_conversion_not_in_directory() {
        // arrange
        converter.SetPricePerUnit("cryptoCoin", 50);
        converter.SetPricePerUnit("nextCoin", 45);
    
        // act

        // assert
        Assert.Throws<ArgumentException>(() => converter.Convert("cryptoCoin", "notACoin", 5));
    }
    [Fact]
    public void get_currency_conversion_negative_value() {
        // arrange
        converter.SetPricePerUnit("cryptoCoin", 50);
        converter.SetPricePerUnit("nextCoin", 45);
    
        // act

        // assert
        Assert.Throws<ArgumentException>(() => converter.Convert("cryptoCoin", "nextCoin", -5));
    }

    [Fact]
    public void get_currency_conversion() {
        // arrange
        converter.SetPricePerUnit("cryptoCoin", 50);
        converter.SetPricePerUnit("nextCoin", 45);
    
        // act

        // assert
        Assert.Equal(4.5, converter.Convert("cryptoCoin", "nextCoin", 5));
    }

}