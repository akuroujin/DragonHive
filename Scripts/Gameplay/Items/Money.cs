public class Money
{
    public Money() : this(gold: 10) { }
    public Money(int copper = 0, int silver = 0, int electrum = 0, int gold = 0, int platinum = 0)
    {
        int total = copper + silver * 10 + electrum * 50 + gold * 100 + platinum * 1000;
        this.Total = total;
    }
    public int Total = 0;
    public int Copper => Total % 10;
    public int Silver => Copper / 10 % 5;
    public int Electrum => Silver / 5 % 2;
    public int Gold => Electrum / 2 % 10;
    public int Platinum => Gold / 10;

    //Total
    public int TotalCopper => Total;
    public int TotalSilver => TotalCopper / 10;
    public int TotalElectrum => TotalElectrum / 5;
    public int TotalGold => TotalElectrum / 2;
    public int TotalPlatinum => TotalGold / 10;

}
