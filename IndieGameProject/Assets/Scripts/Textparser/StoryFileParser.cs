using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;


namespace TextParser
{
    public class StoryFileParser : IEnumerator<Sentence>
    {
        private readonly TextAsset _storyFile;
        private readonly Sentence[] _sentences;
        private int curIndex;
        private Sentence curSentence;

        public StoryFileParser(TextAsset file)
        {
            _storyFile = file;
            _sentences = _storyFile.text.Split('\n').Select(line => new Sentence(line)).ToArray();
            curIndex = -1;
            curSentence = null;
        }
        
        public bool MoveNext()
        {
            if (++curIndex >= _sentences.Length) return false;
            curSentence = _sentences[curIndex];
            return true;
        }
        
        public void Reset()
        {
            curIndex = -1;
        }

        public Sentence Current => curSentence;

        object IEnumerator.Current => Current;
        
        public void Dispose() { }
    }
}

