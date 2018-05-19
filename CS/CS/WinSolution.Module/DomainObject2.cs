using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace WinSolution.Module {
    [DefaultClassOptions]
    public class DomainObject2 : BaseObject {
        public DomainObject2(Session session) : base(session) { }
    }

}
