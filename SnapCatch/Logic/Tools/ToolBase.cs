using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using SnapCatch.Annotations;
using SnapCatch.Resources;

namespace SnapCatch.Logic.Tools
{
    /// <summary>
    /// Tool selected delegate
    /// </summary>
    /// <returns></returns>
    public delegate void ToolSelected(ToolBase tool);

    public abstract class ToolBase : INotifyPropertyChanged
    {
        private string _toolName;
        private bool _isSelected;

        /// <summary>
        /// Resource key for tool name
        /// </summary>
        private string _toolNameKey;

        /// <summary>
        /// Куыщгксу лун ащк ещщд шьфпу
        /// </summary>
        private string _toolImageKey;

        /// <summary>
        /// Tool group collection
        /// </summary>
        public string ToolGroupKey { get; set; }

        /// <summary>
        /// Tool vactor path display
        /// </summary>
        public Path ToolImagePath { get; protected set; }

        /// <summary>
        /// Tooltip tool name
        /// </summary>
        public string ToolName
        {
            get { return _toolName; }
            protected set
            {
                _toolName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Tool selected property
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged();
                if (value)
                {
                    ToolSelected?.Invoke(this);
                }

            }
        }

        public virtual void InitTool(int order)
        {
            DefaultOrder = order;
        }

        /// <summary>
        /// Default tool order display
        /// </summary>
        public int DefaultOrder { get; protected set; }

        public void SetOrder(int order)
        {
            DefaultOrder = order;
        }

        public ToolBase(string imgKey, string toolTipName, string groupKey) 
            : this()
        {
            _toolImageKey = imgKey;
            _toolNameKey = toolTipName;
            ToolImagePath = (Path)Application.Current.FindResource(_toolImageKey);
            ToolName = (string)Application.Current.FindResource(_toolNameKey);
            ToolGroupKey = groupKey;
        }

        public ToolBase()
        {
            App.LanguageChanged += AppOnLanguageChanged;
        }

        private void AppOnLanguageChanged(object sender, EventArgs eventArgs)
        {
            ToolName = (string)Application.Current.FindResource(_toolNameKey);
        }

        /// <summary>
        /// Current tool instance selected
        /// </summary>
        public event ToolSelected ToolSelected;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
