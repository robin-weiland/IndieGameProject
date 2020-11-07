using System.Collections.Generic;
using System.Text;


namespace TextParser
{

    public class Sentence
    {
        private const string Spacing = "[+]";

        private readonly string _line;
        private readonly List<string> _keywords;

        public Sentence(string line)
        {
            _keywords = new List<string>();
            var lineBuilder = new StringBuilder();
            var keywordBuilder = new StringBuilder();
            var inKey = false;
            
            foreach (var c in line)
            {
                switch (c)
                {
                    case '[':
                        inKey = true;
                        keywordBuilder.Clear();
                        lineBuilder.Append(Spacing);
                        break;
                    case '|':
                        _keywords.Add(keywordBuilder.ToString().Trim());
                        keywordBuilder.Clear();
                        break;
                    case ']':
                        inKey = false;
                        _keywords.Add(keywordBuilder.ToString().Trim());
                        break;
                    default:
                    {
                        if (inKey) keywordBuilder.Append(c);
                        else lineBuilder.Append(c);
                        break;
                    }
                }
            }
            
            _line = lineBuilder.ToString();
        }

        public override string ToString()
        {
            return _line + " : [" + string.Join(", ", _keywords) + "]";
        }

        public string this[int i] => _keywords[i];

        public int KeywordCount()
        {
            return _keywords.Count;
        }

        public bool HasKeywords()
        {
            return KeywordCount() > 0;
        }

        public string Line => _line;

        public List<string> Keywords => _keywords;
    }
}
