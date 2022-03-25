// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32815,y:32713,varname:node_3138,prsc:2|emission-8281-RGB,alpha-9526-A;n:type:ShaderForge.SFN_Tex2d,id:8281,x:32554,y:32862,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_8281,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6119-OUT;n:type:ShaderForge.SFN_TexCoord,id:4674,x:31845,y:32769,varname:node_4674,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:7266,x:32037,y:32862,varname:node_7266,prsc:2|A-4674-UVOUT,B-734-OUT;n:type:ShaderForge.SFN_Vector1,id:734,x:31859,y:32944,varname:node_734,prsc:2,v1:0.7;n:type:ShaderForge.SFN_Add,id:9676,x:32211,y:32862,varname:node_9676,prsc:2|A-7266-OUT,B-5823-OUT;n:type:ShaderForge.SFN_Clamp01,id:6119,x:32367,y:32862,varname:node_6119,prsc:2|IN-9676-OUT;n:type:ShaderForge.SFN_Vector2,id:5823,x:32006,y:33067,varname:node_5823,prsc:2,v1:0.25,v2:0.25;n:type:ShaderForge.SFN_VertexColor,id:9526,x:32213,y:33065,varname:node_9526,prsc:2;proporder:8281;pass:END;sub:END;*/

Shader "Shader Forge/ScreenshotUnlit" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
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
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
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
                float2 node_6119 = saturate(((i.uv0*0.7)+float2(0.25,0.25)));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_6119, _MainTex));
                float3 emissive = _MainTex_var.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,i.vertexColor.a);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
