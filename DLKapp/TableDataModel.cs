namespace DLKapp
{
    public class TableDataObject
    {
        // Model for the data sets from DLK. The data will probably have to get get converted from SQL in it's own layer,
        // then the objects get initialized.
        public TableDataObject(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public string name { get; set; }
        public string description { get; set; }
    }
}
