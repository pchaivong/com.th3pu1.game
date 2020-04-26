using UnityEngine;


namespace PuiGame.RPGGameEngine
{
    public class RPGInputController : MonoBehaviour
    {

        #region Singleton
        private static RPGInputController _instance;
        public static RPGInputController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (RPGInputController)FindObjectOfType(typeof(RPGInputController));
                    if (_instance == null)
                    {
                        var singletonObj = new GameObject();
                        _instance = singletonObj.AddComponent<RPGInputController>();
                        singletonObj.name = typeof(RPGInputController).ToString() + " (Singleton)";
                        DontDestroyOnLoad(singletonObj);
                    }
                }

                return _instance;
            }
        }
        #endregion

        public delegate void GroundSelectedHandler(Vector3 point);
        public delegate void ObjectSelectedHandler(Transform target);

        public static GroundSelectedHandler onGroundSelected;
        public static ObjectSelectedHandler onObjectSelected;

        [SerializeField]
        private Transform groundRef;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Vector3 point;
            Transform obj;

            if (CheckGroundHit(out point))
            {
                if (onGroundSelected != null) onGroundSelected.Invoke(point);
            }
            else if (CheckObjectHit(out obj)) {
                if (onObjectSelected != null) onObjectSelected.Invoke(obj);
            }
        }

        private bool CheckGroundHit(out Vector3 point)
        {
            point = Vector3.zero;
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform == groundRef)
                    {
                        point = hit.point;
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckObjectHit(out Transform obj)
        {
            obj = null;

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform != groundRef)
                    {
                        obj = hit.transform;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

