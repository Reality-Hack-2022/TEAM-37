// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33503,y:32632,varname:node_9361,prsc:2|emission-6574-OUT,clip-1775-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:8068,x:32752,y:33535,varname:node_8068,prsc:2;n:type:ShaderForge.SFN_LightColor,id:3406,x:32752,y:33401,varname:node_3406,prsc:2;n:type:ShaderForge.SFN_LightVector,id:6869,x:31876,y:33103,varname:node_6869,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:9684,x:31876,y:33231,prsc:2,pt:True;n:type:ShaderForge.SFN_HalfVector,id:9471,x:31876,y:33382,varname:node_9471,prsc:2;n:type:ShaderForge.SFN_Dot,id:7782,x:32088,y:33146,cmnt:Lambert,varname:node_7782,prsc:2,dt:1|A-6869-OUT,B-9684-OUT;n:type:ShaderForge.SFN_Dot,id:3269,x:32088,y:33320,cmnt:Blinn-Phong,varname:node_3269,prsc:2,dt:1|A-9684-OUT,B-9471-OUT;n:type:ShaderForge.SFN_Multiply,id:2746,x:32483,y:33315,cmnt:Specular Contribution,varname:node_2746,prsc:2|A-7782-OUT,B-5267-OUT,C-4865-RGB;n:type:ShaderForge.SFN_Tex2d,id:851,x:31861,y:32163,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_851,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1941,x:32483,y:33142,cmnt:Diffuse Contribution,varname:node_1941,prsc:2|A-544-OUT,B-7782-OUT;n:type:ShaderForge.SFN_Color,id:5927,x:31876,y:32901,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_5927,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Exp,id:1700,x:32088,y:33503,varname:node_1700,prsc:2,et:1|IN-9978-OUT;n:type:ShaderForge.SFN_Slider,id:5328,x:31547,y:33505,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_5328,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Power,id:5267,x:32286,y:33389,varname:node_5267,prsc:2|VAL-3269-OUT,EXP-1700-OUT;n:type:ShaderForge.SFN_Add,id:2159,x:32752,y:33261,cmnt:Combine,varname:node_2159,prsc:2|A-1941-OUT,B-2746-OUT;n:type:ShaderForge.SFN_Multiply,id:5085,x:32997,y:33401,cmnt:Attenuate and Color,varname:node_5085,prsc:2|A-2159-OUT,B-3406-RGB,C-8068-OUT;n:type:ShaderForge.SFN_ConstantLerp,id:9978,x:31876,y:33505,varname:node_9978,prsc:2,a:1,b:11|IN-5328-OUT;n:type:ShaderForge.SFN_Color,id:4865,x:32286,y:33544,ptovrint:False,ptlb:Spec Color,ptin:_SpecColor,varname:node_4865,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_AmbientLight,id:7528,x:32539,y:32386,varname:node_7528,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2460,x:32820,y:32362,cmnt:Ambient Light,varname:node_2460,prsc:2|A-544-OUT,B-7528-RGB;n:type:ShaderForge.SFN_Multiply,id:544,x:32286,y:33038,cmnt:Diffuse Color,varname:node_544,prsc:2|A-1588-OUT,B-5927-RGB;n:type:ShaderForge.SFN_FragmentPosition,id:8636,x:31935,y:31741,varname:node_8636,prsc:2;n:type:ShaderForge.SFN_Distance,id:8925,x:32444,y:31933,varname:node_8925,prsc:2|A-8636-XYZ,B-1119-XYZ;n:type:ShaderForge.SFN_Vector3,id:5930,x:31912,y:31947,cmnt:replace this node with barkleys world position,varname:node_5930,prsc:2,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_Lerp,id:6574,x:33269,y:32422,varname:node_6574,prsc:2|A-2460-OUT,B-177-OUT,T-5736-OUT;n:type:ShaderForge.SFN_Clamp01,id:5736,x:32762,y:32180,varname:node_5736,prsc:2|IN-249-OUT;n:type:ShaderForge.SFN_Multiply,id:249,x:32603,y:32193,varname:node_249,prsc:2|A-8925-OUT,B-1130-OUT;n:type:ShaderForge.SFN_Multiply,id:1588,x:32157,y:32228,varname:node_1588,prsc:2|A-851-RGB,B-6001-OUT;n:type:ShaderForge.SFN_Lerp,id:8468,x:33296,y:32840,varname:node_8468,prsc:2|A-5085-OUT,B-6421-OUT,T-5736-OUT;n:type:ShaderForge.SFN_Vector1,id:6421,x:33040,y:32777,cmnt:geometry becomes unit as it lerps to fog color,varname:node_6421,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:6001,x:31877,y:32330,varname:node_6001,prsc:2,v1:2;n:type:ShaderForge.SFN_Vector1,id:5426,x:32194,y:32133,cmnt:configure fog radius here smaller number wider radius,varname:node_5426,prsc:2,v1:0.08;n:type:ShaderForge.SFN_Vector3,id:177,x:33051,y:32465,cmnt:fog color,varname:node_177,prsc:2,v1:0.3679245,v2:0.3679245,v3:0.3679245;n:type:ShaderForge.SFN_ValueProperty,id:1130,x:32300,y:32213,ptovrint:False,ptlb:fog_radius,ptin:fog_radius,varname:node_1130,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Clamp01,id:7194,x:32815,y:33593,varname:node_7194,prsc:2;n:type:ShaderForge.SFN_Vector4Property,id:1119,x:32030,y:32042,ptovrint:False,ptlb:barkley_pos,ptin:barkley_pos,varname:node_1119,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5,v2:0.5,v3:0.5,v4:1;n:type:ShaderForge.SFN_OneMinus,id:1775,x:33220,y:32553,varname:node_1775,prsc:2|IN-5736-OUT;proporder:851-5927-5328-4865;pass:END;sub:END;*/

Shader "Shader Forge/radialFog_skybox" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _Gloss ("Gloss", Range(0, 1)) = 0.5
        _SpecColor ("Spec Color", Color) = (1,1,1,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Color;
            uniform float fog_radius;
            uniform float4 barkley_pos;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float node_5736 = saturate((distance(i.posWorld.rgb,barkley_pos.rgb)*fog_radius));
                clip((1.0 - node_5736) - 0.5);
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_544 = ((_MainTex_var.rgb*2.0)*_Color.rgb); // Diffuse Color
                float3 emissive = lerp((node_544*UNITY_LIGHTMODEL_AMBIENT.rgb),float3(0.3679245,0.3679245,0.3679245),node_5736);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float fog_radius;
            uniform float4 barkley_pos;
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
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float node_5736 = saturate((distance(i.posWorld.rgb,barkley_pos.rgb)*fog_radius));
                clip((1.0 - node_5736) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
