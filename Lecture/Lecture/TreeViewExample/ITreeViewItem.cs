using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TP.Lecture
{
    class ITreeViewItem
    {
        public ITreeViewItem()
        {
            Children = new ObservableCollection<ITreeViewItem>();
            Children.Add(null);
            this._wasBuilt = false;
        }
        public string Name { get; set; }
        public ObservableCollection<ITreeViewItem> Children { get; set; }
        public void buildMyself()
        {
            Random random = new Random();
            for (int i = 0; i < random.Next(7); i++)
            {
                this.Children.Add(new ITreeViewItem() { Name = "sample" + i });
            }
        }
        private bool _wasBuilt;
        private bool _isExpanded;
        public bool isExpanded
        {
            get { return _isExpanded; }
            set
            {
                _isExpanded = value;
                if (!_wasBuilt)
                {
                    Children.Clear();
                    buildMyself(); 
                    _wasBuilt = true;
                }

               
            }

        }
    }
}
