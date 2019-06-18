// ---------------------------------------------------------------------------
// Copyright (c) 2019, Zoltan Podlovics, KP-Tech Kft. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0. See LICENSE.md in the 
// project root for license information.
// ---------------------------------------------------------------------------

using KPTech.WS.Mvu.CSharp.CounterList;
using WebSharper;
using WebSharper.UI.Client;
using KPTech.WS.Mvu.FSharp.Extensions;
using Doc = WebSharper.UI.Doc;

namespace KPTech.WS.Mvu.CSharp.CounterList.App
{
    
    [JavaScript]
    public class Program
    {        
        
        [SPAEntryPoint]
        public static void ClientMain()
        {
            Model initialModel = CounterList.Init();
            var updateF = FSharpConvert.Fun(CounterList.UpdateFunc);
            var renderF = CounterList.RenderFunc.FromRenderFunc();
            
            var remoteDevOptions = new RemoteDev.Options()
            {
                hostname = "localhost",
                port = 8000
            };
            
            var app = WebSharper.Mvu.App.CreateSimple(initialModel, updateF, renderF);
            app = WebSharper.Mvu.App.WithRemoteDev(remoteDevOptions, app);
            Doc doc = WebSharper.Mvu.App.Run(app); 
            doc.RunById("main");
        }
    }
}
