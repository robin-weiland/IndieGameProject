using UnityEngine;


namespace Path
{
    public class Point : MonoBehaviour
    {
        [SerializeField]
        [Range(0, 100)]
        public int localLerpTime = 100;

        public WordController.WordController wordController = null;

        public int lerpTimer;

        protected int Active  = 1;
        public bool reached = false;

        public Vector3 Location { private set; get; }

        public bool isWord = false;

        private void Start()
        {
            _Start();
        }

        protected void _Start()
        {
            lerpTimer = localLerpTime > 0 ? localLerpTime : GetComponentInParent<Pathway>().globalLerpTime;
            Location = gameObject.transform.position;
        }

        public override string ToString()
        {
            return $"Point at [{Location.x}, {Location.y}, {Location.z}] with lerp time of {lerpTimer}";
        }

        public int IsActive()
        {
            return Active;
        }
    }
}