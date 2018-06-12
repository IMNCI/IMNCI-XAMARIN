using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace IMNCI.Data
{
    public class HIVCareGroup : ObservableCollection<Models.HIVCare>, INotifyPropertyChanged
    {
        private bool _expanded;

        public string Parent { get; set; }

        public int ItemCount { get; set; }

        public string ParentWithCount{
            get { return string.Format("{0} ({1})", Parent, ItemCount); }
        }

        public string Title { get; set; }

        public bool Expanded{
            get { return _expanded; }

            set
            {
                if(_expanded != value)
                {
                    _expanded = value;
                    //OnPropertyChanged(Expanded);
                    //OnPropertyChanged(StateIcon);
                }
            }
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public string StateIcon{
            get { return Expanded ? "expanded.png" : "collapsed.png"; }
        }

        public HIVCareGroup(string parent, bool expanded=true){
            Parent = parent;
            Expanded = expanded;
        }
    }
}
