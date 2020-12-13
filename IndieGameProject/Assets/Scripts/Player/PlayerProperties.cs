using System;
using System.Collections.Generic;
using Path;
using UnityEngine;


namespace Player
{
    [Serializable]
    public class PlayerProperties
    {
        [Header("Pathway")]
        public Pathway pathway;

        [NonSerialized]
        public List<Point> Path = new List<Point>();
        
        [NonSerialized]
        public int CurrentPoint = 0;
    }
}
