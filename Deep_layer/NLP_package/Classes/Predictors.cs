﻿using Microsoft.ML;
using System.Collections.Generic;
using System;

namespace NLP_package
{
    public class Predictor : IPredictor {
        public string predict(string chat_text_message, string model_name, Dictionary<bool, string> map)
        {
            MLContext mlContext = new MLContext();
            DataViewSchema modelSchema;

            ITransformer model = mlContext.Model.Load(model_name, out modelSchema);

            PredictionEngine<SentimentData, SentimentPrediction> predictionFunction = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
            SentimentData sampleStatement = new SentimentData
            {
                SentimentText = chat_text_message
            };
            var resultPrediction = predictionFunction.Predict(sampleStatement);
            return map[Convert.ToBoolean(resultPrediction.Prediction)];
        }
    }
}