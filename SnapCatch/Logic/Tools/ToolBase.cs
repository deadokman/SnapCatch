using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Shapes;
using SnapCatch.Annotations;

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

        /// <summary>
        /// Reference to Layers manger
        /// </summary>
        protected LayersManager LayersManager { get; private set; }

        /// <summary>
        /// Reference to viewport manager
        /// </summary>
        protected ViewportManager ViewportManager { get; private set; }

        /// <summary>
        /// Base class for tool
        /// </summary>
        /// <param name="imgKey"> Resource key for tool icon </param>
        /// <param name="toolTipName"> Resource key for localized resource name </param>
        /// <param name="groupKey"> Group key for autogrouping feature </param>
        /// <param name="layersManager"> Reference to application layers manager </param>
        /// <param name="viewportManager"> Reference to application viewport manager </param>
        public ToolBase(string imgKey, string toolTipName, string groupKey, LayersManager layersManager, ViewportManager viewportManager) 
            : this()
        {
            LayersManager = layersManager;
            ViewportManager = viewportManager;
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
