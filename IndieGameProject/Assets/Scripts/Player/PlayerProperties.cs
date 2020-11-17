using System;
using System.Collections.Generic;
using Path;
using UnityEngine;


namespace Player
{
    [Serializable]
    public class PlayerProperties
    {
        [SerializeField]
        [Header("Movement")]
        public float movementSpeed;

        [Header("Spawn")]
        public Transform spawnPoint;

        [Header("Path")]
        public List<Point> paths;

        [Header("Pathway")]
        public Pathway pathway;

        public List<Point> path;
        
        [NonSerialized]
        public int CurrentPoint = 0;
    }
}
