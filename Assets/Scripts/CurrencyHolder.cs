using System;

public class CurrencyHolder : ICurrencyHolder {
    public event Action<int> ValueChanged;
    private int amount;
        
    public int Amount
    {
        get=> amount;
        set
        {
            amount = value;
            ValueChanged?.Invoke(value);
        }
    }
}