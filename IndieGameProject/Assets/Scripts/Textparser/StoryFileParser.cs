using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace TextParser
{
    public class StoryFileParser : IEnumerator<Sentence>
    {
        private readonly Sentence[] _sentences;
        private int _curIndex;
        private Sentence _curSentence;

        public StoryFileParser(TextAsset file)
        {
            _sentences = file.text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(line => new Sentence(line)).ToArray();
            _curIndex = -1;
            _curSentence = null;
        }
        
        public bool MoveNext()
        {
            if (++_curIndex >= _sentences.Length) return false;
            _curSentence = _sentences[_curIndex];
            return true;
        }
        
        public void Reset()
        {
            _curIndex = -1;
        }

        public Sentence Current => _curSentence;

        object IEnumerator.Current => Current;
        
        public void Dispose() { }
    }
}

