using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
 
[Serializable, VolumeComponentMenuForRenderPipeline("Custom/CustomEffectComponent", typeof(UniversalRenderPipeline))]
public sealed class CustomEffectComponent : VolumeComponent, IPostProcessComponent
{
    public ClampedFloatParameter intensity = new ClampedFloatParameter(value: 0, min: 0, max: 1, overrideState: true);
    public FloatParameter DistortionAmount = new FloatParameter(0.5f , false );
    public FloatParameter NoiseSpeed = new FloatParameter(0.5f , false );

    public bool IsActive() => intensity.value > 0;

    public bool IsTileCompatible()=> true;
}