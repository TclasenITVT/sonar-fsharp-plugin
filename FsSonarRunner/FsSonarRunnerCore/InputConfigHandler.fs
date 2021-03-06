﻿module InputConfigHandler

open System
open System.IO
open FSharp.Data
open FSharpLint.Framework.Configuration

let CreateALintConfiguration(path : string) =
    if not(String.IsNullOrEmpty(path)) && File.Exists(path) then
        let sonarConfig = ConfHelper.InputConfigution.Parse(File.ReadAllText(path))
   
        let configdata = ()
        {
            Configuration.IgnoreFiles = None
            Analysers = Map(Seq.concat
                        [
                            (Map.toSeq (NamingConventionsConfig.SonarConfiguration(sonarConfig)));
                            (Map.toSeq (SourceLengthConfig.SonarConfiguration(sonarConfig)));
                            (Map.toSeq (BindingConfig.SonarConfiguration(sonarConfig)));
                            (Map.toSeq (NumberOfItemsConfig.SonarConfiguration(sonarConfig)));
                            (Map.toSeq (NestedStatementsConfig.SonarConfiguration(sonarConfig)));
                            (Map.toSeq (TypographyConfig.SonarConfiguration(sonarConfig)));
                            (Map.toSeq (FunctionReimplementationConfig.SonarConfiguration(sonarConfig)));
                            (Map.toSeq (RaiseWithTooManyArgumentsConfig.SonarConfiguration(sonarConfig)));
                            (Map.toSeq (HintsConfig.SonarConfiguration(sonarConfig)));
                            (Map.toSeq (RedundantNewKeywordConfig.SonarConfiguration(sonarConfig)));
                        ])
        }
    else
        FSharpLint.Framework.Configuration.defaultConfiguration
