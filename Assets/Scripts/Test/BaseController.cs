using UnityEngine;

namespace Test
{
    public class BaseController : MonoBehaviour
    {
        public float x = 0;
        public float y = 1;
    
        // Start is called before the first frame update
        protected virtual void Start()
        {
        
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            var verticalVec = Vector3.up * y;
            var horizontalVec = Vector3.right * x;
            var sumVec = (verticalVec + horizontalVec) * speed;
            
            transform.Translate(sumVec * Time.deltaTime, Space.World);
        }

        public float speed = 3.0f;
    }
}