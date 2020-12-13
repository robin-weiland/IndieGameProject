using UnityEngine;


namespace Path
{
   public class Pathway : MonoBehaviour
   {
       [SerializeField]
       [Range(0, 100)]
       public int globalLerpTime;
        
       // TODO vefify whether this is really faster than doing it individually in Point
       private void Awake()
       {
           for(var i = 0; i < transform.childCount; i++)
               transform.GetChild(i).localScale = new Vector3(0, 0, 0);
       }
   }
}
