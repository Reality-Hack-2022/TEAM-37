// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:True,qofs:0,qpre:1,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.3921569,fgcg:0.8823529,fgcb:1,fgca:1,fgde:0.01,fgrn:0,fgrf:120,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:34829,y:32090,varname:node_4013,prsc:2|diff-8583-RGB,spec-7958-OUT,gloss-7958-OUT,emission-9073-OUT,amdfl-8583-RGB,amspl-7958-OUT,difocc-7958-OUT,spcocc-7958-OUT,alpha-2233-OUT;n:type:ShaderForge.SFN_TexCoord,id:651,x:31589,y:32295,varname:node_651,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:144,x:31103,y:32463,varname:node_144,prsc:2;n:type:ShaderForge.SFN_Vector1,id:7958,x:34147,y:31973,varname:node_7958,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:8583,x:34189,y:32363,ptovrint:False,ptlb:slimeTex,ptin:_slimeTex,varname:node_8583,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:40fdd8bfba8e16d498dd9ef0cd70de00,ntxv:0,isnm:False|UVIN-1478-OUT;n:type:ShaderForge.SFN_TexCoord,id:1435,x:33363,y:32335,varname:node_1435,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:1252,x:33538,y:32266,varname:node_1252,prsc:2|A-4154-OUT,B-1435-U;n:type:ShaderForge.SFN_Append,id:6614,x:33830,y:32420,varname:node_6614,prsc:2|A-4347-OUT,B-4669-OUT;n:type:ShaderForge.SFN_Add,id:4347,x:33754,y:32266,varname:node_4347,prsc:2|A-1252-OUT,B-7349-OUT;n:type:ShaderForge.SFN_Time,id:3044,x:32899,y:31965,varname:node_3044,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7349,x:33552,y:32103,varname:node_7349,prsc:2|A-3518-OUT,B-6935-OUT;n:type:ShaderForge.SFN_VertexColor,id:709,x:33949,y:32624,varname:node_709,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2233,x:34460,y:32483,varname:node_2233,prsc:2|A-8583-A,B-709-A;n:type:ShaderForge.SFN_Multiply,id:6976,x:33101,y:31973,varname:node_6976,prsc:2|A-3044-T,B-4045-OUT;n:type:ShaderForge.SFN_Ceil,id:3518,x:33270,y:31973,varname:node_3518,prsc:2|IN-6976-OUT;n:type:ShaderForge.SFN_Multiply,id:1478,x:34032,y:32398,varname:node_1478,prsc:2|A-6614-OUT,B-8390-OUT;n:type:ShaderForge.SFN_Multiply,id:4669,x:33610,y:32394,varname:node_4669,prsc:2|A-1435-V,B-4319-OUT;n:type:ShaderForge.SFN_Multiply,id:9073,x:34608,y:32168,varname:node_9073,prsc:2|A-416-OUT,B-8871-OUT;n:type:ShaderForge.SFN_Slider,id:416,x:34269,y:32075,ptovrint:False,ptlb:intensity,ptin:_intensity,varname:node_416,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1,max:10;n:type:ShaderForge.SFN_ValueProperty,id:4045,x:32899,y:32105,ptovrint:False,ptlb:rate,ptin:_rate,varname:node_4045,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:8;n:type:ShaderForge.SFN_ValueProperty,id:8390,x:33759,y:32613,ptovrint:False,ptlb:tile,ptin:_tile,varname:node_8390,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_ValueProperty,id:6935,x:33284,y:32123,ptovrint:False,ptlb:1/frames,ptin:_1frames,varname:node_6935,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.125;n:type:ShaderForge.SFN_ValueProperty,id:9634,x:33132,y:32213,ptovrint:False,ptlb:U Mult,ptin:_UMult,varname:node_9634,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.25;n:type:ShaderForge.SFN_ValueProperty,id:9251,x:33285,y:32510,ptovrint:False,ptlb:vertical scale,ptin:_verticalscale,varname:node_9251,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:9668,x:33400,y:31940,varname:node_9668,prsc:2,v1:1;n:type:ShaderForge.SFN_Subtract,id:4319,x:33464,y:32558,cmnt:remove seam,varname:node_4319,prsc:2|A-9251-OUT,B-8167-OUT;n:type:ShaderForge.SFN_Vector1,id:8167,x:33059,y:32409,cmnt:remove seam,varname:node_8167,prsc:2,v1:0.0001;n:type:ShaderForge.SFN_Subtract,id:4154,x:33363,y:32194,cmnt:remove seam,varname:node_4154,prsc:2|A-9634-OUT,B-8167-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:485,x:34157,y:32660,varname:node_485,prsc:2;n:type:ShaderForge.SFN_Vector3,id:9486,x:34314,y:32804,varname:node_9486,prsc:2,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_Distance,id:5206,x:34491,y:32683,varname:node_5206,prsc:2|A-2851-OUT,B-9486-OUT;n:type:ShaderForge.SFN_Multiply,id:5853,x:34661,y:32683,varname:node_5853,prsc:2|A-5206-OUT,B-1683-OUT;n:type:ShaderForge.SFN_Vector1,id:1683,x:34441,y:32896,varname:node_1683,prsc:2,v1:0.01;n:type:ShaderForge.SFN_Frac,id:2328,x:34824,y:32724,varname:node_2328,prsc:2|IN-5853-OUT;n:type:ShaderForge.SFN_Hue,id:8564,x:34475,y:32368,varname:node_8564,prsc:2|IN-2328-OUT;n:type:ShaderForge.SFN_Lerp,id:8871,x:34495,y:32223,varname:node_8871,prsc:2|A-8583-RGB,B-8564-OUT,T-9020-OUT;n:type:ShaderForge.SFN_Vector1,id:9020,x:34228,y:32254,varname:node_9020,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Append,id:2851,x:34314,y:32649,varname:node_2851,prsc:2|A-485-X,B-485-Z;proporder:8583-416-4045-8390-6935-9634-9251;pass:END;sub:END;*/

Shader "Shader Forge/SpriteSheetUnlit" {
    Properties {
        _slimeTex ("slimeTex", 2D) = "white" {}
        _intensity ("intensity", Range(1, 10)) = 1
        _rate ("rate", Float ) = 8
        _tile ("tile", Float ) = 2
        _1frames ("1/frames", Float ) = 0.125
        _UMult ("U Mult", Float ) = 0.25
        _verticalscale ("vertical scale", Float ) = 0.5
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _slimeTex; uniform float4 _slimeTex_ST;
            uniform float _intensity;
            uniform float _rate;
            uniform float _tile;
            uniform float _1frames;
            uniform float _UMult;
            uniform float _verticalscale;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float node_8167 = 0.0001; // remove seam
                float4 node_3044 = _Time;
                float2 node_1478 = (float2((((_UMult-node_8167)*i.uv0.r)+(ceil((node_3044.g*_rate))*_1frames)),(i.uv0.g*(_verticalscale-node_8167)))*_tile);
                float4 _slimeTex_var = tex2D(_slimeTex,TRANSFORM_TEX(node_1478, _slimeTex));
                float3 emissive = (_intensity*lerp(_slimeTex_var.rgb,saturate(3.0*abs(1.0-2.0*frac(frac((distance(float2(i.posWorld.r,i.posWorld.b),float3(0,0,0))*0.01))+float3(0.0,-1.0/3.0,1.0/3.0)))-1),0.1));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(_slimeTex_var.a*i.vertexColor.a));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
