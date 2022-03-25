// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:6,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32862,y:32747,varname:node_4013,prsc:2|diff-6632-OUT,emission-6632-OUT,alpha-1970-A;n:type:ShaderForge.SFN_Color,id:1304,x:32192,y:32724,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:1970,x:31995,y:32802,varname:node_1970,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8028,x:32457,y:32916,varname:node_8028,prsc:2|A-7590-OUT,B-4441-OUT;n:type:ShaderForge.SFN_Vector1,id:4441,x:32249,y:33051,varname:node_4441,prsc:2,v1:1.5;n:type:ShaderForge.SFN_FragmentPosition,id:5389,x:31817,y:33236,varname:node_5389,prsc:2;n:type:ShaderForge.SFN_Vector3,id:8540,x:31804,y:33361,varname:node_8540,prsc:2,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_Distance,id:9492,x:31992,y:33273,varname:node_9492,prsc:2|A-5389-XYZ,B-8540-OUT;n:type:ShaderForge.SFN_Multiply,id:7383,x:32182,y:33273,varname:node_7383,prsc:2|A-9492-OUT,B-2687-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2687,x:31992,y:33471,ptovrint:False,ptlb:_gradientSize,ptin:_gradientSize,varname:node_2687,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Frac,id:2996,x:32376,y:33273,varname:node_2996,prsc:2|IN-7383-OUT;n:type:ShaderForge.SFN_Add,id:6075,x:32546,y:33212,varname:node_6075,prsc:2|A-6494-TSL,B-2996-OUT;n:type:ShaderForge.SFN_Time,id:6494,x:32349,y:33152,varname:node_6494,prsc:2;n:type:ShaderForge.SFN_Hue,id:5358,x:32716,y:33212,varname:node_5358,prsc:2|IN-6075-OUT;n:type:ShaderForge.SFN_ValueProperty,id:874,x:31969,y:32970,ptovrint:False,ptlb:_gradientLevel,ptin:_gradientLevel,varname:node_874,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Lerp,id:7590,x:32249,y:32898,varname:node_7590,prsc:2|A-1970-RGB,B-5358-OUT,T-874-OUT;n:type:ShaderForge.SFN_Multiply,id:6632,x:32613,y:32782,varname:node_6632,prsc:2|A-1970-RGB,B-8028-OUT;proporder:1304;pass:END;sub:END;*/

Shader "Shader Forge/cubeParticlesVertColor" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
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
            ZTest Always
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float _gradientSize;
            uniform float _gradientLevel;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 node_6494 = _Time;
                float3 node_6632 = (i.vertexColor.rgb*(lerp(i.vertexColor.rgb,saturate(3.0*abs(1.0-2.0*frac((node_6494.r+frac((distance(i.posWorld.rgb,float3(0,0,0))*_gradientSize)))+float3(0.0,-1.0/3.0,1.0/3.0)))-1),_gradientLevel)*1.5));
                float3 diffuseColor = node_6632;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = node_6632;
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,i.vertexColor.a);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZTest Always
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float _gradientSize;
            uniform float _gradientLevel;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 node_6494 = _Time;
                float3 node_6632 = (i.vertexColor.rgb*(lerp(i.vertexColor.rgb,saturate(3.0*abs(1.0-2.0*frac((node_6494.r+frac((distance(i.posWorld.rgb,float3(0,0,0))*_gradientSize)))+float3(0.0,-1.0/3.0,1.0/3.0)))-1),_gradientLevel)*1.5));
                float3 diffuseColor = node_6632;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * i.vertexColor.a,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
