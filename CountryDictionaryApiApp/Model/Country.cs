namespace CountryDictionaryApiApp.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISO31661Alpha2Code { get; set; }
        public string ISO31661Alpha3Code { get; set; }
        public string ISO31661NumericCode { get; set; }
        public Country(): this(0, string.Empty, string.Empty, string.Empty, string.Empty) { }
        public Country(int id, string name, string iSO31661Alpha2Code, string iSO31661Alpha3Code, string iSO31661NumericCode)
        {
            Id = id;
            Name = name;
            ISO31661Alpha2Code = iSO31661Alpha2Code;
            ISO31661Alpha3Code = iSO31661Alpha3Code;
            ISO31661NumericCode = iSO31661NumericCode;
        }
        public override string ToString()
        {
            return $"{Id} - {Name} -{ISO31661Alpha2Code} - {ISO31661Alpha3Code} - {ISO31661NumericCode}";
        }
    }
}
