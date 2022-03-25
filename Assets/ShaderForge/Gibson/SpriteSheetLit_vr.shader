// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:1,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.3921569,fgcg:0.8823529,fgcb:1,fgca:1,fgde:0.01,fgrn:0,fgrf:120,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:-1,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:34987,y:32059,varname:node_4013,prsc:2|diff-9010-OUT,spec-7958-OUT,gloss-7958-OUT,emission-9010-OUT,amdfl-8704-OUT,amspl-7958-OUT,difocc-7958-OUT,spcocc-7958-OUT;n:type:ShaderForge.SFN_TexCoord,id:651,x:31589,y:32295,varname:node_651,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:144,x:31103,y:32463,varname:node_144,prsc:2;n:type:ShaderForge.SFN_Vector1,id:7958,x:34704,y:32258,varname:node_7958,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:8583,x:34189,y:32363,ptovrint:False,ptlb:slimeTex,ptin:_slimeTex,varname:node_8583,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:40fdd8bfba8e16d498dd9ef0cd70de00,ntxv:0,isnm:False|UVIN-1478-OUT;n:type:ShaderForge.SFN_TexCoord,id:1435,x:33312,y:32335,varname:node_1435,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:1252,x:33538,y:32266,varname:node_1252,prsc:2|A-81-OUT,B-1435-U;n:type:ShaderForge.SFN_Append,id:6614,x:33830,y:32420,varname:node_6614,prsc:2|A-4347-OUT,B-4669-OUT;n:type:ShaderForge.SFN_Add,id:4347,x:33754,y:32266,varname:node_4347,prsc:2|A-1252-OUT,B-7349-OUT;n:type:ShaderForge.SFN_Time,id:3044,x:32899,y:31965,varname:node_3044,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7349,x:33552,y:32103,varname:node_7349,prsc:2|A-3518-OUT,B-6935-OUT;n:type:ShaderForge.SFN_Multiply,id:6976,x:33101,y:31973,varname:node_6976,prsc:2|A-3044-T,B-4045-OUT;n:type:ShaderForge.SFN_Ceil,id:3518,x:33270,y:31973,varname:node_3518,prsc:2|IN-6976-OUT;n:type:ShaderForge.SFN_Multiply,id:1478,x:34032,y:32398,varname:node_1478,prsc:2|A-6614-OUT,B-8390-OUT;n:type:ShaderForge.SFN_Multiply,id:4669,x:33610,y:32394,varname:node_4669,prsc:2|A-1435-V,B-9583-OUT;n:type:ShaderForge.SFN_Multiply,id:9073,x:34536,y:32142,varname:node_9073,prsc:2|A-1338-OUT,B-7451-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4045,x:32899,y:32105,ptovrint:False,ptlb:rate,ptin:_rate,varname:node_4045,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:8;n:type:ShaderForge.SFN_ValueProperty,id:8390,x:33759,y:32613,ptovrint:False,ptlb:tile,ptin:_tile,varname:node_8390,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_ValueProperty,id:6935,x:33284,y:32123,ptovrint:False,ptlb:1/frames,ptin:_1frames,varname:node_6935,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.125;n:type:ShaderForge.SFN_ValueProperty,id:9634,x:33211,y:32207,ptovrint:False,ptlb:U Mult,ptin:_UMult,varname:node_9634,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.25;n:type:ShaderForge.SFN_ValueProperty,id:9251,x:33158,y:32540,ptovrint:False,ptlb:vertical scale,ptin:_verticalscale,varname:node_9251,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:9668,x:33400,y:31940,varname:node_9668,prsc:2,v1:1;n:type:ShaderForge.SFN_Subtract,id:9583,x:33371,y:32573,cmnt:remove seam,varname:node_9583,prsc:2|A-9251-OUT,B-3352-OUT;n:type:ShaderForge.SFN_Subtract,id:81,x:33393,y:32207,varname:node_81,prsc:2|A-9634-OUT,B-3352-OUT;n:type:ShaderForge.SFN_Vector1,id:3352,x:33085,y:32281,varname:node_3352,prsc:2,v1:0.0001;n:type:ShaderForge.SFN_Vector1,id:1338,x:34267,y:32157,varname:node_1338,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Hue,id:304,x:34566,y:32450,varname:node_304,prsc:2|IN-5539-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:1147,x:34129,y:32656,varname:node_1147,prsc:2;n:type:ShaderForge.SFN_Distance,id:5967,x:34381,y:32692,varname:node_5967,prsc:2|A-1147-XYZ,B-7354-OUT;n:type:ShaderForge.SFN_Vector3,id:7354,x:34157,y:32792,varname:node_7354,prsc:2,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_Frac,id:6191,x:34728,y:32703,varname:node_6191,prsc:2|IN-7106-OUT;n:type:ShaderForge.SFN_Lerp,id:7451,x:34458,y:32296,varname:node_7451,prsc:2|A-8583-RGB,B-304-OUT,T-45-OUT;n:type:ShaderForge.SFN_Multiply,id:7106,x:34552,y:32716,varname:node_7106,prsc:2|A-5967-OUT,B-1599-OUT;n:type:ShaderForge.SFN_Add,id:5539,x:34371,y:32564,varname:node_5539,prsc:2|A-6742-TSL,B-6191-OUT;n:type:ShaderForge.SFN_Time,id:6742,x:33999,y:32550,varname:node_6742,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:45,x:34337,y:32498,ptovrint:False,ptlb:gradientLevel,ptin:_gradientLevel,varname:node_45,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:1599,x:34321,y:32901,ptovrint:False,ptlb:gradientSize,ptin:_gradientSize,varname:node_1599,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_FragmentPosition,id:345,x:33244,y:31260,varname:node_345,prsc:2;n:type:ShaderForge.SFN_Distance,id:8294,x:33753,y:31452,varname:node_8294,prsc:2|A-345-XYZ,B-7119-XYZ;n:type:ShaderForge.SFN_Vector3,id:3287,x:33221,y:31466,cmnt:replace this node with barkleys world position,varname:node_3287,prsc:2,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_Clamp01,id:2294,x:34071,y:31699,varname:node_2294,prsc:2|IN-8970-OUT;n:type:ShaderForge.SFN_Multiply,id:8970,x:33912,y:31712,varname:node_8970,prsc:2|A-8294-OUT,B-84-OUT;n:type:ShaderForge.SFN_Vector1,id:7775,x:33503,y:31652,cmnt:configure fog radius here smaller number wider radius,varname:node_7775,prsc:2,v1:0.08;n:type:ShaderForge.SFN_ValueProperty,id:84,x:33609,y:31732,ptovrint:False,ptlb:fog_radius,ptin:fog_radius,varname:node_1130,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Vector4Property,id:7119,x:33339,y:31561,ptovrint:False,ptlb:barkley_pos,ptin:barkley_pos,varname:node_1119,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5,v2:0.5,v3:0.5,v4:1;n:type:ShaderForge.SFN_Lerp,id:9010,x:34556,y:31778,varname:node_9010,prsc:2|A-9073-OUT,B-7198-RGB,T-2294-OUT;n:type:ShaderForge.SFN_Color,id:7198,x:34194,y:31879,ptovrint:False,ptlb:FogColor,ptin:_FogColor,varname:node_6507,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3679245,c2:0.3679245,c3:0.3679245,c4:0;n:type:ShaderForge.SFN_Lerp,id:8704,x:34748,y:31653,varname:node_8704,prsc:2|A-9073-OUT,B-1064-OUT,T-2294-OUT;n:type:ShaderForge.SFN_Vector3,id:1064,x:34350,y:31637,varname:node_1064,prsc:2,v1:0,v2:0,v3:0;proporder:8583-4045-8390-6935-9634-9251-7198;pass:END;sub:END;*/

