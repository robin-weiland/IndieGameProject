using UnityEngine;


namespace Path
{
    public class Point : MonoBehaviour
    {
        [SerializeField]
        [Range(0, 100)]
        public int localLerpTime;

        public WordController.WordController wordController;

        public int LerpTimer { get; private set; }

        protected int Active = 1;
        public bool Reached { get; set; }

        public Vector3 Location { get; private set; }
        
        public bool IsWord { get; protected set; }

        public bool isEnd;

        private void Start()
        {
            _Start();
        }

        protected void _Start()
        {
            LerpTimer = localLerpTime > 0 ? localLerpTime : GetComponentInParent<Pathway>().globalLerpTime;
            Location = gameObject.transform.position;
        }

        public override string ToString()
        {
            return $"Point at [{Location.x}, {Location.y}, {Location.z}] with lerp time of {LerpTimer}";
        }

        public int IsActive()
        {
            return Active;
        }
    }
}