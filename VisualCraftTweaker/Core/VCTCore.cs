using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VisualCraftTweaker.Models;

namespace VisualCraftTweaker.Core
{
    public sealed class VCTCore
    {
        private VCTCore() { }

        #region Singleton

        private static VCTCore _instance = null;
        private static readonly object _threadLock = new object();

        public static VCTCore Instance
        {
            get
            {
                lock (_threadLock)
                {
                    if (_instance == null)
                        _instance = new VCTCore();

                    return _instance;
                }
            }
        }

        #endregion

        //public Dictionary<string, Action<object, Action<string>>> AddRecipe { get; private set; }

        //#region Initialize

        //public void Initialize()
        //{
        //    AddRecipe = new Dictionary<string, Action<object, Action<string>>>
        //    {
        //        { "Remove", Remove },
        //        { "Shaped", Shaped },
        //        { "Shapless", Shapless }
        //    };




        //}

        //#endregion

        #region Recipe Logic

        public void Remove(object craft, Action<string> callback)
        {
            
        }

        public void Shaped(object craft, Action<string> callback)
        {

        }

        public void Shapless(object craft, Action<string> callback)
        {

        }

        #endregion

    }
}
