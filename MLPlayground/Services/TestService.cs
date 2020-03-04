using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLPlayground.Services
{
    public class TestService
    {
        private readonly MLContext _mLContext;

        private string _inputDataPath;

        public TestService()
        {
            _mLContext = new MLContext();
        }


    }
}
