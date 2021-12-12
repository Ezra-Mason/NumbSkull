Shader "Custom/ToonSurfaceShader" {
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _Detail("Detail", Range(0,5)) = 4
        _FullLight("Full Light Amount", Range(0,1)) = 0.25
        _Colour("Colour", COLOR) = (1,1,1,1)

    }
    SubShader{
        Tags { "RenderType" = "Opaque" }

        CGPROGRAM
        #pragma surface surf Ramp

        sampler2D _Ramp;
        float _Detail;
        float _FullLight;
        float _Colour;

        float4 LightingRamp(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {
            float NdotL = dot(s.Normal, lightDir);
            float stepRamp = ceil(NdotL*atten * _Detail + _FullLight) / _Detail;
            float diff = lerp(0.5, 1, stepRamp);

            float4 c;
            c.rgb = s.Albedo * diff * _LightColor0.rgb;
            c.a = s.Alpha;
            return c;

        }

        struct Input {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;

        void surf(Input IN, inout SurfaceOutput o) {
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
        }
        ENDCG

    }
        FallBack "Diffuse"
}