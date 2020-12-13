namespace Path
{
    public class WordPoint : Point
    {
        public CountdownTimer countdownTimer;
        private void Start()
        {
            _Start();
            foreach (var label in wordController.labels)
                label.gameObject.SetActive(false);
            IsWord = true;
            Active = 0;
            //countdownTimer.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (!Reached) return;
            //countdownTimer.gameObject.SetActive(true);
            // GetComponent<TimeBar>().gameObject.SetActive(true);
            Active = wordController.Status;
        }
    }
}
