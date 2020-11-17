using System;
using System.Collections.Generic;
using System.Linq;
using General;
using Path;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField]
        public PlayerProperties properties = new PlayerProperties();

        private int _elapsedFrames;

        private void Start()
        {
            foreach (Transform child in properties.pathway.transform)
                properties.path.Add(child.gameObject.GetComponent<Point>());

            if (properties.path.Count < 1) throw new ArgumentException("Pathway invalid!");
            gameObject.transform.position = properties.path[properties.CurrentPoint].Location;
            
        }

        private void FixedUpdate()
        {
            if (properties.CurrentPoint == properties.path.Count) return;
            
            properties.path[properties.CurrentPoint].reached = true;
            
            if (properties.path[properties.CurrentPoint].isWord)
                foreach (var label in properties.path[properties.CurrentPoint].wordController.labels)
                    label.gameObject.SetActive(true);
            
            switch (properties.path[properties.CurrentPoint].IsActive())
            {
                case -1:
                    CameraBehaviour.Shake(0.4f, 0.25f);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    return;
                case 0: return;
                case 1:
                    break;
            }
            
            if (properties.path[properties.CurrentPoint].lerpTimer == 0) Debug.Log(properties.CurrentPoint);
            var interpolationRatio = _elapsedFrames / properties.path[properties.CurrentPoint].lerpTimer;
            
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
                                                         properties.path[properties.CurrentPoint].Location,
                                                          interpolationRatio
            );
            
            _elapsedFrames = (_elapsedFrames + 1) % (properties.path[properties.CurrentPoint].lerpTimer + 1);

            if (_elapsedFrames > 0) return;
            
            properties.path[properties.CurrentPoint].reached = false;
            if (properties.path[properties.CurrentPoint].isWord)
                foreach (var label in properties.path[properties.CurrentPoint].wordController.labels)
                    label.gameObject.SetActive(false);
            properties.CurrentPoint++;
        }
    }
}
