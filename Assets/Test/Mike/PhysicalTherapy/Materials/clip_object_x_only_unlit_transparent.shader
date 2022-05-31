// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32981,y:32762,varname:node_2865,prsc:2|diff-6343-OUT,spec-358-OUT,gloss-1813-OUT,normal-5964-RGB,emission-6343-OUT,alpha-4991-OUT,clip-1535-OUT;n:type:ShaderForge.SFN_Multiply,id:6343,x:32114,y:32712,varname:node_6343,prsc:2|A-7736-RGB,B-6665-RGB;n:type:ShaderForge.SFN_Color,id:6665,x:31921,y:32804,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31921,y:32620,ptovrint:True,ptlb:Base Color,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32407,y:32978,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:358,x:32250,y:32780,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:32250,y:32882,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_FragmentPosition,id:4076,x:31692,y:33031,varname:node_4076,prsc:2;n:type:ShaderForge.SFN_If,id:4378,x:32000,y:33105,varname:node_4378,prsc:2|A-4076-X,B-4551-OUT,GT-9788-OUT,EQ-9228-OUT,LT-9228-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4551,x:31659,y:33226,ptovrint:False,ptlb:xMin,ptin:_xMin,varname:node_4551,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.75;n:type:ShaderForge.SFN_Vector1,id:9788,x:31727,y:33289,varname:node_9788,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:9228,x:31777,y:33357,varname:node_9228,prsc:2,v1:0;n:type:ShaderForge.SFN_If,id:6592,x:32108,y:33375,varname:node_6592,prsc:2|A-4076-X,B-8742-OUT,GT-2217-OUT,EQ-2217-OUT,LT-2095-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8742,x:31768,y:33495,ptovrint:False,ptlb:xMax,ptin:_xMax,varname:_xMax_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.75;n:type:ShaderForge.SFN_Vector1,id:2217,x:31835,y:33558,varname:node_2217,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:2095,x:31885,y:33627,varname:node_2095,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:4202,x:32256,y:33196,varname:node_4202,prsc:2|A-4378-OUT,B-6592-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:5324,x:31765,y:33712,varname:node_5324,prsc:2;n:type:ShaderForge.SFN_Vector1,id:8685,x:31800,y:33970,varname:node_8685,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:4401,x:31850,y:34038,varname:node_4401,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:7399,x:31908,y:34239,varname:node_7399,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:1184,x:31958,y:34308,varname:node_1184,prsc:2,v1:1;n:type:ShaderForge.SFN_If,id:3473,x:32181,y:34056,varname:node_3473,prsc:2|A-5324-Y,B-2211-OUT,GT-7399-OUT,EQ-7399-OUT,LT-1184-OUT;n:type:ShaderForge.SFN_If,id:3956,x:32073,y:33786,varname:node_3956,prsc:2|A-5324-Y,B-8176-OUT,GT-8685-OUT,EQ-4401-OUT,LT-4401-OUT;n:type:ShaderForge.SFN_Multiply,id:6673,x:32329,y:33877,varname:node_6673,prsc:2|A-3956-OUT,B-3473-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:4382,x:31844,y:34451,varname:node_4382,prsc:2;n:type:ShaderForge.SFN_Vector1,id:6800,x:31879,y:34709,varname:node_6800,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:6956,x:31929,y:34777,varname:node_6956,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:3469,x:31987,y:34978,varname:node_3469,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:7762,x:32037,y:35047,varname:node_7762,prsc:2,v1:1;n:type:ShaderForge.SFN_If,id:5489,x:32260,y:34795,varname:node_5489,prsc:2|A-4382-Z,B-3584-OUT,GT-3469-OUT,EQ-3469-OUT,LT-7762-OUT;n:type:ShaderForge.SFN_If,id:767,x:32152,y:34525,varname:node_767,prsc:2|A-4382-Z,B-511-OUT,GT-6800-OUT,EQ-6956-OUT,LT-6956-OUT;n:type:ShaderForge.SFN_Multiply,id:8964,x:32408,y:34616,varname:node_8964,prsc:2|A-767-OUT,B-5489-OUT;n:type:ShaderForge.SFN_Multiply,id:302,x:32514,y:33438,varname:node_302,prsc:2|A-4202-OUT,B-6673-OUT;n:type:ShaderForge.SFN_Multiply,id:8192,x:32779,y:33728,varname:node_8192,prsc:2|A-302-OUT,B-8964-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8176,x:31715,y:33871,ptovrint:False,ptlb:yMin,ptin:_yMin,varname:node_8176,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.75;n:type:ShaderForge.SFN_ValueProperty,id:2211,x:31764,y:34167,ptovrint:False,ptlb:yMax,ptin:_yMax,varname:node_2211,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.75;n:type:ShaderForge.SFN_ValueProperty,id:511,x:31588,y:34698,ptovrint:False,ptlb:zMin,ptin:_zMin,varname:node_511,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.75;n:type:ShaderForge.SFN_ValueProperty,id:3584,x:31754,y:34922,ptovrint:False,ptlb:zMax,ptin:_zMax,varname:node_3584,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.75;n:type:ShaderForge.SFN_Multiply,id:7611,x:32514,y:33193,varname:node_7611,prsc:2|A-4202-OUT,B-3956-OUT;n:type:ShaderForge.SFN_Multiply,id:1535,x:32679,y:33272,varname:node_1535,prsc:2|A-7611-OUT,B-3473-OUT;n:type:ShaderForge.SFN_Multiply,id:4991,x:32730,y:33019,varname:node_4991,prsc:2|A-6665-A,B-1535-OUT;proporder:5964-6665-7736-358-1813-4551-8742-8176-2211-511-3584;pass:END;sub:END;*/

