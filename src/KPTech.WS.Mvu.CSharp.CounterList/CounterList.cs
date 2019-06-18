using System;
using System.Collections.Generic;
using System.Linq;
using WebSharper;
using WebSharper.UI;
using Console = WebSharper.JavaScript.Console;
using Doc = WebSharper.UI.Doc;
using Html = WebSharper.UI.Client.Html;

namespace KPTech.WS.Mvu.CSharp.CounterList
{
    [JavaScript]
    public static class CounterList
    {
        public static (int,System.Action<Msg>) CounterIdAction(System.Action<Msg> dispatch, Counter.Model model)
        {
            return (model.Id, dispatch);
        }

        public static Func<System.Action<Msg>,Counter.Model, (int,System.Action<Msg>)> CounterIdActionFunc = CounterIdAction;
        
        public static Model Init()
        {
            return Init(10);
        }
        
        public static Model Init(int count)
        {
            var counters = new List<Counter.Model>();
            for (int i = 0; i < count; i++)
            {
                counters.Add(new Counter.Model(i, 0));
            }

            return new Model(counters);
        }

        public static Model Update(Msg msg, Model model)
        {
            Console.Log("CounterList.Update: " + msg.Tag);
            switch (msg.Tag)
            {
                case 1:
                {
                    CounterMsg counterMsg = msg as CounterMsg;
                    var updatedCounters = model.Counters.Select((counter, i) => (i == counterMsg.Index) ? Counter.Counter.UpdateFunc(counterMsg.Msg, counter) : counter).ToList();
                    return new Model(updatedCounters);
                }
                     
                default:
                    return model;
            }
        }

        public static Func<Msg, Model, Model> UpdateFunc = Update;

        public static Doc RenderCounter((int,System.Action<Msg>) idDispatch, View<Counter.Model> view)
        {
            var (id, parentDispatch) = idDispatch;
            Action<Counter.Msg> dispatch = (msg) => parentDispatch.Invoke(new CounterMsg(id, msg));
            var doc = Html.div(
                Html.p(Html.text("Counter: " + id.ToString())),
                    Counter.Counter.RenderFunc(dispatch, view)
                );
            return doc;
        }

        public static Func<(int,System.Action<Msg>), View<Counter.Model>, Doc> RenderCounterFunc = RenderCounter;
        
        public static Doc Render(Action<Msg> dispatch,
            View<Model> view)
        {
            var counters = WebSharper.UI.V.V(view.V.CountersEnumerable);

            Func<Counter.Model, (int,System.Action<Msg>)> counterIdActionFuncPartial =
            (model) => CounterIdActionFunc(dispatch, model);
        
            var doc = counters.DocSeqCached(counterIdActionFuncPartial, RenderCounterFunc);

            return doc;
        }

        public static Func<Action<Msg>, View<Model>, Doc> RenderFunc = Render;        
        
    }
}