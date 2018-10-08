using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEffects : MonoBehaviour {
    private int band { set; get; }
    public float _startScale, _scaleMultiplier;
    public bool _useBuffer;
    Material _material;

    public int Band
    {
        get
        {
            return band;
        }
        set
        {
            if(value > 1 && value <= 7)
            {
                band = value;
            }
        }
    }
    // Use this for initialization
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (_useBuffer)
        {
            if(transform.localScale.x > _scaleMultiplier)
            {
                Debug.LogError("AUDIO: " + AudioDataCollector._audioBandBuffer[band] + "/ FORMULA " + (Mathf.Clamp(AudioDataCollector._audioBandBuffer[band], 0, 1) * 2) + _startScale);
            }
            transform.localScale = new Vector3((Mathf.Clamp(AudioDataCollector._audioBandBuffer[band], 0, 1) * (_scaleMultiplier - _startScale)) + _startScale, transform.localScale.y, transform.localScale.z);
            float colormix = AudioDataCollector._audioBandBuffer[band] * 255;
            Color32 _color = new Color32(255, (byte)colormix, 255, 255);
            GetComponent<Renderer>().material.color = _color;
        }
        if (!_useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioDataCollector._audioBand[band] * _scaleMultiplier) + _startScale, transform.localScale.z);
            Color _color = new Color(AudioDataCollector._audioBand[band], AudioDataCollector._audioBand[band], AudioDataCollector._audioBand[band]);
            GetComponent<Renderer>().material.color = _color;
        }
    }
}
