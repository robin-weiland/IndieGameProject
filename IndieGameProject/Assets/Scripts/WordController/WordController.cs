using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


namespace WordController
{
    public class WordController : MonoBehaviour
    {
        private StringBuilder _word;
        public List<string> words;
        public List<Text> labels;
        public int Status { get; private set; }
    
        private void Start()
        {
            _word = new StringBuilder();
        }
    
        private void Update()
        {
            foreach (var c in Input.inputString)
                switch (c)
                {
                    case '\b' when _word.Length != 0:
                        _word.Remove(_word.Length - 1, 1);
                        break;
                    case '\n':
                    case '\r':
                        print("User entered their name: " + _word);
                        break;
                    default:
                        _word.Append(c);
                        break;
                }
            
            foreach (var word in words)
            {
                if (word == _word.ToString())
                {
                    Status = 1;
                    return;
                }
                if (!word.StartsWith(_word.ToString())) continue;
                Status = 0;
                return;
            }
            Status = -1;
        }
    }
}
