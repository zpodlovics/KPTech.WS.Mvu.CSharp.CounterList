// ---------------------------------------------------------------------------
// Copyright (c) 2019, Zoltan Podlovics, KP-Tech Kft. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0. See LICENSE.md in the 
// project root for license information.
// ---------------------------------------------------------------------------

using System;
using WebSharper;
using WebSharper.UI;
using Console = WebSharper.JavaScript.Console;
using Doc = WebSharper.UI.Doc;
using Html = WebSharper.UI.Client.Html;

namespace KPTech.WS.Mvu.CSharp.Counter
{
    [JavaScript]
    public static class Counter
    {

        public static Model Init()
        {
            return new Model(0, 0);
        }
        
        public static Model Init(int id)
        {
            return new Model(id, 0);
        }

        public static Model Update(Msg msg, Model model)
        {
            Console.Log("Counter.Update: " + msg.Tag);
            switch (msg.Tag)
            {
                case 1:
                    return new Model(model.Id, model.Counter + 1);
                case 2:
                    return new Model(model.Id, model.Counter - 1);
                default:
                    return model;
            }
        }

        public static Func<Msg, Model, Model> UpdateFunc = Update;

        public static Doc Render(Action<Msg> dispatch,
            View<Model> view)
        {
            var doc = Html.div(
                Html.button("+", () => dispatch(new Increment()), null), 
                Html.span(Html.text(view.V.Counter.ToString())), 
                Html.button("-", () => dispatch(new Decrement()), null)
            );

            return doc;
        }

        public static Func<Action<Msg>, View<Model>, Doc> RenderFunc = Render;
    }
}