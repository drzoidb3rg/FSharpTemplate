
module HDAS.Program

open System
open System.Net

open Suave
open Suave.Sockets
open Suave.Sockets.Control
open Suave.Logging
open Suave.Web
open Suave.Http
open Suave.Http.EventSource
open Suave.Http.Applicatives
open Suave.Http.Writers
open Suave.Http.Files
open Suave.Http.Successful
open Suave.Types
open Suave.State.CookieStateStore
open Suave.Utils


let logger = Loggers.ConsoleWindowLogger LogLevel.Verbose



System.Net.ServicePointManager.DefaultConnectionLimit <- Int32.MaxValue


// Adds a new mime type to the default map
let mimeTypes =
  Writers.defaultMimeTypesMap
    >=> (function | ".avi" -> Writers.mkMimeType "video/avi" false | _ -> None)

let hdasApp =
  choose [
    GET >>= path "/" >>= OK "Home"
    ]


[<EntryPoint>]
let main argv =
  //let defaultConfig = { defaultConfig with bindings = [ HttpBinding.mk' HTTP "0.0.0.0" 8083 ] }
  (*let cert =
    let bio = BIO.MemoryBuffer()
    let cert = System.IO.File.ReadAllBytes "example.pem"
    bio.Write cert
    OpenSSL.X509.X509Certificate.FromDER bio*)

  startWebServer
    { bindings              = [ HttpBinding.mk' HTTP "0.0.0.0" 8082
                                //HttpBinding.mk' (HTTPS (Provider.open_ssl cert)) "127.0.0.1" 8443
                              ]
      serverKey             = Utils.Crypto.generateKey HttpRuntime.ServerKeyLength
      errorHandler          = defaultErrorHandler
      listenTimeout         = TimeSpan.FromMilliseconds 2000.
      cancellationToken     = Async.DefaultCancellationToken
      bufferSize            = 2048
      maxOps                = 100
      mimeTypesMap          = mimeTypes
      homeFolder            = None
      compressedFilesFolder = None
      logger                = logger }
   hdasApp 
  0
