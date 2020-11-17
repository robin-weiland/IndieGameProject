using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Path
{
    public class WordPoint : Point
    {
        // [SerializeField]
        // public WordController.WordController wordController;

        private void Start()
        {
            _Start();
            foreach (var label in wordController.labels)
                label.gameObject.SetActive(false);
            isWord = true;
            Active = 0;
        }

        private void Update()
        {
            if (reached) Active = wordController.status;
        }
    }
}
