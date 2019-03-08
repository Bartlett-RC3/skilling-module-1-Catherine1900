using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using SpatialSlur;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(StackModel))]
    [RequireComponent(typeof(StackAnalyser))]
    public partial class StackDisplay : MonoBehaviour
    {
        // TODO process OnModelReset event
        // TODO reference "AnalysisResults" scriptable object rather than "StackAnalyser"

        [SerializeField] private CellDisplayMode _displayMode = CellDisplayMode.Age;
        [Space(12)]
        [SerializeField] private Material _ageMaterial;
        [SerializeField] private int _ageDisplayMin = 0;
        [SerializeField] private int _ageDisplayMax = 10;
        [Space(12)]



        private StackModel _model;
        private StackAnalyser _analyser;
        private MaterialPropertyBlock _properties;
        private int _currentLayer; // index of the most recently updated layer

        IEnumerator colorChanger;

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _model = GetComponent<StackModel>();
            _analyser = GetComponent<StackAnalyser>();
            _properties = new MaterialPropertyBlock();
            ResetDisplay();
        }


        /// <summary>
        /// 
        /// </summary>
        private void LateUpdate()
        {
            // reset display if necessary
            if (_currentLayer > _model.CurrentLayer)
                ResetDisplay();

            // update analysis if model has been updated
            if (_currentLayer < _model.CurrentLayer)
                UpdateDisplay();
        }


        /// <summary>
        /// 
        /// </summary>
        private void UpdateDisplay()
        {
            colorChanger = ChangeColor();
            StartCoroutine(colorChanger);

            if (Time.time > 5)
            {
                StopCoroutine(ChangeColor());


            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void ResetDisplay()
        {
            _currentLayer = -1;
        }


        private IEnumerator ChangeColor()
        {
            while(true)
            {
                yield return new WaitForSeconds(2);

                const string propName = "_Value";

                CellLayer[] layers = _model.Stack.Layers;
                int layer0 = _currentLayer + 1;
                int layer1 = _model.CurrentLayer;

                for (int i = layer0; i <= layer1; i++)
                {
                    foreach (var cell in layers[i].Cells)
                    {
                        // skip dead cells
                        if (cell.State == 0)
                            continue;

                        // update cell material
                        MeshRenderer renderer = cell.Renderer;
                        renderer.sharedMaterial = _ageMaterial;

                        // set material properties
                        {
                            renderer.GetPropertyBlock(_properties);

                            // normalize age
                            float value = SlurMath.Normalize(cell.Age, _ageDisplayMin, _ageDisplayMax);
                            _properties.SetFloat(propName, value);

                            renderer.SetPropertyBlock(_properties);
                        }
                    }
                }

                _currentLayer = layer1;

               
            }

        }



        /// <summary>
        /// 
        /// </summary>
        private float GetNeighborDensity(Cell[,] cells, Index2 index, Index2[] neighborhood)
        {
            int nrows = cells.GetLength(0);
            int ncols = cells.GetLength(1);
            int sum = 0;

            foreach (Index2 offset in neighborhood)
            {
                int i1 = Wrap(index.I + offset.I, nrows);
                int j1 = Wrap(index.J + offset.J, ncols);

                if (cells[i1, j1].State > 0)
                    sum++;
            }

            return (float)sum / neighborhood.Length;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int Wrap(int i, int n)
        {
            i %= n;
            return (i < 0) ? i + n : i;
        }
    }
}