Shader "Shader Forge/SpriteSheetLitVR" {
    Properties {
        _slimeTex ("slimeTex", 2D) = "white" {}
        _rate ("rate", Float ) = 8
        _tile ("tile", Float ) = 2
        _1frames ("1/frames", Float ) = 0.125
        _UMult ("U Mult", Float ) = 0.25
        _verticalscale ("vertical scale", Float ) = 0.5
        _FogColor ("FogColor", Color) = (0.3679245,0.3679245,0.3679245,0)
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
            
            Offset -1, 0
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
            uniform sampler2D _slimeTex; uniform float4 _slimeTex_ST;
            uniform float _rate;
            uniform float _tile;
            uniform float _1frames;
            uniform float _UMult;
            uniform float _verticalscale;
            uniform float _gradientLevel;
            uniform float _gradientSize;
            uniform float fog_radius;
            uniform float4 barkley_pos;
            uniform float4 _FogColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
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
                float node_3352 = 0.0001;
                float4 node_3044 = _Time;
                float2 node_1478 = (float2((((_UMult-node_3352)*i.uv0.r)+(ceil((node_3044.g*_rate))*_1frames)),(i.uv0.g*(_verticalscale-node_3352)))*_tile);
                float4 _slimeTex_var = tex2D(_slimeTex,TRANSFORM_TEX(node_1478, _slimeTex));
                float4 node_6742 = _Time;
                float3 node_9073 = (1.5*lerp(_slimeTex_var.rgb,saturate(3.0*abs(1.0-2.0*frac((node_6742.r+frac((distance(i.posWorld.rgb,float3(0,0,0))*_gradientSize)))+float3(0.0,-1.0/3.0,1.0/3.0)))-1),_gradientLevel));
                float node_2294 = saturate((distance(i.posWorld.rgb,barkley_pos.rgb)*fog_radius));
                float3 node_9010 = lerp(node_9073,_FogColor.rgb,node_2294);
                float3 diffuseColor = node_9010; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (0 + float3(node_7958,node_7958,node_7958));
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
/////// Diffuse:
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += lerp(node_9073,float3(0,0,0),node_2294); // Diffuse Ambient Light
                indirectDiffuse *= node_7958; // Diffuse AO
////// Emissive:
                float3 emissive = node_9010;
/// Final Color:
                outDiffuse = half4( diffuseColor, node_7958 );
                outSpecSmoothness = half4( specularColor, gloss );
                outNormal = half4( normalDirection * 0.5 + 0.5, 1 );
                outEmission = half4( node_9010, 1 );
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
            
            Offset -1, 0
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
            uniform sampler2D _slimeTex; uniform float4 _slimeTex_ST;
            uniform float _rate;
            uniform float _tile;
            uniform float _1frames;
            uniform float _UMult;
            uniform float _verticalscale;
            uniform float _gradientLevel;
            uniform float _gradientSize;
            uniform float fog_radius;
            uniform float4 barkley_pos;
            uniform float4 _FogColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
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
                float node_3352 = 0.0001;
                float4 node_3044 = _Time;
                float2 node_1478 = (float2((((_UMult-node_3352)*i.uv0.r)+(ceil((node_3044.g*_rate))*_1frames)),(i.uv0.g*(_verticalscale-node_3352)))*_tile);
                float4 _slimeTex_var = tex2D(_slimeTex,TRANSFORM_TEX(node_1478, _slimeTex));
                float4 node_6742 = _Time;
                float3 node_9073 = (1.5*lerp(_slimeTex_var.rgb,saturate(3.0*abs(1.0-2.0*frac((node_6742.r+frac((distance(i.posWorld.rgb,float3(0,0,0))*_gradientSize)))+float3(0.0,-1.0/3.0,1.0/3.0)))-1),_gradientLevel));
                float node_2294 = saturate((distance(i.posWorld.rgb,barkley_pos.rgb)*fog_radius));
                float3 node_9010 = lerp(node_9073,_FogColor.rgb,node_2294);
                float3 diffuseColor = node_9010; // Need this for specular when using metallic
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
                indirectDiffuse += lerp(node_9073,float3(0,0,0),node_2294); // Diffuse Ambient Light
                indirectDiffuse *= node_7958; // Diffuse AO
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = node_9010;
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
