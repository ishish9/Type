Shader "Custom/URP/TronGridShader" {
    Properties {
        _BaseColor ("Base Color", Color) = (0, 0, 0, 1) // Dark background
        _GridColor ("Grid Color", Color) = (0, 1, 1, 1) // Cyan glow
        _GridSize ("Grid Size", Range(0.1, 20)) = 10.0 // Grid frequency
        _LineWidth ("Line Width", Range(0.01, 1)) = 0.1 // Width of grid lines
        _GlowIntensity ("Glow Intensity", Range(0, 5)) = 2.0 // How bright the glow is
        _PulseSpeed ("Pulse Speed", Range(0, 5)) = 1.0 // Speed of pulsing effect
        _Smoothness ("Smoothness", Range(0, 1)) = 0.5
        _Metallic ("Metallic", Range(0, 1)) = 0.0
    }
    SubShader {
        Tags { 
            "RenderType" = "Opaque" 
            "RenderPipeline" = "UniversalPipeline" 
            "Queue" = "Geometry"
        }
        LOD 100

        Pass {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                float3 normalOS : NORMAL;
            };

            struct Varyings {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 positionWS : TEXCOORD1;
                float3 normalWS : TEXCOORD2;
            };

            CBUFFER_START(UnityPerMaterial)
                float4 _BaseColor;
                float4 _GridColor;
                float _GridSize;
                float _LineWidth;
                float _GlowIntensity;
                float _PulseSpeed;
                float _Smoothness;
                float _Metallic;
            CBUFFER_END

            Varyings vert (Attributes input) {
                Varyings output;
                output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
                output.uv = input.uv;
                output.positionWS = TransformObjectToWorld(input.positionOS.xyz);
                output.normalWS = TransformObjectToWorldNormal(input.normalOS);
                return output;
            }

            half4 frag (Varyings input) : SV_Target {
                // Grid pattern using world position
                float2 gridUV = input.positionWS.xz * _GridSize;
                float2 grid = abs(frac(gridUV) - 0.5);
                float lines = smoothstep(_LineWidth, _LineWidth * 0.5, min(grid.x, grid.y));

                // Pulsing effect
                float pulse = sin(_Time.y * _PulseSpeed) * 0.5 + 0.5;
                float glow = lines * (1.0 + pulse * _GlowIntensity);

                // Combine base color and grid
                half3 finalColor = _BaseColor.rgb;
                finalColor = lerp(finalColor, _GridColor.rgb, glow);

                // Basic lighting
                Light mainLight = GetMainLight();
                half3 lighting = mainLight.color * max(0, dot(input.normalWS, mainLight.direction));
                half3 ambient = SampleSH(input.normalWS);

                // Output with lighting
                half3 litColor = finalColor * (lighting + ambient);
                return half4(litColor, 1.0);
            }
            ENDHLSL
        }
    }
    FallBack "Universal Render Pipeline/Lit"
}