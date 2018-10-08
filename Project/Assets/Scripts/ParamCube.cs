using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {
    public int _band;
    public float _startScale, _scaleMultiplier;
    public bool _useBuffer;
    Material _material;
	// Use this for initialization
	void Start () {
        _material = GetComponent<MeshRenderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () {
        if(_useBuffer)
        {
            transform.localScale = new Vector3((AudioDataCollector._audioBandBuffer[_band] * _scaleMultiplier) + _startScale, transform.localScale.y, transform.localScale.z);
            float colormix = AudioDataCollector._audioBandBuffer[_band] * 255;
            Color32 _color = new Color32(255, (byte)colormix, 255, 255);
            Debug.Log(colormix);
            GetComponent<Renderer>().material.color = _color;
        }
        if (!_useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioDataCollector._audioBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
            Color _color = new Color(AudioDataCollector._audioBand[_band], AudioDataCollector._audioBand[_band], AudioDataCollector._audioBand[_band]);
            Debug.Log("R : " + _color.r + "G: " + _color.g + " B: " + _color.b);
            GetComponent<Renderer>().material.color = _color;
        }
    }
}
