﻿namespace DLKapp
{
    public class TableDataObject
    {
        public TableDataObject(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public string name { get; set; }
        public string description { get; set; }
    }
}