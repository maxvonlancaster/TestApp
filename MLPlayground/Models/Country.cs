using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLPlayground.Models
{
    public class Country
    {
        [LoadColumn(0)]
        public string Code;

        [LoadColumn(1)]
        public string Name;

        [LoadColumn(3)]
        public float HappinessScore;

        [LoadColumn(4)]
        public float Population;
    }
}
