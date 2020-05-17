using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShaderController : MonoBehaviour
{
    public float min = 0, max = 1;

    public float _Softness;
    public float _FadeLimit;
    public float _WaveSpeed;
    public float _WaveAmp;
    public float _WaveOffset;

    public Material water;

    // Start is called before the first frame update
    void Start()
    {
        _Softness   = water.GetFloat("_Softness");
        _FadeLimit  = water.GetFloat("_FadeLimit");
        _WaveSpeed  = water.GetFloat("_WaveSpeed");
        _WaveAmp    = water.GetFloat("_WaveAmp");
        _WaveOffset = water.GetFloat("_WaveOffset");

    }

    // Update is called once per frame
    void Update()
    {
        water.SetFloat("_WaveSpeed", _Softness );
        water.SetFloat("_Softness",  _FadeLimit );
        water.SetFloat("_FadeLimit", _WaveSpeed );
        water.SetFloat("_WaveAmp",   _WaveAmp );
        water.SetFloat("_WaveOffset",_WaveOffset );






        
        
        
        
        








        //Debug.Log(water.GetFloat("_MainTex"));

    }
}
