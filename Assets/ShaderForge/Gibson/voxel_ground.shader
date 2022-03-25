// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:1,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:34556,y:32106,varname:node_4013,prsc:2|diff-1230-OUT,spec-7958-OUT,gloss-7958-OUT,emission-1230-OUT,amdfl-1230-OUT,amspl-7958-OUT,difocc-7958-OUT,spcocc-7958-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32446,y:32776,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4387,x:32450,y:32349,varname:node_4387,prsc:2,tex:de7668ae9edcbfb4cadd8a3cda1e84b4,ntxv:0,isnm:False|UVIN-5759-OUT,TEX-7589-TEX;n:type:ShaderForge.SFN_TexCoord,id:651,x:31589,y:32295,varname:node_651,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:5759,x:32040,y:32314,varname:node_5759,prsc:2|A-166-OUT,B-9072-OUT;n:type:ShaderForge.SFN_Time,id:144,x:31103,y:32463,varname:node_144,prsc:2;n:type:ShaderForge.SFN_Tex2dAsset,id:7589,x:32143,y:32506,ptovrint:False,ptlb:node_7589,ptin:_node_7589,varname:node_7589,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:de7668ae9edcbfb4cadd8a3cda1e84b4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5381,x:32469,y:32500,varname:node_5381,prsc:2,tex:de7668ae9edcbfb4cadd8a3cda1e84b4,ntxv:0,isnm:False|UVIN-1587-OUT,TEX-7589-TEX;n:type:ShaderForge.SFN_Multiply,id:4196,x:32728,y:32455,varname:node_4196,prsc:2|A-4387-RGB,B-5381-RGB;n:type:ShaderForge.SFN_Subtract,id:1587,x:32143,y:32678,varname:node_1587,prsc:2|A-2009-OUT,B-9072-OUT;n:type:ShaderForge.SFN_Blend,id:1230,x:34139,y:32188,varname:node_1230,prsc:2,blmd:19,clmp:True|SRC-4495-OUT,DST-6371-OUT;n:type:ShaderForge.SFN_Round,id:2974,x:31631,y:32581,varname:node_2974,prsc:2|IN-3492-OUT;n:type:ShaderForge.SFN_Multiply,id:9072,x:31826,y:32597,varname:node_9072,prsc:2|A-2974-OUT,B-5893-OUT;n:type:ShaderForge.SFN_Vector1,id:5893,x:31631,y:32755,varname:node_5893,prsc:2,v1:0.012;n:type:ShaderForge.SFN_Multiply,id:3492,x:31472,y:32581,varname:node_3492,prsc:2|A-144-TTR,B-1624-OUT;n:type:ShaderForge.SFN_Vector1,id:1624,x:31268,y:32690,varname:node_1624,prsc:2,v1:5;n:type:ShaderForge.SFN_OneMinus,id:2009,x:31768,y:32377,varname:node_2009,prsc:2|IN-166-OUT;n:type:ShaderForge.SFN_Slider,id:8252,x:32635,y:32250,ptovrint:False,ptlb:sparsity,ptin:_sparsity,varname:node_8252,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Subtract,id:6937,x:33039,y:32219,varname:node_6937,prsc:2|A-4196-OUT,B-8252-OUT;n:type:ShaderForge.SFN_Clamp01,id:4807,x:33202,y:32219,varname:node_4807,prsc:2|IN-6937-OUT;n:type:ShaderForge.SFN_Multiply,id:4323,x:33454,y:32301,varname:node_4323,prsc:2|A-4807-OUT,B-7128-OUT;n:type:ShaderForge.SFN_HsvToRgb,id:4495,x:33867,y:32301,varname:node_4495,prsc:2|H-3666-HOUT,S-2794-OUT,V-3666-VOUT;n:type:ShaderForge.SFN_RgbToHsv,id:3666,x:33665,y:32301,varname:node_3666,prsc:2|IN-4323-OUT;n:type:ShaderForge.SFN_Slider,id:2794,x:33518,y:32150,ptovrint:False,ptlb:saturation,ptin:_saturation,varname:node_2794,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_FragmentPosition,id:9577,x:31043,y:32078,varname:node_9577,prsc:2;n:type:ShaderForge.SFN_Frac,id:2010,x:31430,y:32050,varname:node_2010,prsc:2|IN-5991-OUT;n:type:ShaderForge.SFN_Multiply,id:5991,x:31274,y:32050,varname:node_5991,prsc:2|A-9577-X,B-3378-OUT;n:type:ShaderForge.SFN_Vector1,id:3378,x:31060,y:32215,varname:node_3378,prsc:2,v1:0.01;n:type:ShaderForge.SFN_Append,id:166,x:31617,y:32087,varname:node_166,prsc:2|A-2010-OUT,B-2305-OUT;n:type:ShaderForge.SFN_Multiply,id:9409,x:31274,y:32181,varname:node_9409,prsc:2|A-9577-Z,B-3378-OUT;n:type:ShaderForge.SFN_Frac,id:2305,x:31445,y:32217,varname:node_2305,prsc:2|IN-9409-OUT;n:type:ShaderForge.SFN_Vector1,id:7128,x:33118,y:32517,varname:node_7128,prsc:2,v1:0.75;n:type:ShaderForge.SFN_Multiply,id:6371,x:33412,y:32732,varname:node_6371,prsc:2|A-1304-RGB,B-7128-OUT;n:type:ShaderForge.SFN_Vector1,id:7958,x:34139,y:32411,varname:node_7958,prsc:2,v1:0;proporder:1304-7589-8252-2794;pass:END;sub:END;*/

