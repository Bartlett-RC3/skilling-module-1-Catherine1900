using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSlur;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelManager : MonoBehaviour
    {
        [SerializeField] private ModelInitializer _initializer;
        [SerializeField] private Cell _cellPrefab;
        [SerializeField] private int _countX = 50;
        [SerializeField] private int _countY = 50;
        [SerializeField] private int _ageDisplayMin = 0;
        [SerializeField] private int _ageDisplayMax = 10;
        [SerializeField] private Material _ageMaterial;
        MaterialPropertyBlock _properties;//unity thing change each cell's color 

        IEnumerator displayColor;
     

        private Cell[,] _cells;
        private GameOfLife2D _model;
        private int _stepCount;


        private List<int> _cellsSum = new List<int>();
        private int _calculate = 0;
        private int _density = 0;
        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {

            // create cell array
            _cells = new Cell[_countY, _countX];

            _properties = new MaterialPropertyBlock();

            // instantiate cell prefabs and store in array
            for (int y = 0; y < _countY; y++)
            {
                for (int x = 0; x < _countX; x++)
                {
                    Cell cell = Instantiate(_cellPrefab, transform);

                    cell.transform.localPosition = new Vector3(x, y, 0);
                    _cells[y, x] = cell;
                }
            }


            //Debug.Log("a");


            //Debug.Log("b");
            // create model
            _model = new GameOfLife2D(_countY, _countX);

            // initialize model
            _initializer.Initialize(_model.CurrentState);

        }


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            
            _model.Step();
            _stepCount++;
            // Debug.Log($"{_stepCount} steps taken!");

            int[,] state = _model.CurrentState;



            // update cells based on current state of model
            for (int y = 0; y < _countY; y++)
            {
                for (int x = 0; x < _countX; x++)
                {
                    _cells[y, x].State = state[y, x];
                   
                    _cells[y, x].Age = state[y, x] > 0 ? _cells[y, x].Age + 1 : 0;
                }
            }
           
             // update cells age
            
         

            var _density = CalculateDensity();
            
//            Debug.Log("density =" +_density);

         
            displayColor = DisplayColor();
            StartCoroutine(displayColor);

            if (Time.time > 5)
            {

                StopCoroutine(DisplayColor());
               
                StopAllCoroutines();
         
            }




        }

        private float CalculateDensity()
        {
           
            int aliveCount = 0;

            foreach (var cell in _cells)
                aliveCount += cell.State;

            _cellsSum.Add(aliveCount);

            return (float)aliveCount /_cells.Length;
        }

        private IEnumerator DisplayColor()
        {
            while (true)
            {
                foreach (var cell in _cells)
                {
                    if (cell.State == 0)
                        continue;

                    MeshRenderer renderer = cell.Renderer;
                    renderer.sharedMaterial = _ageMaterial;
                    const string propName = "_Value";
                    {
                        renderer.GetPropertyBlock(_properties);

                        // normalize age
                        float value = SlurMath.Normalize(cell.Age, _ageDisplayMin, _ageDisplayMax);
                        _properties.SetFloat(propName, value);

                        renderer.SetPropertyBlock(_properties);
                    }

                  //  cell.GetComponent<MeshRenderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);

                }
                yield return new WaitForSeconds(0.1f);

            }

        }


    }
}
