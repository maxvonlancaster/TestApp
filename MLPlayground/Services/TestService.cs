﻿using Microsoft.ML;
using MLPlayground.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLPlayground.Services
{
    public class TestService
    {
        private readonly MLContext _context;

        private string[] _inputDataPaths;

        public TestService()
        {
            _context = new MLContext();
            _inputDataPaths[0] = "..//DataSets//COTW//countries of the world.csv";
        }

        public void GetTrainAndTestData() 
        {
            // load from csv
            var dataView = _context.Data.LoadFromTextFile<Country>(_inputDataPaths[0], hasHeader: true, separatorChar: ',');
            // Split the data randomly, in 90:10 ratio, for training and evaluation data respectively.
            var data = _context.Data.TrainTestSplit(dataView, testFraction: 0.1);
        }


    }
}
