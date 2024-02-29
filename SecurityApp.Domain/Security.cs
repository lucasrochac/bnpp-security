namespace SecurityApp.Domain
{
    public class Security
    {
        public string Isin { get; set; }
        public decimal Price { get; set; }

        public bool IsValid() 
        { 
            return !string.IsNullOrEmpty(Isin) || Isin.Length == 12; 
        }
    }
}