using Microsoft.ML;
using MLPlayground.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLPlayground.Services
{
    public class TestService
    {
        private readonly MLContext _context;

        public string[] _inputDataPaths;

        public TestService()
        {
            _context = new MLContext();
            _inputDataPaths = new string[] { "..//DataSets//COTW//countries of the world.csv" };
        }

        public void GetTrainAndTestData() 
        {
            // load from csv
            var dataView = _context.Data.LoadFromTextFile<Country>(_inputDataPaths[0], hasHeader: true, separatorChar: ',');

            // Split the data randomly, in 90:10 ratio, for training and evaluation data respectively.
            var data = _context.Data.TrainTestSplit(dataView, testFraction: 0.1);

        }

        public ITransformer TrainModel(IDataView dataView) 
        {
            // Construct training pipeline:
            // - handle missing values
            // - create a column for the output by copying the one we want to predict to the expected name "Label"
            // - create a column for all features using the expected name "Features"
            // - apply a regression

            throw new NotImplementedException();
        }


    }
}