Shader "Shader Forge/clip_object_x_only_unlit_transparent" {
    Properties {
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Base Color", 2D) = "white" {}
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0.8
        _xMin ("xMin", Float ) = -0.75
        _xMax ("xMax", Float ) = 0.75
        _yMin ("yMin", Float ) = -0.75
        _yMax ("yMax", Float ) = 0.75
        _zMin ("zMin", Float ) = -0.75
        _zMax ("zMax", Float ) = 0.75
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform float _xMin;
            uniform float _xMax;
            uniform float _yMin;
            uniform float _yMax;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float node_4378_if_leA = step(i.posWorld.r,_xMin);
                float node_4378_if_leB = step(_xMin,i.posWorld.r);
                float node_9228 = 0.0;
                float node_6592_if_leA = step(i.posWorld.r,_xMax);
                float node_6592_if_leB = step(_xMax,i.posWorld.r);
                float node_2217 = 0.0;
                float node_4202 = (lerp((node_4378_if_leA*node_9228)+(node_4378_if_leB*1.0),node_9228,node_4378_if_leA*node_4378_if_leB)*lerp((node_6592_if_leA*1.0)+(node_6592_if_leB*node_2217),node_2217,node_6592_if_leA*node_6592_if_leB));
                float node_3956_if_leA = step(i.posWorld.g,_yMin);
                float node_3956_if_leB = step(_yMin,i.posWorld.g);
                float node_4401 = 0.0;
                float node_3956 = lerp((node_3956_if_leA*node_4401)+(node_3956_if_leB*1.0),node_4401,node_3956_if_leA*node_3956_if_leB);
                float node_3473_if_leA = step(i.posWorld.g,_yMax);
                float node_3473_if_leB = step(_yMax,i.posWorld.g);
                float node_7399 = 0.0;
                float node_3473 = lerp((node_3473_if_leA*1.0)+(node_3473_if_leB*node_7399),node_7399,node_3473_if_leA*node_3473_if_leB);
                float node_1535 = ((node_4202*node_3956)*node_3473);
                clip(node_1535 - 0.5);
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_6343 = (_MainTex_var.rgb*_Color.rgb);
                float3 emissive = node_6343;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(_Color.a*node_1535));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float _xMin;
            uniform float _xMax;
            uniform float _yMin;
            uniform float _yMax;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 posWorld : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float node_4378_if_leA = step(i.posWorld.r,_xMin);
                float node_4378_if_leB = step(_xMin,i.posWorld.r);
                float node_9228 = 0.0;
                float node_6592_if_leA = step(i.posWorld.r,_xMax);
                float node_6592_if_leB = step(_xMax,i.posWorld.r);
                float node_2217 = 0.0;
                float node_4202 = (lerp((node_4378_if_leA*node_9228)+(node_4378_if_leB*1.0),node_9228,node_4378_if_leA*node_4378_if_leB)*lerp((node_6592_if_leA*1.0)+(node_6592_if_leB*node_2217),node_2217,node_6592_if_leA*node_6592_if_leB));
                float node_3956_if_leA = step(i.posWorld.g,_yMin);
                float node_3956_if_leB = step(_yMin,i.posWorld.g);
                float node_4401 = 0.0;
                float node_3956 = lerp((node_3956_if_leA*node_4401)+(node_3956_if_leB*1.0),node_4401,node_3956_if_leA*node_3956_if_leB);
                float node_3473_if_leA = step(i.posWorld.g,_yMax);
                float node_3473_if_leB = step(_yMax,i.posWorld.g);
                float node_7399 = 0.0;
                float node_3473 = lerp((node_3473_if_leA*1.0)+(node_3473_if_leB*node_7399),node_7399,node_3473_if_leA*node_3473_if_leB);
                float node_1535 = ((node_4202*node_3956)*node_3473);
                clip(node_1535 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_6343 = (_MainTex_var.rgb*_Color.rgb);
                o.Emission = node_6343;
                
                float3 diffColor = float3(0,0,0);
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
