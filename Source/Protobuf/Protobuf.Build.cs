using UnrealBuildTool;
using System.IO;
public class Protobuf : ModuleRules
{
    private string ModulePath
    {
        get { return ModuleDirectory; }
    }

    private string ThirdPartyPath
    {
        get { return Path.Combine(ModulePath, "ThirdParty/"); }
    }

    public Protobuf(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
				// ... add other public dependencies that you statically link with here ...
			}
			);
			
        PublicSystemIncludePaths.AddRange(
            new string[]
            {
                Path.Combine(ThirdPartyPath,"protobuf/include")
            }
            );

        if(Target.bForceEnableRTTI)
        {
            bUseRTTI = true;
            PublicDefinitions.Add("GOOGLE_PROTOBUF_NO_RTTI=0");
        }
        else
        {
            bUseRTTI = false;
            PublicDefinitions.Add("GOOGLE_PROTOBUF_NO_RTTI=1");
        }

		ShadowVariableWarningLevel = WarningLevel.Off;

		PublicDefinitions.Add("HAVE_ZLIB=0");

		PublicDefinitions.Add("PROTOBUF_USE_DLLS");
        
        bWarningsAsErrors = false;
        bEnableUndefinedIdentifierWarnings = false;
        bEnableExceptions = true;
    }
}
