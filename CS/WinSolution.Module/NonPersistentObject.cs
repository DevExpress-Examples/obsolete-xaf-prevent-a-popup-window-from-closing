using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace WinSolution.Module {
    [NonPersistent]
    public class NonPersistentObject : BaseObject {
        public NonPersistentObject(Session session) : base(session) { }
        private DateTime _currentCollectionDate;
        public DateTime CurrentCollectionDate {
            get { return _currentCollectionDate; }
            set { SetPropertyValue("CurrentCollectionDate", ref _currentCollectionDate, value); }
        }
        private DateTime _previousCollectionDate;
        public DateTime PreviousCollectionDate {
            get { return _previousCollectionDate; }
            set { SetPropertyValue("PreviousCollectionDate", ref _previousCollectionDate, value); }
        }
    }
}
