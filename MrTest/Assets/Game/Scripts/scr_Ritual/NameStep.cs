using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using UnityEngine.Windows.Speech;

public class NameStep : RitualStep
{
    /*
        [SerializeField]string phraseToRecognize;
        private KeywordRecognizer recognizer;
        private ConfidenceLevel confidence = ConfidenceLevel.Low;
        private Dictionary<string,Action> recognizerWords = new Dictionary<string,Action>();
        // Start is called once before the first execution of Update after the MonoBehaviour is created


        protected override void CheckCompleteStep()
        {
            if(!activeStep) return;
            START_STEP?.Invoke();
            recognizerWords.Add(phraseToRecognize,CompleteStep);
            recognizer = new KeywordRecognizer(recognizerWords.Keys.ToArray(),confidence);
            recognizer.OnPhraseRecognized += OnKeywordRecognized;
            recognizer.Start();
        }

        void CompleteStep()
        {
            FINISH_STEP?.Invoke();
        }

        void OnKeywordRecognized(PhraseRecognizedEventArgs args)
        {
            recognizerWords[args.text]?.Invoke();
        }

        public override void StopStep()
        {
            base.StopStep();
            recognizer.Stop();
        }*/
    protected override void CheckCompleteStep()
    {
        throw new NotImplementedException();
    }
}
