// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:0,qpre:4,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.8160377,fgcg:1,fgcb:1,fgca:0.04313726,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:34556,y:32106,varname:node_4013,prsc:2|diff-8583-RGB,spec-7958-OUT,gloss-7958-OUT,emission-9073-OUT,amdfl-8583-RGB,amspl-7958-OUT,difocc-7958-OUT,spcocc-7958-OUT,alpha-2233-OUT;n:type:ShaderForge.SFN_TexCoord,id:651,x:31589,y:32295,varname:node_651,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:144,x:31103,y:32463,varname:node_144,prsc:2;n:type:ShaderForge.SFN_Vector1,id:7958,x:34147,y:31973,varname:node_7958,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:8583,x:34189,y:32363,ptovrint:False,ptlb:slimeTex,ptin:_slimeTex,varname:node_8583,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:40fdd8bfba8e16d498dd9ef0cd70de00,ntxv:0,isnm:False|UVIN-1478-OUT;n:type:ShaderForge.SFN_TexCoord,id:1435,x:33312,y:32335,varname:node_1435,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:1252,x:33538,y:32266,varname:node_1252,prsc:2|A-5213-OUT,B-1435-U;n:type:ShaderForge.SFN_Vector1,id:5213,x:33296,y:32277,varname:node_5213,prsc:2,v1:0.0625;n:type:ShaderForge.SFN_Append,id:6614,x:33855,y:32452,varname:node_6614,prsc:2|A-4347-OUT,B-4669-OUT;n:type:ShaderForge.SFN_Add,id:4347,x:33754,y:32266,varname:node_4347,prsc:2|A-1252-OUT,B-7349-OUT;n:type:ShaderForge.SFN_Time,id:3044,x:32684,y:32534,varname:node_3044,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7349,x:33506,y:32563,varname:node_7349,prsc:2|A-3518-OUT,B-6930-OUT;n:type:ShaderForge.SFN_Vector1,id:6930,x:33294,y:32753,varname:node_6930,prsc:2,v1:0.0625;n:type:ShaderForge.SFN_VertexColor,id:709,x:33949,y:32624,varname:node_709,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2233,x:34276,y:32535,varname:node_2233,prsc:2|A-8583-A,B-709-A;n:type:ShaderForge.SFN_Multiply,id:6976,x:33005,y:32546,varname:node_6976,prsc:2|A-3044-T,B-2811-OUT;n:type:ShaderForge.SFN_Vector1,id:2811,x:32846,y:32670,varname:node_2811,prsc:2,v1:10;n:type:ShaderForge.SFN_Ceil,id:3518,x:33222,y:32516,varname:node_3518,prsc:2|IN-6976-OUT;n:type:ShaderForge.SFN_Multiply,id:1478,x:34045,y:32488,varname:node_1478,prsc:2|A-6614-OUT,B-7356-OUT;n:type:ShaderForge.SFN_Vector1,id:7356,x:33741,y:32583,varname:node_7356,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:4669,x:33610,y:32394,varname:node_4669,prsc:2|A-1435-V,B-7697-OUT;n:type:ShaderForge.SFN_Vector1,id:7697,x:33402,y:32470,varname:node_7697,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:9073,x:34352,y:32219,varname:node_9073,prsc:2|A-416-OUT,B-8583-RGB;n:type:ShaderForge.SFN_Slider,id:416,x:33990,y:32174,ptovrint:False,ptlb:intensity,ptin:_intensity,varname:node_416,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1,max:2;proporder:8583-416;pass:END;sub:END;*/

Shader "Shader Forge/sun" {
    Properties {
        _slimeTex ("slimeTex", 2D) = "white" {}
        _intensity ("intensity", Range(1, 2)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Overlay"
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
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _slimeTex; uniform float4 _slimeTex_ST;
            uniform float _intensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_3044 = _Time;
                float2 node_1478 = (float2(((0.0625*i.uv0.r)+(ceil((node_3044.g*10.0))*0.0625)),(i.uv0.g*0.5))*2.0);
                float4 _slimeTex_var = tex2D(_slimeTex,TRANSFORM_TEX(node_1478, _slimeTex));
                float3 emissive = (_intensity*_slimeTex_var.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,(_slimeTex_var.a*i.vertexColor.a));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
