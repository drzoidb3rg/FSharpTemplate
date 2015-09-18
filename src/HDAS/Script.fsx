

#I "../../bin/HDAS"
#r "../../packages/Suave/lib/net40/Suave.dll" 

open Suave
open Suave.Http
open Suave.Http.Applicatives
open Suave.Http.Successful
open Suave.Types
#load "Program.fs"

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
