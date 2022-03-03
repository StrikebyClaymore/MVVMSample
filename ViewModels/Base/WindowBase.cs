using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMSample.Views.Windows.ViewModels.Base
{
    internal abstract class WindowBase : ViewModel
    {
        #region Window title

        private string _title;

        /// <summary> Заголовок окна </summary>
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        
        #endregion
    }
}
