Shader "Custom/Outline"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0

        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineWidth ("Outline Width", Range(0.01,1)) = 0.1        
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
        }
        LOD 200
        
        Tags
        {
            "Queue"="Transparent"
        }
        Pass
        {
            Name "Outline"
        
            ZWrite Off
        
            CGPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 origin : TEXCOORD0;
                float4 color : COLOR;
            };
            
            float4 _OutlineColor;
            float _OutlineWidth;
            
            v2f vert(appdata_base v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex * (1 + _OutlineWidth));
                o.color = _OutlineColor;
                return o;
            }
            
            float4 frag(v2f i) : SV_Target
            {
                return i.color;
            }
            
            ENDCG
            
            Blend SrcAlpha DstAlpha
        }
    
        CGPROGRAM
        
        #pragma surface surf Standard fullforwardshadows

        #pragma target 3.0

        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        
        ENDCG
    }
    FallBack "Diffuse"
}
