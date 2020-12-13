using System;
using Path;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField]
        public PlayerProperties properties = new PlayerProperties();

        private int _elapsedFrames;
        private bool _seenOnce;

        private void Start()
        {
            foreach (Transform child in properties.pathway.transform)
                properties.Path.Add(child.gameObject.GetComponent<Point>());

            if (properties.Path.Count < 1) throw new ArgumentException("Pathway empty!");
            gameObject.transform.position = properties.Path[properties.CurrentPoint].Location;
        }

        private void FixedUpdate()
        {
            if (properties.CurrentPoint == properties.Path.Count) return;
            
            properties.Path[properties.CurrentPoint].Reached = true;
            
            if (properties.Path[properties.CurrentPoint].isEnd)
                SceneManager.LoadScene(1 - SceneManager.GetActiveScene().buildIndex);
            
            if (properties.Path[properties.CurrentPoint].IsWord)
                foreach (var label in properties.Path[properties.CurrentPoint].wordController.labels)
                    label.gameObject.SetActive(true);
            
            switch (properties.Path[properties.CurrentPoint].IsActive())
            {
                case -1:
                    // CameraBehaviour.Shake(0.4f, 0.25f);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    return;
                case 0: return;
                case 1:
                    break;
            }
            var interpolationRatio = _elapsedFrames / properties.Path[properties.CurrentPoint].LerpTimer;
            
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
                                                         properties.Path[properties.CurrentPoint].Location,
                                                          interpolationRatio
            );
            
            _elapsedFrames = (_elapsedFrames + 1) % (properties.Path[properties.CurrentPoint].LerpTimer + 1);

            if (_elapsedFrames > 0) return;
            
            properties.Path[properties.CurrentPoint].Reached = false;
            if (properties.Path[properties.CurrentPoint].IsWord)
                foreach (var label in properties.Path[properties.CurrentPoint].wordController.labels)
                    label.gameObject.SetActive(false);
            properties.CurrentPoint++;
        }
    }
}
