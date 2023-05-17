using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TerrainScannerDEMO
{
    public class ConstantSensor : MonoBehaviour
    {
        [SerializeField] private Material _sensorMaterial;
        
        private GeneralAIController _klaxonAI;
        private float _distance;

        public bool _allowed;

        private void Start()
        {
            _klaxonAI = GameObject.FindObjectOfType<GeneralAIController>();

            _distance = _klaxonAI.klaxonRange;
        }

        private void OnDisable()
        {
            _sensorMaterial.SetFloat("_Radius", 0);
        }

        private void Update()
        {
            _sensorMaterial.SetVector("_RevealOrigin", transform.position);
        }

        public void HoverKlaxon()
        {
            if (!_allowed) { return; }
            _sensorMaterial.SetFloat("_Radius", _distance);
        }

        public void StopHoverKlaxon()
        {
            if (!_allowed) { return; }
            _sensorMaterial.SetFloat("_Radius", 0);
        } 
    }
}

