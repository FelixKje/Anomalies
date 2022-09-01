using System;
public interface ICurrencyHolder {
    public event Action<int> ValueChanged;
    public int Amount { get; set; }
}