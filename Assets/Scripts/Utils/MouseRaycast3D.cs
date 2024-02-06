using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

namespace Utils
{
    public class MouseRaycast3D : MonoBehaviour
    {
        [Header("  Settings  ")] [SerializeField]
        private Camera mainCamera;

        [SerializeField] private LayerMask interactableObjects;

        [Header("   Debug Settings  ")] [SerializeField]
        private bool debug;

        [SerializeField] private bool drawLine = true;
        [SerializeField] private bool drawSphere = true;
        [SerializeField] private Color defaultDebugColor = Color.green;
        [SerializeField] private float debugSphereRadius = 1f;
        private Dictionary<int, Color> _raycastedLayerColors = new();

        private RaycastHit _raycastHit;


        private void Start()
        {
            if (mainCamera == null) mainCamera = Camera.main;
        }


        private void FixedUpdate()
        {
            CastRayFromCamera();
        }

        private void CastRayFromCamera()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (!IsMouseClickedOverUI() &&
                Physics.Raycast(ray, out _raycastHit, float.MaxValue, interactableObjects))
            {
            }
        }

        private bool IsMouseClickedOverUI()
        {
            if (EventSystem.current.IsPointerOverGameObject()) // Clicked on UI
                return true;

            return false;
        }

        public Transform CurrentTransform => _raycastHit.transform;


        #region Debug

        private void OnDrawGizmos()
        {
            if (!debug || _raycastHit.collider == null) return;

            int layer = _raycastHit.transform.gameObject.layer;

            if (!_raycastedLayerColors.ContainsKey(LayerMask.NameToLayer("Default")))
                _raycastedLayerColors.Add(LayerMask.NameToLayer("Default"), defaultDebugColor);
            if (!_raycastedLayerColors.ContainsKey(layer))
                _raycastedLayerColors.Add(layer, GenerateColor(_raycastedLayerColors.Count));


            Gizmos.color = _raycastedLayerColors[layer];

            if (drawSphere) Gizmos.DrawSphere(_raycastHit.point, debugSphereRadius);
            if (drawLine) Gizmos.DrawLine(mainCamera.transform.position, _raycastHit.point);
        }

        private Color GenerateColor(int number)
        {
            const float max = 360f;
            const float cycleStep = max / 32f;
            const float
                hueQuarter = max / 4f; //colors are grouped in sets of 4 to increase their differentiation on hsv space

            int colorIndex = number % 4;
            float colorShift = hueQuarter * colorIndex; //shift on 1/32 every 5-th color on hue coordinate 

            Color.RGBToHSV(defaultDebugColor, out float startHue, out _,
                out _); // colors starts from default color 

            int cycleNumber = number / 4;
            float hue = startHue * max + colorShift + cycleNumber * cycleStep;
            hue = (hue % max) / max;

            const float saturationStep = (1 - 0.3f) / 8;
            float saturation = 1f - saturationStep * cycleNumber;
            return Random.ColorHSV(hue, hue,
                saturation, saturation,
                1f, 1f);
        }

        #endregion
    }
}