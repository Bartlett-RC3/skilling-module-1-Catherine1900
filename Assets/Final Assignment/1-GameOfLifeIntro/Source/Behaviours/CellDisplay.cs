using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3
{
    public class CellDisplay : MonoBehaviour
    {
        private ModelManager _manager;
        MaterialPropertyBlock _materialprops;//unity thing change each cell's color 


        // Start is called before the first frame update
        void Start()
        {
            _manager = GetComponent<ModelManager>();
            _materialprops = new MaterialPropertyBlock();

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
