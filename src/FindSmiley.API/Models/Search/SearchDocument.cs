using System;
using System.Collections.Generic;

namespace FindSmiley.API.Models.Search
{
    public class SearchDocument
    {
        public Virksomhed Virksomhed { get; set; }
        public string Text { get; set; }
    }
}