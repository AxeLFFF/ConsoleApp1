using System;
using System.Collections.Generic;
using System.Text;
using Google.Cloud.Speech.V1;

namespace ConsoleApp1
{
    public static class TextToSpeechProvider
    {
        public static void Audio2Text(string filepath)
        {
            var speechClient = SpeechClient.Create();
            var response = speechClient.Recognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                SampleRateHertz = 16000,
                LanguageCode = "ru"
            }, RecognitionAudio.FromFile(filepath));
            foreach(var result in response.Results)
            {
                foreach(var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }
        }
    }
}
