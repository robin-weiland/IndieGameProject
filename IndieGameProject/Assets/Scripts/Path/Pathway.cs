using System;
using UnityEngine;


namespace Path
{
   public class Pathway : MonoBehaviour
   {
       [SerializeField]
       [Range(0, 100)]
       public int globalLerpTime;

       private void Start()
       {
           for(var i = 0; i < transform.childCount; i++)
               transform.GetChild(i).localScale = new Vector3(0, 0, 0);
       }
   }
}
