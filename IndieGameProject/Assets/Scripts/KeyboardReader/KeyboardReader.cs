using TextParser;
using UnityEngine;


namespace KeyboardReader
{
    public class KeyboardReader : MonoBehaviour
    {
        private bool _active;
        public Sentence Sentence;

        private void Start()
        {
            _active = true;
            if (_active) {}
        }

        private void OnGUI()
        {
            {
                var e = Event.current;
                if (e != null && e.isKey)
                {
                    Debug.Log("Detected key code: " + e.keyCode);
                }
            }
        }
    }
}
