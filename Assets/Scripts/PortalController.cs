using UnityEngine;

namespace Assets.Scripts
{
    public class PortalController : MonoBehaviour
    {
        // Use this for initialization
        public bool IsPortaling = false;

        private GameObject _otherPortal;
        private GameObject _clone;
        private Joint _joint;
        private bool _initialPositive;

        private Color[] _colors =
        {
            Color.red,
            Color.blue,
            Color.green,
            Color.cyan,
        };


        void Start()
        {
            Color color = _colors[gameObject.transform.parent.parent.GetSiblingIndex() % _colors.Length];
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", color);
            gameObject.transform.parent.Find("Marker").GetComponent<Renderer>().material.SetColor("_Color", color);


            if (gameObject.transform.parent.name == "Portal_A")
            {
                _otherPortal = gameObject.transform.parent.parent.Find("Portal_B").Find("EventHorizon").gameObject;
            }
            else if (gameObject.transform.parent.name == "Portal_B")
            {
                _otherPortal = gameObject.transform.parent.parent.Find("Portal_A").Find("EventHorizon").gameObject;
            }
        }


        void OnTriggerEnter(Collider player)
        {
            if (player.tag != "Player")
            {
                return;
            }

            if (IsPortaling)
            {
                return;
            }


            IsPortaling = true;
            _otherPortal.GetComponent<PortalController>().IsPortaling = true;

            Vector3 playerOffset = player.transform.position - gameObject.transform.position;


            _clone = Instantiate(player.gameObject, _otherPortal.transform.position + playerOffset, transform.rotation);

            _clone.gameObject.AddComponent<FixedJoint>();
            _joint = _clone.GetComponent<FixedJoint>();
            _joint.connectedBody = player.GetComponent<Rigidbody>();


            _initialPositive = transform.InverseTransformPoint(player.transform.position).z > 0;
        }

        void OnTriggerExit(Collider player)
        {
            if (player.tag != "Player")
            {
                return;
            }


            float z = transform.InverseTransformPoint(player.transform.position).z;
            if (_initialPositive && z < 0 || !_initialPositive && z > 0)
            {
                Transform t = _clone.transform;
                Destroy(_clone);
                player.gameObject.transform.position = t.position;
            }
            else
            {
                Destroy(_clone);
            }

            IsPortaling = false;
            _otherPortal.GetComponent<PortalController>().IsPortaling = false;
        }
    }
}