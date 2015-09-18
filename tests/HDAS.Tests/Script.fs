#I "../../bin/HDASSearchService"
#I "../../src/HDASSearchService/bin/"
#I "../HDASSearchService.Tests/bin/"
#r "../../packages/Fuchu/lib/Fuchu.dll"
#r "../../packages/Suave/lib/net40/Suave.dll"
#r "../../packages/FsPickler/lib/net40/FsPickler.dll"
#r "../../packages/Suave.Testing/lib/net40/Suave.Testing.dll"
#r @"System.Net.Http"
#r "../../packages/FSharp.Data/lib/net40/FSharp.Data.dll"
#r "../../packages/Unquote/lib/net40/Unquote.dll"
#r "../../packages/NUnit/lib/nunit.framework.dll"

open Suave
open Suave.Http
open Suave.Http.Applicatives
open Suave.Http.Successful
open Suave.Web
open Suave.Types
open NUnit.Framework
open Swensen.Unquote
open Swensen.Unquote.Operators
open Suave.Testing
open Fuchu


//Set pwd to the directory containing this script
System.Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

let hdasApp =
  choose [
    GET >>= path "/" >>= OK "Home"
    ]


let defaultConfig = { defaultConfig with
                                    bindings = [ HttpBinding.mk' HTTP "0.0.0.0" 8083 ]
                                    homeFolder = Some (__SOURCE_DIRECTORY__ + "/web")
                    }

//printf "Running with config:\n%A" defaultConfig
//startWebServer defaultConfig hdasApp
