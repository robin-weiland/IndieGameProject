using System.Collections;
using UnityEngine;


namespace General
{
    public class CameraBehaviour : MonoBehaviour
    {
        //Shake
        private static CameraBehaviour _instance;
        private Vector3 _originalPos;
        private float _timeAtCurrentFrame;
        private float _timeAtLastFrame;
        private float _fakeDelta;

        private void Awake()
        {
            _instance = this;
        }
        
        private void Update()
        {
            _timeAtCurrentFrame = Time.realtimeSinceStartup;
            _fakeDelta = _timeAtCurrentFrame - _timeAtLastFrame;
            _timeAtLastFrame = _timeAtCurrentFrame;

        }

        public static void Shake(float duration, float amount)
        {
            _instance._originalPos = _instance.gameObject.transform.localPosition;
            _instance.StopAllCoroutines();
            _instance.StartCoroutine(_instance._shake(duration, amount));
        }

        private IEnumerator _shake(float duration, float amount)
        {
            // while (duration > 0)
            // {
                transform.localPosition = _originalPos + Random.insideUnitSphere * amount;
                duration -= _fakeDelta;
                yield return null;
            // }
            transform.localPosition = _originalPos;
        }
    }
}