Shader "Shader Forge/voxel_ground" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _node_7589 ("node_7589", 2D) = "white" {}
        _sparsity ("sparsity", Range(0, 1)) = 0
        _saturation ("saturation", Range(0, 1)) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "DEFERRED"
            Tags {
                "LightMode"="Deferred"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_DEFERRED
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile ___ UNITY_HDR_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _node_7589; uniform float4 _node_7589_ST;
            uniform float _sparsity;
            uniform float _saturation;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            void frag(
                VertexOutput i,
                out half4 outDiffuse : SV_Target0,
                out half4 outSpecSmoothness : SV_Target1,
                out half4 outNormal : SV_Target2,
                out half4 outEmission : SV_Target3 )
            {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float node_7958 = 0.0;
                float gloss = node_7958;
                float perceptualRoughness = 1.0 - node_7958;
                float roughness = perceptualRoughness * perceptualRoughness;
/////// GI Data:
                UnityLight light; // Dummy light
                light.color = 0;
                light.dir = half3(0,1,0);
                light.ndotl = max(0,dot(normalDirection,light.dir));
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = 1;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
////// Specular:
                float3 specularColor = node_7958;
                float specularMonochrome;
                float node_3378 = 0.01;
                float2 node_166 = float2(frac((i.posWorld.r*node_3378)),frac((i.posWorld.b*node_3378)));
                float4 node_144 = _Time;
                float node_9072 = (round((node_144.a*5.0))*0.012);
                float2 node_5759 = (node_166+node_9072);
                float4 node_4387 = tex2D(_node_7589,TRANSFORM_TEX(node_5759, _node_7589));
                float2 node_1587 = ((1.0 - node_166)-node_9072);
                float4 node_5381 = tex2D(_node_7589,TRANSFORM_TEX(node_1587, _node_7589));
                float node_7128 = 0.75;
                float3 node_4323 = (saturate(((node_4387.rgb*node_5381.rgb)-_sparsity))*node_7128);
                float4 node_3666_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_3666_p = lerp(float4(float4(node_4323,0.0).zy, node_3666_k.wz), float4(float4(node_4323,0.0).yz, node_3666_k.xy), step(float4(node_4323,0.0).z, float4(node_4323,0.0).y));
                float4 node_3666_q = lerp(float4(node_3666_p.xyw, float4(node_4323,0.0).x), float4(float4(node_4323,0.0).x, node_3666_p.yzx), step(node_3666_p.x, float4(node_4323,0.0).x));
                float node_3666_d = node_3666_q.x - min(node_3666_q.w, node_3666_q.y);
                float node_3666_e = 1.0e-10;
                float3 node_3666 = float3(abs(node_3666_q.z + (node_3666_q.w - node_3666_q.y) / (6.0 * node_3666_d + node_3666_e)), node_3666_d / (node_3666_q.x + node_3666_e), node_3666_q.x);;
                float3 node_1230 = saturate(((_Color.rgb*node_7128)-(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(node_3666.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),_saturation)*node_3666.b)));
                float3 diffuseColor = node_1230; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (0 + float3(node_7958,node_7958,node_7958));
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
/////// Diffuse:
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += node_1230; // Diffuse Ambient Light
                indirectDiffuse *= node_7958; // Diffuse AO
////// Emissive:
                float3 emissive = node_1230;
/// Final Color:
                outDiffuse = half4( diffuseColor, node_7958 );
                outSpecSmoothness = half4( specularColor, gloss );
                outNormal = half4( normalDirection * 0.5 + 0.5, 1 );
                outEmission = half4( node_1230, 1 );
                outEmission.rgb += indirectSpecular;
                outEmission.rgb += indirectDiffuse * diffuseColor;
                #ifndef UNITY_HDR_ON
                    outEmission.rgb = exp2(-outEmission.rgb);
                #endif
            }
            ENDCG
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
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _node_7589; uniform float4 _node_7589_ST;
            uniform float _sparsity;
            uniform float _saturation;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
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
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float node_7958 = 0.0;
                float gloss = node_7958;
                float perceptualRoughness = 1.0 - node_7958;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularAO = node_7958;
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = node_7958;
                float specularMonochrome;
                float node_3378 = 0.01;
                float2 node_166 = float2(frac((i.posWorld.r*node_3378)),frac((i.posWorld.b*node_3378)));
                float4 node_144 = _Time;
                float node_9072 = (round((node_144.a*5.0))*0.012);
                float2 node_5759 = (node_166+node_9072);
                float4 node_4387 = tex2D(_node_7589,TRANSFORM_TEX(node_5759, _node_7589));
                float2 node_1587 = ((1.0 - node_166)-node_9072);
                float4 node_5381 = tex2D(_node_7589,TRANSFORM_TEX(node_1587, _node_7589));
                float node_7128 = 0.75;
                float3 node_4323 = (saturate(((node_4387.rgb*node_5381.rgb)-_sparsity))*node_7128);
                float4 node_3666_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_3666_p = lerp(float4(float4(node_4323,0.0).zy, node_3666_k.wz), float4(float4(node_4323,0.0).yz, node_3666_k.xy), step(float4(node_4323,0.0).z, float4(node_4323,0.0).y));
                float4 node_3666_q = lerp(float4(node_3666_p.xyw, float4(node_4323,0.0).x), float4(float4(node_4323,0.0).x, node_3666_p.yzx), step(node_3666_p.x, float4(node_4323,0.0).x));
                float node_3666_d = node_3666_q.x - min(node_3666_q.w, node_3666_q.y);
                float node_3666_e = 1.0e-10;
                float3 node_3666 = float3(abs(node_3666_q.z + (node_3666_q.w - node_3666_q.y) / (6.0 * node_3666_d + node_3666_e)), node_3666_d / (node_3666_q.x + node_3666_e), node_3666_q.x);;
                float3 node_1230 = saturate(((_Color.rgb*node_7128)-(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(node_3666.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),_saturation)*node_3666.b)));
                float3 diffuseColor = node_1230; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (0 + float3(node_7958,node_7958,node_7958)) * specularAO;
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                indirectDiffuse += node_1230; // Diffuse Ambient Light
                indirectDiffuse *= node_7958; // Diffuse AO
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = node_1230;
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _node_7589; uniform float4 _node_7589_ST;
            uniform float _sparsity;
            uniform float _saturation;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
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
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float node_7958 = 0.0;
                float gloss = node_7958;
                float perceptualRoughness = 1.0 - node_7958;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = node_7958;
                float specularMonochrome;
                float node_3378 = 0.01;
                float2 node_166 = float2(frac((i.posWorld.r*node_3378)),frac((i.posWorld.b*node_3378)));
                float4 node_144 = _Time;
                float node_9072 = (round((node_144.a*5.0))*0.012);
                float2 node_5759 = (node_166+node_9072);
                float4 node_4387 = tex2D(_node_7589,TRANSFORM_TEX(node_5759, _node_7589));
                float2 node_1587 = ((1.0 - node_166)-node_9072);
                float4 node_5381 = tex2D(_node_7589,TRANSFORM_TEX(node_1587, _node_7589));
                float node_7128 = 0.75;
                float3 node_4323 = (saturate(((node_4387.rgb*node_5381.rgb)-_sparsity))*node_7128);
                float4 node_3666_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_3666_p = lerp(float4(float4(node_4323,0.0).zy, node_3666_k.wz), float4(float4(node_4323,0.0).yz, node_3666_k.xy), step(float4(node_4323,0.0).z, float4(node_4323,0.0).y));
                float4 node_3666_q = lerp(float4(node_3666_p.xyw, float4(node_4323,0.0).x), float4(float4(node_4323,0.0).x, node_3666_p.yzx), step(node_3666_p.x, float4(node_4323,0.0).x));
                float node_3666_d = node_3666_q.x - min(node_3666_q.w, node_3666_q.y);
                float node_3666_e = 1.0e-10;
                float3 node_3666 = float3(abs(node_3666_q.z + (node_3666_q.w - node_3666_q.y) / (6.0 * node_3666_d + node_3666_e)), node_3666_d / (node_3666_q.x + node_3666_e), node_3666_q.x);;
                float3 node_1230 = saturate(((_Color.rgb*node_7128)-(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(node_3666.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),_saturation)*node_3666.b)));
                float3 diffuseColor = node_1230; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
