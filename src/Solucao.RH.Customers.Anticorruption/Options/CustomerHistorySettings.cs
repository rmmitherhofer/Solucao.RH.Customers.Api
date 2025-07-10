namespace Solucao.RH.Customers.Anticorruption.Options;

public class CustomerHistorySettings
{
    internal const string SECTION_NAME = "Apis:CustomerHistory";
    public string BaseAddress { get; set; }
    public CustomerHistoryEndpoints EndPoints { get; set; }
}

public class CustomerHistoryEndpoints
{
    public string HistCustomer { get; set; }
    public string HistContact { get; set; }
    public string HistAddress { get; set; }
}
